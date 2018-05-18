using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AMS.Service.Services.Implements;
using AMS.Service.Services.Interfaces;

namespace 汽车维修管理系统.Areas.AutoRepair.Controllers
{
    public class RepairHistoryController : Controller
    {
        private readonly IServiceRepairHistoryService _serviceRepairHistoryService;

        public RepairHistoryController()
        {
            _serviceRepairHistoryService=new ServiceRepairHistoryService();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ServiceRepairHistory_GridDataSource()
        {
            return Json(_serviceRepairHistoryService.GetAllHistory(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult A_PartialView()
        {
            return PartialView("a");
        }
        public ActionResult B_PartialView()
        {
            return PartialView("B");
        }
    }
}