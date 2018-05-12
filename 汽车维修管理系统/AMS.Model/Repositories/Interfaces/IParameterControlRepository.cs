using System.Collections.Generic;
using AMS.Model.dto;
using AMS.Model.ResponseModel;

namespace AMS.Model.Repositories.Interfaces
{
    public interface IParameterControlRepository
    {
        ResModel UpdateParameterControl(List<ParameterControlDto> parameterControlDtos, UserDto operationUser);
        List<ParameterControlDto> GetAllParameterControls();
    }
}
