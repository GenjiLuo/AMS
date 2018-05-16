using System;
using System.Collections.Generic;
using AMS.Model.dto;
using AMS.Model.ResponseModel;

namespace AMS.Service.Services.Interfaces
{
    public interface IServiceBookingService
    {
        List<ServiceBookingDto> GetAllServiceBooking();
        ResModel AddServiceBooking(ServiceBookingDto serviceBookingDto, UserDto operationUser);
        ServiceBookingDto GetOneServiceBooking(Guid serviceBookingId);
        ResModel UpdateServiceBooking(ServiceBookingDto serviceBookingDto, UserDto operationUser);
        ResModel DeleteServiceBooking(Guid serviceBookingId);
        List<ServiceBookingDto> QueryServiceBooking(string keyword);
        ResModel TurnToInvalid(Guid serviceBookingId);
        ResModel TurnToRepair(Guid serviceBookingId);
    }
}
