using System;
using System.Collections.Generic;
using System.Linq;
using AMS.Model.dto;
using AMS.Model.poco;
using AMS.Model.Repositories.Interfaces;
using AMS.Model.ResponseModel;

namespace AMS.Model.Repositories.Implements
{
    public class QuickMenuRepository : IQuickMenuRepository
    {
        public List<UserQuickMenuDto> GetUserQuickMenu(UserDto userDto)
        {
            using (var db = new ModelContext())
            {
                var quickMenuDtos = new List<UserQuickMenuDto>();
                var userQuickMenuIds = db.QuickMenu.Where(i => i.UserId == userDto.Id).Select(i=>i.MenuId);
                var topLevelMenus = db.Menu.Where(i => i.ParentId == null);
                foreach (var topLevelMenu in topLevelMenus)
                {
                    var topQuickMenu=new UserQuickMenuDto()
                    {
                        Name = topLevelMenu.Name
                    };
                    foreach (var secondLevelMenu in topLevelMenu.SubMenu)
                    {
                        foreach (var thirdLevelMenu in secondLevelMenu.SubMenu)
                        {
                            var userQuickMenu=new UserQuickMenuDto()
                            {
                                MenuId = thirdLevelMenu.Id,
                                Name = thirdLevelMenu.Name,
                                Url = thirdLevelMenu.Url,
                                QuickMenuIcon = thirdLevelMenu.QuickMenuIcon
                            };
                            if (userQuickMenuIds.Contains(userQuickMenu.MenuId))
                            {
                                userQuickMenu.IsSelected = true;
                            }
                            topQuickMenu.AllThirdLevelMenu.Add(userQuickMenu);
                        }
                    }
                    quickMenuDtos.Add(topQuickMenu);
                }
                return quickMenuDtos;
            }
        }

        public ResModel AddUserQuickMenu(List<UserQuickMenuDto> userQuickMenuDtos,UserDto userDto)
        {
            using (var db=new ModelContext())
            {
                var quickMenus = userQuickMenuDtos.Select(i=>new QuickMenu()
                {
                    Id = Guid.NewGuid(),
                    UserId = userDto.Id,
                    MenuId = i.MenuId
                });
                try
                {
                    db.QuickMenu.AddRange(quickMenus);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    return new ResModel(){Msg = "保存失败",Success = false};
                }
                return new ResModel() { Msg = "保存成功", Success = true };
            }
        }
    }
}
