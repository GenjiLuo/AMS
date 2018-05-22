using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Transactions;
using AMS.Model.dto;
using AMS.Model.Enum;
using AMS.Model.poco;
using AMS.Model.Repositories.Interfaces;
using AMS.Model.ResponseModel;

namespace AMS.Model.Repositories.Implements
{
    public class UserRepository : IUserRepository
    {
        public Tuple<ResModel, UserDto,List<MenuDto>> GetUserByLoginVM(UserDto userDto)
        {
            using (var db = new ModelContext())
            {  
                var tuple = Tuple.Create<ResModel, UserDto, List<MenuDto>>(null, null, null);
                var user = db.User.Where(i => i.Account == userDto.Account).Select(i => new UserDto
                {
                    Id = i.Id,
                    Name = i.Name,
                    Account = i.Account,
                    Password = i.Password,
                    OrgId = i.Org.Id,
                    OrgName = i.Org.Name,
                    OrgHope = i.Org.OrgHope
                }).FirstOrDefault();
                if (user == null)
                {
                    tuple = Tuple.Create<ResModel, UserDto, List<MenuDto>>(
                        new ResModel() {Msg = "登录失败，该账号不存在", Success = false}, null, null);
                    return tuple;
                }

                if (user.Password != userDto.Password)
                {
                    tuple = Tuple.Create<ResModel, UserDto, List<MenuDto>>(
                        new ResModel() { Msg = "登录失败，密码错误", Success = false }, null, null);
                    return tuple;
                }

                var userJobs = db.UserJob.Where(i => i.UserId == user.Id).Select(i => new UserJobDto()
                {
                    Id = i.Id,
                    JobId = i.JobId,
                    JobName = i.Job.Name,
                    UserId = i.UserId,
                    UserName = i.User.Name
                });
                if (!userJobs.Any())
                {
                    tuple = Tuple.Create<ResModel, UserDto, List<MenuDto>>(
                        new ResModel() { Msg = "登录失败，该账号没有任何岗位权限，无法登录", Success = false }, null, null);
                    return tuple;
                }

                var count = 0;
                var authorizedMenus=new List<MenuDto>();
                foreach (var userJob in userJobs)
                {
                    var jobMenus = db.JobMenu.Where(i => i.JobId == userJob.JobId).Select(i=>new JobMenuDto()
                    {
                        Id = i.Id,
                        JobId = i.JobId,
                        JobName = i.Job.Name,
                        MenuId = i.MenuId,
                        MenuName = i.Menu.Name
                    });
                    if (jobMenus.Any())
                    {
                        count++;
                    }

                    foreach (var jobMenu in jobMenus)
                    {
                        var menu = new MenuDto()
                        {
                            Id =jobMenu.MenuId,
                            Name = jobMenu.MenuName
                        };
                        if (authorizedMenus.All(i => i.Id != menu.Id))
                        {
                            authorizedMenus.Add(menu);
                        }
                    }
                }

                if (count == 0)
                {
                    tuple = Tuple.Create<ResModel, UserDto, List<MenuDto>>(
                        new ResModel() { Msg = "登录失败，该账号岗位没有任何权限，无法登录", Success = false }, null, null);
                    return tuple;
                }
                tuple = Tuple.Create(
                    new ResModel() { Msg = "登录成功", Success = true }, user, authorizedMenus);
                return tuple;
            }
        }

        public List<UserDto> GetAllUser()
        {
            using (var db=new ModelContext())
            {
                var users = db.User.Select(i => new UserDto()
                {
                    Id=i.Id,
                    Name = i.Name,
                    State = i.State,
                    Account = i.Account,
                    OrgId = i.Org.Id,
                    OrgName = i.Org.Name,
                    OperationType = i.OperationType
                }).ToList();
                return users;
            }
        }

        public UserDto GetOneUser(UserDto userDto)
        {
            using (var db=new ModelContext())
            {
                var user=db.User.Where(i=>i.Id == userDto.Id).Select(i=>new UserDto()
                {
                    Id = i.Id,
                    Name = i.Name,
                    Account = i.Account,
                    Password = i.Password,
                    OrgId = i.Org.Id,
                    OrgName = i.Org.Name,
                    State = i.State,
                    Email = i.Email,
                    Tel = i.Tel,
                    UserJobs = i.UserJobs.Select(j=>new UserJobDto()
                    {
                        Id = j.Id,
                        JobId = j.JobId,
                        JobName = j.Job.Name,
                        UserId = j.UserId,
                        UserName = j.User.Name
                    }).ToList()
                }).FirstOrDefault();
                return user;
            }
        }

