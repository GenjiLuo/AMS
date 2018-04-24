using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace 汽车维修管理系统.Areas.PartDictionary.Controllers
{
    public class BaseInfoController : Controller
    {
        // GET: PartDictionary/BaseInfo
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Supplier()
        {
            return View();
        }
        public ActionResult PartDictionary()
        {
            return View();
        }
    }
}