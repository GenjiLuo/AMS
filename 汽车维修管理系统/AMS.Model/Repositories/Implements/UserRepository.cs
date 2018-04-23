using System;
using System.Data.Entity;
using System.Linq;
using AMS.Model.dto;
using AMS.Model.Repositories.Interfaces;

namespace AMS.Model.Repositories.Implements
{
    public class UserRepository : IUserRepository
    {
        public UserDto GetUserByLoginVM(UserDto userDto)
        {
            using (var db = new ModelContext())
            {
                var user = db.User.Where(i => i.Account == userDto.Account && i.Password == userDto.Password).Select(i => new UserDto
                {
                    Id = i.Id,
                    Name = i.Name,
                    Account = i.Account,
                    Password = i.Password,
                    OrgId = i.Org.Id,
                    OrgName = i.Org.Name
                }).FirstOrDefault();
                return user;
            };

        }
    }
}
