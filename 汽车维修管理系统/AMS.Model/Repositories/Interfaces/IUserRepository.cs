using AMS.Model.dto;

namespace AMS.Model.Repositories.Interfaces
{
    interface IUserRepository
    {
        UserDto GetUserByLoginVM(UserDto userDto);
    }
}
