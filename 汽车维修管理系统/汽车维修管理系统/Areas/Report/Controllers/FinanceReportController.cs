using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace 汽车维修管理系统.Areas.Report.Controllers
{
    public class FinanceReportController : Controller
    {
        // GET: Report/FinanceReport
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DailyRepairReport()
        {
            return View();
        }
        public ActionResult WorkHourPay()
        {
            return View();
        }
    }
}