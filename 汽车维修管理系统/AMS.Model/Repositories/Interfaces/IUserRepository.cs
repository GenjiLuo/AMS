﻿using AMS.Model.dto;

namespace AMS.Model.Repositories.Interfaces
{
    public interface IUserRepository
    {
        UserDto GetUserByLoginVM(UserDto userDto);
    }
}
