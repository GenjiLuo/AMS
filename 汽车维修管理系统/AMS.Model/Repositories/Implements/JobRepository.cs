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
    public class JobRepository : IJobRepository
    {
        public List<JobDto> GetAllJob()
        {
            using (var db=new ModelContext())
            {
                var jobs = db.Job.Select(i => new JobDto()
                {
                    Id = i.Id,
                    Name = i.Name,
                    OrgId = i.OrgId,
                    OrgName = i.Org.Name,
                    OperationType = i.OperationType,
                    JobMenus = i.JobMenus.Select(j => new JobMenuDto()
                    {
                        Id = j.Id,
                        JobId = j.JobId,
                        MenuId = j.MenuId,
                        MenuName = j.Menu.Name
                    }).ToList()
                }).ToList();
                return jobs;
            }
        }

        public ResModel AddJob(JobDto jobDto, UserDto operationUser)
        {
            using (var db=new ModelContext())
            {
                var job=new Job()
                {
                    Id = Guid.NewGuid(),
                    Name = jobDto.Name,
                    OrgId = jobDto.OrgId,
                    CreateTime = DateTime.Now,
                    CreateBy = operationUser.Id
                };
                var jobMenus = jobDto.JobMenus.Select(i => new JobMenu()
                {
                    Id = Guid.NewGuid(),
                    MenuId = i.MenuId,
                    JobId = job.Id
                });
                using (var scope=new TransactionScope())
                {
                    try
                    {
                        db.Job.Add(job);
                        db.SaveChanges();
                        db.JobMenu.AddRange(jobMenus);
                        db.SaveChanges();
                        scope.Complete();
                    }
                    catch (Exception e)
                    {
                        return new ResModel(){Msg = "新增岗位失败",Success = false};
                    }
                    return new ResModel() { Msg = "新增岗位成功", Success = true };
                }
            }
        }

        public JobDto GetOneJob(Guid jobId)
        {
            using (var db=new ModelContext())
            {
                var job = db.Job.Where(i => i.Id == jobId).Select(i=>new JobDto()
                {
                    Id = i.Id,
                    Name = i.Name,
                    OrgId = i.OrgId,
                    OrgName = i.Org.Name,
                    OperationType = i.OperationType,
                    JobMenus = i.JobMenus.Select(j=>new JobMenuDto()
                    {
                        Id = j.Id,
                        JobId = j.JobId,
                        MenuId = j.MenuId,
                        MenuName = j.Menu.Name
                    }).ToList()
                }).FirstOrDefault();
                return job;
            }
        }

        public ResModel UpdateJob(JobDto jobDto, UserDto operationUser)
        {
            using (var db=new ModelContext())
            {
                var job = db.Job.FirstOrDefault(i => i.Id == jobDto.Id);
                if (job == null) 
                {
                    return new ResModel(){Msg = "更新失败，未找到该岗位",Success = false};
                }
                var jobMenus = jobDto.JobMenus.Select(i => new JobMenu()
                {
                    Id = Guid.NewGuid(),
                    MenuId = i.MenuId,
                    JobId = job.Id
                });
                using (var scope=new TransactionScope())
                {
                    try
                    {
                        job.OrgId = jobDto.OrgId;
                        job.Name = jobDto.Name;
                        job.UpdateTime = DateTime.Now;
                        job.UpdateBy = operationUser.Id;
                        db.JobMenu.RemoveRange(job.JobMenus);
                        db.SaveChanges();
                        db.JobMenu.AddRange(jobMenus);
                        db.SaveChanges();
                        scope.Complete();
                    }
                    catch (Exception e)
                    {
                        return new ResModel(){Msg = "更新失败",Success = false};
                    }
                    return new ResModel() { Msg = "更新成功", Success = true };
                }
            }
        }

        public ResModel DeleteJob(Guid jobId)
        {
            using (var db = new ModelContext())
            {
                var job = db.Job.FirstOrDefault(i => i.Id == jobId);
                if (job == null)
                {
                    return new ResModel() { Msg = "删除失败，未找到该岗位", Success = false };
                }
                if (job.OperationType == OperationTypeEnum.系统预置)
                {
                    return new ResModel() { Msg = "删除失败，系统预置内容不可删除", Success = false };
                }
                using (var scope=new TransactionScope())
                {
                    try
                    {
                        db.JobMenu.RemoveRange(job.JobMenus);
                        db.SaveChanges();
                        db.Job.Remove(job);
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

        public List<JobDto> GetJobsByOrgId(Guid orgId)
        {
            using (var db=new ModelContext())
            {
                var jobs = db.Job.Where(i => i.OrgId == orgId).Select(i => new JobDto()
                {
                    Id = i.Id,
                    Name = i.Name,
                    OperationType = i.OperationType
                }).ToList();
                return jobs;
            }
        }
    }
}
