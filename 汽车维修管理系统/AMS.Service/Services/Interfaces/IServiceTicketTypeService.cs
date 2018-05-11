using System;
using System.Collections.Generic;
using AMS.Model.dto;
using AMS.Model.ResponseModel;

namespace AMS.Service.Services.Interfaces
{
    public interface IServiceTicketTypeService
    {
        List<ServiceTicketTypeDto> GetAllServiceTicketType();
        ResModel AddServiceTicketType(ServiceTicketTypeDto serviceTicketTypeDto, UserDto operationUser);
        ServiceTicketTypeDto GetOneServiceTicketType(Guid serviceTicketTypeId);
        ResModel UpdateServiceTicketType(ServiceTicketTypeDto serviceTicketTypeDto, UserDto operationUser);
        ResModel DeleteServiceTicketType(Guid serviceTicketTypeId);
        List<ServiceTicketTypeDto> QueryServiceTicketType(string keyword);
    }
}
