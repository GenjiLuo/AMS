using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace 汽车维修管理系统.Areas.Report.Controllers
{
    public class BusinessReportController : Controller
    {
        // GET: Report/BusinessReport
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult PartDictionaryProfit()
        {
            return View();
        }
        public ActionResult BusinessSituation()
        {
            return View();
        }
    }
}