using System;
using System.Collections.Generic;
using AMS.Model.dto;
using AMS.Model.Repositories.Implements;
using AMS.Model.Repositories.Interfaces;
using AMS.Model.ResponseModel;
using AMS.Service.Services.Interfaces;

namespace AMS.Service.Services.Implements
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService()
        {
            _userRepository=new UserRepository();
        }
        public List<UserDto> GetAllUser()
        {
            return _userRepository.GetAllUser();
        }

        public UserDto GetOneUser(UserDto userDto)
        {
            return _userRepository.GetOneUser(userDto);
        }

        public ResModel AddUser(UserDto userDto, UserDto operationUser)
        {
            return _userRepository.AddUser(userDto, operationUser);
        }

        public ResModel UpdateUser(UserDto userDto, UserDto operationUser)
        {
            return _userRepository.UpdateUser(userDto, operationUser);
        }

        public ResModel DeleteUser(UserDto userDto, UserDto operationUser)
        {
            return _userRepository.DeleteUser(userDto, operationUser);
        }

        public ResModel ActiveUser(UserDto userDto, UserDto operationUser)
        {
            return _userRepository.ActiveUser(userDto, operationUser);
        }

        public ResModel DisableUser(UserDto userDto, UserDto operationUser)
        {
            return _userRepository.DisableUser(userDto, operationUser);
        }

        public List<UserDto> GetAllAdvisor()
        {
            return _userRepository.GetAllUser();
        }
    }
}
