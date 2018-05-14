using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AMS.Model.dto;
using AMS.Model.Enum;
using AMS.Service.Services.Implements;
using AMS.Service.Services.Interfaces;

namespace 汽车维修管理系统.Areas.PartDictionary.Controllers
{
    public class PartsBuyController : Controller
    {
        private readonly IPartsBuyService _partsBuyService;
        private readonly IPartsDictionaryService _partsDictionaryService;
        private readonly IWarehouseService _warehouseService;
        private readonly ISupplierService _supplierService;

        public PartsBuyController()
        {
            _partsBuyService=new PartsBuyService();
            _partsDictionaryService=new PartsDictionaryService();
            _warehouseService=new WarehouseService();
            _supplierService=new SupplierService();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PartsBuy_GridDataSource()
        {
            return Json(_partsBuyService.GetAllPartsBuy(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Add()
        {
            return View();
        }

        public ActionResult AddParts_PartialView()
        {
            return PartialView("AddParts_PartialView");
        }
        public ActionResult AdvancedAddParts_PartialView()
        {
            return PartialView("AdvancedAddParts_PartialView");
        }

        public ActionResult Supplier_ComboBoxDataSource(string keyword)
        {
            return Json(_supplierService.QuerySupplier(keyword), JsonRequestBehavior.AllowGet);
        }
        public ActionResult Warehouse_DropDownListDataSource()
        {
            return Json(_warehouseService.GetAllWarehouse(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult PartsDictionary_ComboBoxDataSource(string keyword)
        {
            return Json(_partsDictionaryService.QueryPartsDictionary(keyword), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Add(PartsBuyDto partsBuyDto)
        {
            var currentUser = Session["LogUser"] as UserDto;
            return Json(_partsBuyService.AddPartsBuy(partsBuyDto,currentUser));
        }
        public ActionResult Update(Guid partsBuyId)
        {
            var partsBuy = _partsBuyService.GetOnePartsBuy(partsBuyId);
            return View(partsBuy);
        }
        [HttpPost]
        public ActionResult Update(PartsBuyDto partsBuyDto)
        {
            var currentUser = Session["LogUser"] as UserDto;
            return Json(_partsBuyService.UpdatePartsBuy(partsBuyDto, currentUser));
        }
        [HttpPost]
        public ActionResult Delete(Guid partsBuyId)
        {
            return Json(_partsBuyService.DeletePartsBuy(partsBuyId));
        }

        public ActionResult Query(string keyword)
        {
            return Json(_partsBuyService.QueryPartsBuy(keyword), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Check(Guid partsBuyId)
        {
            var currentUser = Session["LogUser"] as UserDto;
            return Json(_partsBuyService.CheckPartsBuy(partsBuyId, currentUser));
        }
        [HttpPost]
        public ActionResult UnCheck(Guid partsBuyId)
        {
            return Json(_partsBuyService.UnCheckPartsBuy(partsBuyId));
        }
        [HttpPost]
        public ActionResult Pay(Guid partsBuyId,decimal money)
        {
            return Json(_partsBuyService.Pay(partsBuyId,money));
        }
    }
}