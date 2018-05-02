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
                    OrgName = i.Org.Name
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
                try
                {
                    db.Job.Add(job);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    return new ResModel(){Msg = "新增岗位失败",Success = false};
                }
                return new ResModel() { Msg = "新增岗位成功", Success = true };
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
                    OrgName = i.Org.Name
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

                try
                {
                    job.OrgId = jobDto.OrgId;
                    job.Name = jobDto.Name;
                    job.UpdateTime = DateTime.Now;
                    job.UpdateBy = operationUser.Id;
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    return new ResModel(){Msg = "更新失败",Success = false};
                }
                return new ResModel() { Msg = "更新成功", Success = true };
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

                try
                {
                    db.Job.Remove(job);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    return new ResModel() { Msg = "删除失败", Success = false };
                }
                return new ResModel() { Msg = "删除成功", Success = true };
            }
        }
    }
}
