using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace 汽车维修管理系统.Areas.CustomerRelation.Controllers
{
    public class CustomerInfoController : Controller
    {
        // GET: CustomerRelation/CustomerInfo
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Customer()
        {
            return View();
        }
        public ActionResult Car()
        {
            return View();
        }
    }
}