using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace 汽车维修管理系统.Areas.Report.Controllers
{
    public class RepairReportController : Controller
    {
        // GET: Report/RepairReport
        public ActionResult PartsSummary()
        {
            return View();
        }
    }
}