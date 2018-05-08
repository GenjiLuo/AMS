using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AMS.Model.dto;
using AMS.Service.Services.Implements;
using AMS.Service.Services.Interfaces;

namespace 汽车维修管理系统.Areas.PartDictionary.Controllers
{
    public class WarehouseController : Controller
    {
        private readonly IWarehouseService _warehouseService;

        public WarehouseController()
        {
            _warehouseService=new WarehouseService();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Warehouse_GridDataSource()
        {
            return Json(_warehouseService.GetAllWarehouse(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(WarehouseDto warehouseDto)
        {
            var currentUser = Session["LogUser"] as UserDto;
            return Json(_warehouseService.AddWarehouse(warehouseDto,currentUser));
        }
        public ActionResult Update(Guid warehouId)
        {
            var warehouse = _warehouseService.GetOneWarehouse(warehouId);
            return View(warehouse);
        }
        [HttpPost]
        public ActionResult Update(WarehouseDto warehouseDto)
        {
            var currentUser = Session["LogUser"] as UserDto;
            return Json(_warehouseService.UpdateWarehouse(warehouseDto, currentUser));
        }
        [HttpPost]
        public ActionResult Delete(Guid warehouId)
        {
            return Json(_warehouseService.DeleteWarehouse(warehouId));
        }
        public ActionResult Query(string keyword)
        {
            return Json(_warehouseService.QueryWarehouse(keyword),JsonRequestBehavior.AllowGet);
        }
    }
}