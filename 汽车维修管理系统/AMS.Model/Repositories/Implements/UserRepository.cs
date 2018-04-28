using System;
using System.Collections.Generic;
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
                    OrgName = i.Org.Name,
                    OrgHope = i.Org.OrgHope
                }).FirstOrDefault();
                return user;
            };

        }

        public List<UserDto> GetAllUser()
        {
            using (var db=new ModelContext())
            {
                var users = db.User.Select(i => new UserDto()
                {
                    Id=i.Id,
                    Name = i.Name,
                    State = i.State,
                    Account = i.Account,
                    OrgId = i.Org.Id,
                    OrgName = i.Org.Name
                }).ToList();
                return users;
            }
        }
    }
}
