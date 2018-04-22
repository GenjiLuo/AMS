using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMS.Model.dto;
using AMS.Model.Repositories.Implements;
using AMS.Model.Repositories.Interfaces;
using AMS.Service.Services.Interfaces;

namespace AMS.Service.Services.Implements
{
    public class MenuService:IMenuService
    {
        private readonly IMenuRepository _menuRepository;

        public MenuService()
        {
            _menuRepository = new MenuRepository();
        }
        public List<MenuDto> GetAllMenu()
        {
            return _menuRepository.GetAllMenu();
        }
    }
}
