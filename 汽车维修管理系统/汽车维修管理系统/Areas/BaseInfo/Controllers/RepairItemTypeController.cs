using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AMS.Model.dto;
using AMS.Service.Services.Implements;
using AMS.Service.Services.Interfaces;

namespace 汽车维修管理系统.Areas.BaseInfo.Controllers
{
    public class RepairItemTypeController : Controller
    {
        private readonly IRepairItemTypeService _repairItemTypeService;

        public RepairItemTypeController()
        {
            _repairItemTypeService = new RepairItemTypeService();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Grid_RepairItemTypeDataSource()
        {
            return Json(_repairItemTypeService.GetAllRepairItemType(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(RepairItemTypeDto repairItemTypeDto)
        {
            var currentUser = Session["LogUser"] as UserDto;
            return Json(_repairItemTypeService.AddRepairItemType(repairItemTypeDto, currentUser));
        }
        public ActionResult Update(Guid repairItemTypeId)
        {
            var repairItemType = _repairItemTypeService.GetOneRepairItemType(repairItemTypeId);
            return View(repairItemType);
        }
        [HttpPost]
        public ActionResult Update(RepairItemTypeDto repairItemTypeDto)
        {
            var currentUser = Session["LogUser"] as UserDto;
            return Json(_repairItemTypeService.UpdateRepairItemType(repairItemTypeDto, currentUser));
        }
        [HttpPost]
        public ActionResult Delete(Guid repairItemTypeId)
        {
            var currentUser = Session["LogUser"] as UserDto;
            return Json(_repairItemTypeService.DeleteRepairItemType(repairItemTypeId));
        }
    }
}