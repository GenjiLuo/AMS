using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace 汽车维修管理系统.Areas.PartDictionary.Controllers
{
    public class RepairItemController : Controller
    {
        // GET: PartDictionary/RepairItem
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult UseOrReturn()
        {
            return View();
        }
    }
}