using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace 汽车维修管理系统.Areas.AutoRepair.Controllers
{
    public class RepairManagementController : Controller
    {
        // GET: AutoRepair/RepairManagement
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult WashCarCreate()
        {
            return View();
        }
        public ActionResult RepairCreate()
        {
            return View();
        }
    }
}