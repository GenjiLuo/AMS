using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMS.Model.dto;

namespace AMS.Service.Services.Interfaces
{
    public interface IMenuService
    {
        List<MenuDto> GetAllMenu();
        List<MenuDto> GenerateMenuByUserId(Guid userId);
    }
}
