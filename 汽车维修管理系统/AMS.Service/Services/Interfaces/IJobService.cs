using System;
using System.Collections.Generic;
using AMS.Model.dto;
using AMS.Model.poco;
using AMS.Model.ResponseModel;

namespace AMS.Service.Services.Interfaces
{
    public interface IJobService
    {
        List<JobDto> GetAllJob();
        ResModel AddJob(JobDto jobDto,UserDto operationUser);
        JobDto GetOneJob(Guid jobId);
        ResModel UpdateJob(JobDto jobDto, UserDto operationUser);
        ResModel DeleteJob(Guid jobId);
        List<JobDto> GetJobsByOrgId(Guid orgId);
    }
}
