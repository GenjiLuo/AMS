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
    public class PaymentTypeController : Controller
    {
        private readonly IPaymentTypeService _paymentTypeService;
        public PaymentTypeController()
        {
            _paymentTypeService=new PaymentTypeService();
        }

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult PaymentType_GridDataSource()
        {
            return Json(_paymentTypeService.GetAllPaymentType(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(PaymentTypeDto paymentTypeDto)
        {
            var currentUser = Session["LogUser"] as UserDto;
            return Json(_paymentTypeService.AddPaymentType(paymentTypeDto,currentUser));
        }
        public ActionResult Update(Guid paymentTypeId)
        {
            var paymentType = _paymentTypeService.GetOnePaymentType(paymentTypeId);
            return View(paymentType);
        }
        [HttpPost]
        public ActionResult Update(PaymentTypeDto paymentTypeDto)
        {
            var currentUser = Session["LogUser"] as UserDto;
            return Json(_paymentTypeService.UpdatePaymentType(paymentTypeDto, currentUser));
        }
        [HttpPost]
        public ActionResult Delete(Guid paymentTypeId)
        {
            return Json(_paymentTypeService.DeletePaymentType(paymentTypeId));
        }

        public ActionResult Query(string keyword)
        {
            return Json(_paymentTypeService.QueryPaymentType(keyword), JsonRequestBehavior.AllowGet);
        }
    }
}