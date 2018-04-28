using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AMS.Service.Services.Implements;
using AMS.Service.Services.Interfaces;

namespace 汽车维修管理系统.Areas.BaseInfo.Controllers
{
    public class EmployeeManagementController : Controller
    {
        private readonly IUserService _userService;

        public EmployeeManagementController()
        {
            _userService=new UserService();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Grid_UserDataSource()
        {
            return Json(_userService.GetAllUser(), JsonRequestBehavior.AllowGet);
        }
    }
}