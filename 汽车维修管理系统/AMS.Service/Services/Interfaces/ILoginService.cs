using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMS.Model.dto;
using AMS.Model.ResponseModel;

namespace AMS.Service.Services.interfaces
{
    public interface ILoginService
    {
        Tuple<ResModel, UserDto, List<MenuDto>> Login(UserDto userDto);
    }
}
