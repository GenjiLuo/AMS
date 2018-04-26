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
        #region 用户所有快捷菜单
        public List<UserQuickMenuDto> GetUserQuickMenu(UserDto userDto)
        {
            using (var db = new ModelContext())
            {
                var quickMenuDtos = new List<UserQuickMenuDto>();
                var userQuickMenuIds = db.QuickMenu.Where(i => i.UserId == userDto.Id).Select(i => i.MenuId);
                var topLevelMenus = db.Menu.Where(i => i.ParentId == null);
                foreach (var topLevelMenu in topLevelMenus)
                {
                    var topQuickMenu = new UserQuickMenuDto()
                    {
                        Name = topLevelMenu.Name
                    };
                    foreach (var secondLevelMenu in topLevelMenu.SubMenu)
                    {
                        foreach (var thirdLevelMenu in secondLevelMenu.SubMenu)
                        {
                            var userQuickMenu = new UserQuickMenuDto()
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

        #endregion

        #region 新增用户快捷菜单

        public ResModel AddUserQuickMenu(List<UserQuickMenuDto> userQuickMenuDtos, UserDto userDto)
        {
            using (var db = new ModelContext())
            {
                var quickMenus = userQuickMenuDtos.Select(i => new QuickMenu()
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
                    return new ResModel() { Msg = "保存失败", Success = false };
                }
                return new ResModel() { Msg = "保存成功", Success = true };
            }
        }

        #endregion

        #region 删除用户快捷菜单

        public ResModel DeleteUserQuickMenu(UserQuickMenuDto userQuickMenu)
        {
            using (var db = new ModelContext())
            {
                var quickMenu = db.QuickMenu.FirstOrDefault(i =>
                    i.MenuId == userQuickMenu.MenuId && i.UserId == userQuickMenu.UserId);
                if (quickMenu == null)
                {
                    return new ResModel(){Msg="删除失败，未找到该快捷菜单",Success=false};
                }
                try
                {
                    db.QuickMenu.Remove(quickMenu);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    return new ResModel() { Msg = "删除失败", Success = false };
                }
                return new ResModel() { Msg = "删除成功", Success = true };
            }
        }

        #endregion
    }
}
