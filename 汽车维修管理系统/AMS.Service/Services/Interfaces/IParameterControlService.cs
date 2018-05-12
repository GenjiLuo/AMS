using System;
using System.Collections.Generic;
using AMS.Model.dto;
using AMS.Model.ResponseModel;

namespace AMS.Service.Services.Interfaces
{
    public interface IParameterControlService
    {
        ResModel UpdateParameterControl(List<ParameterControlDto> parameterControlDtos, UserDto operationUser);
        List<ParameterControlDto> GetAllParameterControls();

    }
}
