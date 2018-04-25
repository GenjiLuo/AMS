using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AMS.Model.dto;
using AMS.Model.ResponseModel;
using AMS.Service.Services.Implements;
using AMS.Service.Services.Interfaces;
using 汽车维修管理系统.Models;

namespace 汽车维修管理系统.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMenuService _menuService;
        private readonly IQuickMenuService _quickMenuService;

        public HomeController()
        {
            _menuService=new MenuService();
            _quickMenuService=new QuickMenuService();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAllMenu()
        {
            return Json(_menuService.GetAllMenu().OrderBy(i=>i.OrderNum),JsonRequestBehavior.AllowGet);
        }

        public ActionResult Help()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }
        public ActionResult GetAllMenuAndUserQuickMenu()
        {
            return Json(_menuService.GetAllMenu().OrderBy(i => i.OrderNum), JsonRequestBehavior.AllowGet);
        }

        //暂时没有使用
        public ActionResult QuickMenuPartialView()
        {
            return PartialView("QuickMenu_PartialView");
        }

        public ActionResult GetAllQuickMenu()
        {
            var currentUser = Session["LogUser"] as UserDto;
            return Json(_quickMenuService.GetUserQuickMenu(currentUser),JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AddUserQuickMenu(List<UserQuickMenuDto> userQuickMenuDtos)
        {
            var currentUser = Session["LogUser"] as UserDto;
            return Json(_quickMenuService.AddUserQuickMenu(userQuickMenuDtos, currentUser));
        }

        public ActionResult DeleteUserQuickMenu(string menuId)
        {
            return Json(new ResModel(){Msg = "删除成功",Success = true});
        }
    }
}