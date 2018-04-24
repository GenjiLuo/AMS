using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace 汽车维修管理系统.Areas.SystemSetting.Controllers
{
    public class SystemLogController : Controller
    {
        // GET: SystemSetting/SystemLog
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult OperationLog()
        {
            return View();
        }
        public ActionResult DataLog()
        {
            return View();
        }
    }
}