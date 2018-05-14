using System.Collections.Generic;
using AMS.Model.dto;

namespace AMS.Service.Services.Interfaces
{
    public interface IPartsService
    {
        List<PartsDto> GetAllParts();
    }
}
