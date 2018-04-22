using AMS.Service.Services.implements;
using System.Web.Mvc;
using AMS.Model.dto;
using AMS.Model.ResponseModel;
using AMS.Service.Services.interfaces;
using 汽车维修管理系统.Models;

namespace 汽车维修管理系统.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILoginService _loginService;
        public AccountController()
        {
            _loginService = new LoginService();
        }
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
             if (ModelState.IsValid)
            {
                var user = _loginService.Login(new UserDto()
                {
                    Account = loginVM.Account,
                    Password = loginVM.Password
                });

                if (user != null)
                {
                    Session["LogUser"] = user;
                    return Json(new ResponseModel { Success = true, Msg = "登录成功" });
                }

                return Json(new ResponseModel { Success = false, Msg = "账号或密码错误" });
            }

            return Json(new ResponseModel { Success = false, Msg = "账号或密码错误" });
        }

        [AllowAnonymous]
        public ActionResult NoPermission()
        {
            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}