using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMS.Model.dto;

namespace AMS.Service.Services.Interfaces
{
    public interface IUserService
    {
        List<UserDto> GetAllUser();
    }
}
