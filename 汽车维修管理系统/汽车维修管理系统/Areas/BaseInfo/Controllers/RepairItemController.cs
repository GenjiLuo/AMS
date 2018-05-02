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
    public class RepairItemController : Controller
    {
        private readonly IRepairItemService _repairItemService;
        private readonly IRepairItemTypeService _repairItemTypeService;

        public RepairItemController()
        {
            _repairItemService = new RepairItemService();
            _repairItemTypeService=new RepairItemTypeService();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Grid_RepairItemDataSource()
        {
            return Json(_repairItemService.GetAllRepairItem(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult DropDowList_RepairItemTypeDataSource()
        {
            return Json(_repairItemTypeService.GetAllRepairItemType(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(RepairItemDto repairItemDto)
        {
            var currentUser = Session["LogUser"] as UserDto;
            return Json(_repairItemService.AddRepairItem(repairItemDto, currentUser));
        }
        public ActionResult Update(Guid repairItemId)
        {
            var repairItem = _repairItemService.GetOneRepairItem(repairItemId);
            return View(repairItem);
        }
        [HttpPost]
        public ActionResult Update(RepairItemDto repairItemDto)
        {
            var currentUser = Session["LogUser"] as UserDto;
            return Json(_repairItemService.UpdateRepairItem(repairItemDto, currentUser));
        }
        [HttpPost]
        public ActionResult Delete(Guid repairItemId)
        {
            var currentUser = Session["LogUser"] as UserDto;
            return Json(_repairItemService.DeleteRepairItem(repairItemId));
        }
    }
}