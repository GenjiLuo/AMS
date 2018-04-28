using System;
using System.Collections.Generic;
using AMS.Model.dto;
using AMS.Model.Repositories.Implements;
using AMS.Model.Repositories.Interfaces;
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
    }
}
