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
    public class RepairTypeController : Controller
    {
        private readonly IRepairTypeService _repairTypeService;

        public RepairTypeController()
        {
            _repairTypeService=new RepairTypeService();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Grid_RepairTypeDataSource()
        {
            return Json(_repairTypeService.GetAllRepairType(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(RepairTypeDto repairTypeDto)
        {
            var currentUser = Session["LogUser"] as UserDto;
            return Json(_repairTypeService.AddRepairType(repairTypeDto,currentUser));
        }
        public ActionResult Update(Guid repairTypeId)
        {
            var repairType = _repairTypeService.GetOneRepairType(repairTypeId);
            return View(repairType);
        }
        [HttpPost]
        public ActionResult Update(RepairTypeDto repairTypeDto)
        {
            var currentUser = Session["LogUser"] as UserDto;
            return Json(_repairTypeService.UpdateRepairType(repairTypeDto, currentUser));
        }
        [HttpPost]
        public ActionResult Delete(Guid repairTypeId)
        {
            var currentUser = Session["LogUser"] as UserDto;
            return Json(_repairTypeService.DeleteRepairType(repairTypeId));
        }

    }
} 