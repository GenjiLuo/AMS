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
    public class SupplierController : Controller
    {
        private readonly ISupplierService _supplierService;
        public SupplierController()
        {
            _supplierService=new SupplierService();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Supplier_GridDataSource()
        {
            return Json(_supplierService.GetAllSupplier(),JsonRequestBehavior.AllowGet);
        }

        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(SupplierDto supplierDto)
        {
            var currentUser = Session["LogUser"] as UserDto;
            return Json(_supplierService.AddSupplier(supplierDto,currentUser));
        }
        public ActionResult Update(Guid supplierId)
        {
            var supplier = _supplierService.GetOneSupplier(supplierId);
            return View(supplier);
        }
        [HttpPost]
        public ActionResult Update(SupplierDto supplierDto)
        {
            var currentUser = Session["LogUser"] as UserDto;
            return Json(_supplierService.UpdateSupplier(supplierDto, currentUser));
        }

        [HttpPost]
        public ActionResult Delete(Guid supplierId)
        {
            return Json(_supplierService.DeleteSupplier(supplierId));
        }
        public ActionResult Query(string keyword)
        {
            return Json(_supplierService.QuerySupplier(keyword));
        }

    }
}