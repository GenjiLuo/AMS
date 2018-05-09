using System;
using System.Collections.Generic;
using AMS.Model.dto;
using AMS.Model.Repositories.Implements;
using AMS.Model.Repositories.Interfaces;
using AMS.Model.ResponseModel;
using AMS.Service.Services.Interfaces;

namespace AMS.Service.Services.Implements
{
    public class ServiceBookingService : IServiceBookingService
    {
        private readonly IServiceBookingRepository _serviceBookingRepository;

        public ServiceBookingService()
        {
            _serviceBookingRepository=new ServiceBookingRepository();
        }

        public List<ServiceBookingDto> GetAllServiceBooking()
        {
            return _serviceBookingRepository.GetAllServiceBooking();
        }

        public ResModel AddServiceBooking(ServiceBookingDto serviceBookingDto, UserDto operationUser)
        {
            return _serviceBookingRepository.AddServiceBooking(serviceBookingDto, operationUser);
        }

        public ServiceBookingDto GetOneServiceBooking(Guid serviceBookingId)
        {
            return _serviceBookingRepository.GetOneServiceBooking(serviceBookingId);
        }

        public ResModel UpdateServiceBooking(ServiceBookingDto serviceBookingDto, UserDto operationUser)
        {
            return _serviceBookingRepository.UpdateServiceBooking(serviceBookingDto, operationUser);
        }

        public ResModel DeleteServiceBooking(Guid serviceBookingId)
        {
            return _serviceBookingRepository.DeleteServiceBooking(serviceBookingId);
        }

        public List<ServiceBookingDto> QueryServiceBooking(string keyword)
        {
            return _serviceBookingRepository.QueryServiceBooking(keyword);
        }
    }
}
