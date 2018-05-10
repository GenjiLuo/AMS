using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace 汽车维修管理系统.Areas.Report.Controllers
{
    public class WarehouseReportController : Controller
    {
        // GET: Report/WarehouseReport
        public ActionResult PartsInventoryCheckSummary()
        {
            return View();
        }
    }
}