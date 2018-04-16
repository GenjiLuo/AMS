using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AMS.Model.Models;
using 汽车维修管理系统.Models;

namespace 汽车维修管理系统.Controllers
{
    public class AccountController : Controller
    {
        [AllowAnonymous]
        public ActionResult Index(string returnUrl)
        {
            if (!string.IsNullOrEmpty(returnUrl))
            {
                TempData["returnUrl"] = returnUrl;
            }
            return View("Login");
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginVM loginVM)
        {
            if (loginVM.UserName == "admin" && loginVM.UserPwd == "admin")
            {
                Session["LogUser"]=new User()
                {
                    UserName = "admin", 
                    Password = "admin"
                };
                return Json(new { success = true, message = "登录成功" });
            }
            else
            {
                return Json(new { success = false, message = "密码或者账号错误" });
            }
        }

        [AllowAnonymous]
        public ActionResult NoPermission()
        {
            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index","Home");
        }
    }
}