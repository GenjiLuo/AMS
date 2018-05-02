using System;
using System.Collections.Generic;
using AMS.Model.dto;
using AMS.Model.poco;
using AMS.Model.Repositories.Implements;
using AMS.Model.Repositories.Interfaces;
using AMS.Model.ResponseModel;
using AMS.Service.Services.Interfaces;

namespace AMS.Service.Services.Implements
{
    public class JobService : IJobService
    {
        private readonly IJobRepository _jobRepository;

        public JobService()
        {
            _jobRepository=new JobRepository();
        }
        public List<JobDto> GetAllJob()
        {
            return _jobRepository.GetAllJob();
        }

        public ResModel AddJob(JobDto jobDto, UserDto operationUser)
        {
            return _jobRepository.AddJob(jobDto, operationUser);
        }

        public JobDto GetOneJob(Guid jobId)
        {
            return _jobRepository.GetOneJob(jobId);
        }

        public ResModel UpdateJob(JobDto jobDto, UserDto operationUser)
        {
            return _jobRepository.UpdateJob(jobDto, operationUser);
        }

        public ResModel DeleteJob(Guid jobId)
        {
            return _jobRepository.DeleteJob(jobId);
        }
    }
}
