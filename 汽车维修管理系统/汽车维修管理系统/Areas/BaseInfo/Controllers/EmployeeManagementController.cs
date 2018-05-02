using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AMS.Model.dto;
using AMS.Model.ResponseModel;
using AMS.Service.Services.Implements;
using AMS.Service.Services.Interfaces;

namespace 汽车维修管理系统.Areas.BaseInfo.Controllers
{
    public class EmployeeManagementController : Controller
    {
        private readonly IUserService _userService;
        private readonly IOrgService _orgService;

        public EmployeeManagementController()
        {
            _userService = new UserService();
            _orgService = new OrgService();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Grid_UserDataSource()
        {
            return Json(_userService.GetAllUser(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult DropDownList_OrgDataSource()
        {
            return Json(_orgService.GetOrganization(),JsonRequestBehavior.AllowGet);
        }

        public ActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddUser(UserDto userDto)
        {
            var currentUser = Session["LogUser"] as UserDto;
            return Json(_userService.AddUser(userDto,currentUser));
        }
        public ActionResult UpdateUserView(UserDto userDto)
        {
            var user = _userService.GetOneUser(userDto);
            return View(user);
        }
        [HttpPost]
        public ActionResult UpdateUser(UserDto userDto)
        {
            var currentUser = Session["LogUser"] as UserDto;
            return Json(_userService.UpdateUser(userDto, currentUser));
        }
        [HttpPost]
        public ActionResult DeleteUser(UserDto userDto)
        {
            var currentUser = Session["LogUser"] as UserDto;
            return Json(_userService.DeleteUser(userDto, currentUser));
        }
        [HttpPost]
        public ActionResult DisableUser(UserDto userDto)
        {
            var currentUser = Session["LogUser"] as UserDto;
            return Json(_userService.DisableUser(userDto, currentUser));
        }
        [HttpPost]
        public ActionResult ActiveUser(UserDto userDto)
        {
            var currentUser = Session["LogUser"] as UserDto;
            return Json(_userService.ActiveUser(userDto, currentUser));
        }
    }
}