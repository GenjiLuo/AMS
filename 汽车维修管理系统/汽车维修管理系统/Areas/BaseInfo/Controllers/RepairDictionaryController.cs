using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace 汽车维修管理系统.Areas.BaseInfo.Controllers
{
    public class RepairDictionaryController : Controller
    {
        // GET: BaseInfo/RepairDictionary
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult RepairItemType()
        {
            return View();
        }
        public ActionResult RepairItem()
        {
            return View();
        }
    }
}