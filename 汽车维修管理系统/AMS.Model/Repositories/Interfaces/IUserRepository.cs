using System;
using System.Collections.Generic;
using AMS.Model.dto;
using AMS.Model.ResponseModel;

namespace AMS.Model.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Tuple<ResModel, UserDto, List<MenuDto>> GetUserByLoginVM(UserDto userDto);
        List<UserDto> GetAllUser();
        UserDto GetOneUser(UserDto userDto);
        ResModel AddUser(UserDto userDto,UserDto operationUser);
        ResModel UpdateUser(UserDto userDto, UserDto operationUser);
        ResModel DeleteUser(UserDto userDto, UserDto operationUser);
        ResModel ActiveUser(UserDto userDto, UserDto operationUser);
        ResModel DisableUser(UserDto userDto, UserDto operationUser);
    }
}
