using AMS.Model.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMS.Service.Services.interfaces;
using AMS.Model.Repositories.Implements;

namespace AMS.Service.Services.implements
{
    public class LoginService:ILoginService
    {
        private UserRepository _userRepository;

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
