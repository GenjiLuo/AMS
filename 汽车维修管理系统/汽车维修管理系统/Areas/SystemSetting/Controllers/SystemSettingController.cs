using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace 汽车维修管理系统.Areas.SystemSetting.Controllers
{
    public class SystemSettingController : Controller
    {
        // GET: SystemSetting/SystemSetting
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ParameterControll()
        {
            return View();
        }
        public ActionResult OrderNoSetting()
        {
            return View();
        }
    }
}