        public ResModel AddUser(UserDto userDto, UserDto operationUser)
        {
            using (var db = new ModelContext())
            {
                var user = new User()
                {
                    Id = Guid.NewGuid(),
                    Name = userDto.Name,
                    Account = userDto.Account,
                    Password = userDto.Password,
                    Email = userDto.Email,
                    Tel = userDto.Tel,
                    OrgId = userDto.OrgId,

                    CreateTime = DateTime.Now,
                    CreateBy = operationUser.Id
                };
                var userJobs = userDto.UserJobs.Select(i => new UserJob()
                {
                    Id = Guid.NewGuid(),
                    JobId = i.JobId,
                    UserId = user.Id
                });
                using (var scope=new TransactionScope())
                {
                    try
                    {
                        db.User.Add(user);
                        db.SaveChanges();
                        db.UserJob.AddRange(userJobs);
                        db.SaveChanges();
                        scope.Complete();
                    }
                    catch (Exception e)
                    {
                        return new ResModel() { Msg = "添加失败", Success = false };
                    }
                    return new ResModel() { Msg = "添加成功", Success = true };
                }
            }
        }

        public ResModel UpdateUser(UserDto userDto, UserDto operationUser)
        {
            using (var db=new ModelContext())
            {
                var user = db.User.FirstOrDefault(i => i.Id == userDto.Id);
                if (user == null)
                {
                    return new ResModel(){Msg = "更新失败，未找到该员工",Success = false};
                }
                if (user.OperationType == OperationTypeEnum.系统预置)
                {
                    return new ResModel() { Msg = "更新失败，系统预置账户不可更新", Success = false };
                }
                var userJobs = userDto.UserJobs.Select(i => new UserJob()
                {
                    Id = Guid.NewGuid(),
                    JobId = i.JobId,
                    UserId = user.Id
                });
                using (var scope=new TransactionScope())
                {
                    try
                    {
                        user.Name = userDto.Name;
                        user.Account = userDto.Account;
                        user.Password = userDto.Password;
                        user.Email = userDto.Email;
                        user.Tel = userDto.Tel;
                        user.OrgId = userDto.OrgId;

                        user.UpdateTime=DateTime.Now;
                        user.UpdateBy = operationUser.Id;
                        db.UserJob.RemoveRange(user.UserJobs);
                        db.SaveChanges();
                        db.UserJob.AddRange(userJobs);
                        db.SaveChanges();
                        scope.Complete();
                    }
                    catch (Exception e)
                    {
                        return new ResModel() { Msg = "更新失败", Success = false };
                    }
                    return new ResModel() { Msg = "更新成功", Success = true };
                }
            }
        }

        public ResModel DeleteUser(UserDto userDto, UserDto operationUser)
        {
            using (var db = new ModelContext())
            {
                var user = db.User.FirstOrDefault(i => i.Id == userDto.Id);
                if (user == null)
                {
                    return new ResModel() { Msg = "删除失败，未找到该员工", Success = false };
                }
                if (user.OperationType == OperationTypeEnum.系统预置)
                {
                    return new ResModel() { Msg = "删除失败，系统预置账户不可删除", Success = false };
                }
                using (var scope=new TransactionScope())
                {
                    try
                    {
                        db.UserJob.RemoveRange(user.UserJobs);
                        db.SaveChanges();
                        db.User.Remove(user);
                        db.SaveChanges();
                        scope.Complete();
                    }
                    catch (Exception e)
                    {
                        return new ResModel() { Msg = "删除失败", Success = false };
                    }
                    return new ResModel() { Msg = "删除成功", Success = true };
                }
            }
        }

        public ResModel ActiveUser(UserDto userDto, UserDto operationUser)
        {
            using (var db = new ModelContext())
            {
                var user = db.User.FirstOrDefault(i => i.Id == userDto.Id && i.State == (int)UserStateEnum.禁用);
                if (user == null)
                {
                    return new ResModel() { Msg = "激活失败，未找到该员工或该员工已激活", Success = false };
                }
                if (user.OperationType == OperationTypeEnum.系统预置)
                {
                    return new ResModel() { Msg = "激活失败，系统预置账户不可操作", Success = false };
                }
                try
                {
                    user.State = (int) UserStateEnum.激活;
                    user.UpdateTime=DateTime.Now;
                    user.CreateBy = operationUser.Id;
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    return new ResModel() { Msg = "激活失败", Success = false };
                }
                return new ResModel() { Msg = "激活成功", Success = true };
            }
        }

        public ResModel DisableUser(UserDto userDto, UserDto operationUser)
        {
            using (var db = new ModelContext())
            {
                var user = db.User.FirstOrDefault(i => i.Id == userDto.Id && i.State == (int)UserStateEnum.激活);
                if (user == null)
                {
                    return new ResModel() { Msg = "禁用失败，未找到该员工或该员工已禁用", Success = false };
                }
                if (user.OperationType == OperationTypeEnum.系统预置)
                {
                    return new ResModel() { Msg = "禁用失败，系统预置账户不可操作", Success = false };
                }
                try
                {
                    user.State = (int)UserStateEnum.禁用;
                    user.UpdateTime = DateTime.Now;
                    user.CreateBy = operationUser.Id;
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    return new ResModel() { Msg = "禁用失败", Success = false };
                }
                return new ResModel() { Msg = "禁用成功", Success = true };
            }
        }
    }
}
