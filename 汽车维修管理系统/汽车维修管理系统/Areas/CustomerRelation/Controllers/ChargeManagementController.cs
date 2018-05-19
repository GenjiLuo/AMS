using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AMS.Model.dto;
using AMS.Service.Services.Implements;
using AMS.Service.Services.Interfaces;

namespace 汽车维修管理系统.Areas.CustomerRelation.Controllers
{
    public class ChargeManagementController : Controller
    {
        private readonly ICustomerService _customerService;
        public ChargeManagementController()
        {
            _customerService=new CustomerService();
        }

        public ActionResult Charge()
        {
            return View();
        }

        public ActionResult GetAllCustomerPrecharge_GridDataSource()
        {
            return Json(_customerService.GetAllCustomerPreCharges(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult UpdateCustomerPrecharge(CustomerDto customerDto)
        {
            var currentUser = Session["LogUser"] as UserDto;
            return Json(_customerService.UpdatePreCharge(customerDto, currentUser));
        }

        public ActionResult PreCharge_PartialView(Guid customerId)
        {
            var customer = _customerService.GetOneCustomer(customerId);
            return PartialView(customer);
        }
    }
}