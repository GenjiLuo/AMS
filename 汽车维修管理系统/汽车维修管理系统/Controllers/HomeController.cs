using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AMS.Service.Services.Implements;
using AMS.Service.Services.Interfaces;

namespace 汽车维修管理系统.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMenuService _menuService;

        public HomeController()
        {
            _menuService=new MenuService();
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

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}