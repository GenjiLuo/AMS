using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMS.Model.dto;
using AMS.Model.poco;
using AMS.Model.Repositories.Interfaces;

namespace AMS.Model.Repositories.Implements
{
    public class MenuRepository : IMenuRepository
    {
        public List<MenuDto> GetAllMenu()
        {
            var menuDtos = new List<MenuDto>();
            using (var db = new ModelContext())
            {
                var menus = db.Menu;
                var firstLevelMenus = menus.Where(i => i.ParentId == null).OrderBy(i=>i.OrderNum);
                foreach (var firstLevelItem in firstLevelMenus)
                {
                    var menuDto = new MenuDto()
                    {
                        Id = firstLevelItem.Id,
                        Name = firstLevelItem.Name,
                        Icon = firstLevelItem.Icon,
                        OrderNum = firstLevelItem.OrderNum,
                        Description = firstLevelItem.Description
                    };
                    var subMenus = firstLevelItem.SubMenu.OrderBy(i => i.OrderNum);
                    foreach (var secondLevelItem in subMenus)
                    {
                        var subMenuDto = new MenuDto()
                        {
                            Id = secondLevelItem.Id,
                            Name = secondLevelItem.Name,
                            Icon = secondLevelItem.Icon,
                            ParentId = secondLevelItem.ParentId,
                            OrderNum = secondLevelItem.OrderNum,
                            Description = secondLevelItem.Description
                        };
                        var subSubMenus = secondLevelItem.SubMenu.OrderBy(i => i.OrderNum);
                        foreach (var thirdLevelItem in subSubMenus)
                        {
                            var subSubMenuDto = new MenuDto()
                            {
                                Id = thirdLevelItem.Id,
                                Name = thirdLevelItem.Name,
                                Icon = thirdLevelItem.Icon,
                                ParentId = thirdLevelItem.ParentId,
                                Url = thirdLevelItem.Url,
                                OrderNum = thirdLevelItem.OrderNum,
                                Description = thirdLevelItem.Description
                            };
                            //三级菜单
                            subMenuDto.SubMenuDto.Add(subSubMenuDto);
                        }
                        //二级菜单
                        menuDto.SubMenuDto.Add(subMenuDto);
                    }
                    //一级菜单
                    menuDtos.Add(menuDto);
                }
            }
            return menuDtos;
        }

