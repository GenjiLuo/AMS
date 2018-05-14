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
    public class PartsReturnController : Controller
    {
        private readonly IPartsReturnService _partsReturnService;
        private readonly ISupplierService _supplierService;
        private readonly IWarehouseService _warehouseService;
        private readonly IPartsService _partsService;
        public PartsReturnController()
        {
            _partsReturnService=new PartsReturnService();
            _supplierService=new SupplierService();
            _warehouseService=new WarehouseService();
            _partsService=new PartsService();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PartsReturn_GridDataSource()
        {
            return Json(_partsReturnService.GetAllPartsReturn(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult Add()
        {
            return View();
        }

        public ActionResult Supplier_ComboBoxDataSource(string keyword)
        {
            return Json(_supplierService.QuerySupplier(keyword), JsonRequestBehavior.AllowGet);
        }
        public ActionResult Warehouse_DropDownListDataSource()
        {
            return Json(_warehouseService.GetAllWarehouse(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult WarehousedParts_GridDataSource()
        {
            return Json(_partsService.GetAllParts(), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Add(PartsReturnDto partsReturnDto)
        {
            var currentUser = Session["LogUser"] as UserDto;
            return Json(_partsReturnService.AddPartsReturn(partsReturnDto,currentUser));
        }
        public ActionResult Update(Guid partsReturnId)
        {
            var partsReturn = _partsReturnService.GetOnePartsReturn(partsReturnId);
            return View(partsReturn);
        }
        [HttpPost]
        public ActionResult Update(PartsReturnDto partsReturnDto)
        {
            var currentUser = Session["LogUser"] as UserDto;
            return Json(_partsReturnService.UpdatePartsReturn(partsReturnDto, currentUser));
        }
        [HttpPost]
        public ActionResult Delete(Guid partsReturnId)
        {
            return Json(_partsReturnService.DeletePartsReturn(partsReturnId));
        }
        [HttpPost]
        public ActionResult Query(string keyword)
        {
            return Json(_partsReturnService.QueryPartsReturn(keyword));
        }

        public ActionResult Check(Guid partsReturnId)
        {
            var currentUser = Session["LogUser"] as UserDto;
            return Json(_partsReturnService.Check(partsReturnId, currentUser));
        }
    }
}