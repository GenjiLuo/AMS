using AMS.Model.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMS.Service.Services.interfaces;
using AMS.Model.Repositories.Implements;
using AMS.Model.Repositories.Interfaces;

namespace AMS.Service.Services.implements
{
    public class LoginService:ILoginService
    {
        private readonly IUserRepository _userRepository;

        public LoginService()
        {
            _userRepository=new UserRepository();
        }
        public UserDto Login(UserDto userDto)
        {
            return _userRepository.GetUserByLoginVM(userDto);
        }
    }
}
