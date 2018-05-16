using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMS.Model.dto;
using AMS.Model.ResponseModel;

namespace AMS.Service.Services.Interfaces
{
    public interface IUserService
    {
        List<UserDto> GetAllUser();
        UserDto GetOneUser(UserDto userDto);
        ResModel AddUser(UserDto userDto, UserDto operationUser);
        ResModel UpdateUser(UserDto userDto, UserDto operationUser);
        ResModel DeleteUser(UserDto userDto, UserDto operationUser);
        ResModel ActiveUser(UserDto userDto, UserDto operationUser);
        ResModel DisableUser(UserDto userDto, UserDto operationUser);
        List<UserDto> GetAllAdvisor();
    }
}
