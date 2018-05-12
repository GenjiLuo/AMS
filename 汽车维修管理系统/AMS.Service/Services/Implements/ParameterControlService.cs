using System.Collections.Generic;
using AMS.Model.dto;
using AMS.Model.Repositories.Implements;
using AMS.Model.Repositories.Interfaces;
using AMS.Model.ResponseModel;
using AMS.Service.Services.Interfaces;

namespace AMS.Service.Services.Implements
{
    public class ParameterControlService : IParameterControlService
    {
        private readonly IParameterControlRepository _parameterControlRepository;
        public ParameterControlService()
        {
            _parameterControlRepository=new ParameterControlRepository();
        }

        public ResModel UpdateParameterControl(List<ParameterControlDto> parameterControlDtos, UserDto operationUser)
        {
            return _parameterControlRepository.UpdateParameterControl(parameterControlDtos,operationUser);
        }

        public List<ParameterControlDto> GetAllParameterControls()
        {
            return _parameterControlRepository.GetAllParameterControls();
        }
    }
}
