using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AMS.Model.dto;
using AMS.Model.Enum;
using AMS.Model.poco;
using AMS.Model.Repositories.Interfaces;
using AMS.Model.ResponseModel;

namespace AMS.Model.Repositories.Implements
{
    public class UserRepository : IUserRepository
    {
        public UserDto GetUserByLoginVM(UserDto userDto)
        {
            using (var db = new ModelContext())
            {
                var user = db.User.Where(i => i.Account == userDto.Account && i.Password == userDto.Password).Select(i => new UserDto
                {
                    Id = i.Id,
                    Name = i.Name,
                    Account = i.Account,
                    Password = i.Password,
                    OrgId = i.Org.Id,
                    OrgName = i.Org.Name,
                    OrgHope = i.Org.OrgHope
                }).FirstOrDefault();
                return user;
            };

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
                    OrgName = i.Org.Name
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
                    Tel = i.Tel
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
                try
                {
                    db.User.Add(user);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    return new ResModel() { Msg = "添加失败", Success = false };
                }
                return new ResModel() { Msg = "添加成功", Success = true };
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
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    return new ResModel() { Msg = "更新失败", Success = false };
                }
                return new ResModel() { Msg = "更新成功", Success = true };
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

                try
                {
                    db.User.Remove(user);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    return new ResModel() { Msg = "删除失败", Success = false };
                }
                return new ResModel() { Msg = "删除成功", Success = true };
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
