using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMS.Model.dto;

namespace AMS.Model.Repositories.Interfaces
{
    public interface IMenuRepository
    {
        List<MenuDto> GetAllMenu();
    }
}
