using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace 汽车维修管理系统.Areas.AutoRepair.Controllers
{
    public class BookingManagementController : Controller
    {
        // GET: AutoRepair/BookingManagement
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }
    }
}