using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AMS.Service.Services.Implements;
using AMS.Service.Services.Interfaces;

namespace 汽车维修管理系统.Areas.PartDictionary.Controllers
{
    public class PartsWarningController : Controller
    {
        private readonly IPartsService _partsService;
        public PartsWarningController()
        {
            _partsService=new PartsService();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AllPartsAlert_GridDataSource()
        {
            return Json(_partsService.GetAllPartAlerts(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult OverHighestPartsAlert_GridDataSource()
        {
            return Json(_partsService.GetOverHighestPartAlerts(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult LowerLowestPartsAlert_GridDataSource()
        {
            return Json(_partsService.GetLowerLowestPartAlerts(), JsonRequestBehavior.AllowGet);
        }

        
    }
}