        public List<MenuDto> GetHierarchicalMenu(Guid userId)
        {
            var menuDtos = new List<MenuDto>();
            using (var db = new ModelContext())
            {
                var authorizedMenuIds = new List<Guid>();
                var userJobs = db.UserJob.Where(i => i.UserId == userId);
                foreach (var userJob in userJobs)
                {
                    var jobMenus = db.JobMenu.Where(i => i.JobId == userJob.JobId).Select(i => new JobMenuDto()
                    {
                        Id = i.Id,
                        JobId = i.JobId,
                        MenuId = i.MenuId,
                    });
                    foreach (var jobMenu in jobMenus)
                    {
                        var menuId = jobMenu.MenuId;
                        if (authorizedMenuIds.All(i => i!= menuId))
                        {
                            authorizedMenuIds.Add(menuId);
                        }
                    }
                }

                var menus = db.Menu.Where(i => authorizedMenuIds.Contains(i.Id)).ToList();
                var subParentMenus=new List<Menu>();
                foreach (var menu in menus)
                {
                    if (menu.ParentId.HasValue && menus.TrueForAll(i=>i.Id != menu.ParentId ))
                    {
                        var parentMenu = db.Menu.FirstOrDefault(i => i.Id == menu.ParentId);
                        subParentMenus.Add(parentMenu);
                    }
                }
                menus.AddRange(subParentMenus);
                var subParentMenuParentIds = subParentMenus.Where(i=>i.ParentId.HasValue && menus.TrueForAll(j=>j.Id !=i.ParentId)).Select(i => i.ParentId);
                var topParentMenus = db.Menu.Where(i => subParentMenuParentIds.Contains(i.Id));
                menus.AddRange(topParentMenus);
                
                var firstLevelMenus = menus.Where(i => i.ParentId == null).OrderBy(i => i.OrderNum);
                foreach (var firstLevelItem in firstLevelMenus)
                {
                    var menuDto = new MenuDto()
                    {
                        Id = firstLevelItem.Id,
                        Name = firstLevelItem.Name,
                        Icon = firstLevelItem.Icon,
                        OrderNum = firstLevelItem.OrderNum, 
                        Description = firstLevelItem.Description,
                        QuickMenuIcon = firstLevelItem.QuickMenuIcon
                    };
                    var subMenus = firstLevelItem.SubMenu.Where(i=> authorizedMenuIds.Contains(i.Id) || i.SubMenu.Any(j=>authorizedMenuIds.Contains(j.Id))).OrderBy(i => i.OrderNum);
                    foreach (var secondLevelItem in subMenus)
                    {
                        var subMenuDto = new MenuDto()
                        {
                            Id = secondLevelItem.Id,
                            Name = secondLevelItem.Name,
                            Icon = secondLevelItem.Icon,
                            ParentId = secondLevelItem.ParentId,
                            OrderNum = secondLevelItem.OrderNum,
                            Description = secondLevelItem.Description,
                            QuickMenuIcon = secondLevelItem.QuickMenuIcon
                        };
                        var subSubMenus = secondLevelItem.SubMenu.Where(i=>authorizedMenuIds.Contains(i.Id)).OrderBy(i => i.OrderNum);
                        foreach (var thirdLevelItem in subSubMenus)
                        {
                            var subSubMenuDto = new MenuDto()
                            {
                                Id = thirdLevelItem.Id,
                                Name = thirdLevelItem.Name,
                                Icon = thirdLevelItem.Icon,
                                ParentId = thirdLevelItem.ParentId,
                                Url = thirdLevelItem.Url,
                                OrderNum = thirdLevelItem.OrderNum,
                                Description = thirdLevelItem.Description,
                                QuickMenuIcon = thirdLevelItem.QuickMenuIcon
                            };
                            //三级菜单
                            subMenuDto.SubMenuDto.Add(subSubMenuDto);
                        }
                        //二级菜单
                        menuDto.SubMenuDto.Add(subMenuDto);
                    }
                    //一级菜单
                    menuDtos.Add(menuDto);
                }
            }
            return menuDtos;
        }

        public List<MenuDto> GetFlatMenu(Guid userId)
        {
            var menuDtos = new List<MenuDto>();
            using (var db = new ModelContext())
            {
                var authorizedMenuIds = new List<Guid>();
                var userJobs = db.UserJob.Where(i => i.UserId == userId);
                foreach (var userJob in userJobs)
                {
                    var jobMenus = db.JobMenu.Where(i => i.JobId == userJob.JobId).Select(i => new JobMenuDto()
                    {
                        Id = i.Id,
                        JobId = i.JobId,
                        MenuId = i.MenuId,
                    });
                    foreach (var jobMenu in jobMenus)
                    {
                        var menuId = jobMenu.MenuId;
                        if (authorizedMenuIds.All(i => i != menuId))
                        {
                            authorizedMenuIds.Add(menuId);
                        }
                    }
                }

                var menus = db.Menu.Where(i => authorizedMenuIds.Contains(i.Id)).ToList();
                var subParentMenus = new List<Menu>();
                foreach (var menu in menus)
                {
                    if (menu.ParentId.HasValue && menus.TrueForAll(i => i.Id != menu.ParentId))
                    {
                        var parentMenu = db.Menu.FirstOrDefault(i => i.Id == menu.ParentId);
                        subParentMenus.Add(parentMenu);
                    }
                }
                menus.AddRange(subParentMenus);
                var subParentMenuParentIds = subParentMenus.Where(i => i.ParentId.HasValue && menus.TrueForAll(j => j.Id != i.ParentId)).Select(i => i.ParentId);
                var topParentMenus = db.Menu.Where(i => subParentMenuParentIds.Contains(i.Id));
                menus.AddRange(topParentMenus);

                menuDtos = menus.Select(i => new MenuDto()
                {
                    Id = i.Id,
                    Name = i.Name,
                    Icon = i.Icon,
                    ParentId = i.ParentId,
                    Url = i.Url,
                    OrderNum = i.OrderNum,
                    Description = i.Description
                }).ToList();
            }
            return menuDtos;
        }
    }
}
