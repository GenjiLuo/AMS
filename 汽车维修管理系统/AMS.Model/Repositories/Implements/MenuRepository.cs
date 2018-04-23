using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMS.Model.dto;
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
                var firstLevelMenus = menus.Where(i => i.ParentId == null);
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
                    foreach (var secondLevelItem in firstLevelItem.SubMenu)
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
                        foreach (var thirdLevelItem in secondLevelItem.SubMenu)
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
    }
}
