using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using 汽车维修管理系统.Models;

namespace 汽车维修管理系统.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Index()
        {
            return View("Login");
        }
        [HttpPost]
        public ActionResult Login(LoginVM loginVM)
        {
            if (loginVM.UserName == "admin" && loginVM.UserPwd == "admin")
            {
                Session["LogUser"]=new LoginVM()
                {
                    UserName = "admin",
                    UserPwd = "admin"
                };
                return Json(new { success = true, message = "登录成功" });
            }
            else
            {
                return Json(new { success = false, message = "密码或者账号错误" });
            }
        }
    }
}