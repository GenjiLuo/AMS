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
    public class CustomerInfoController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomerInfoController()
        {
            _customerService=new CustomerService();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Grid_CustomerDataSource()
        {
            return Json(_customerService.GetAllCustomer(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(CustomerDto customerDto)
        {
            var currentCustomer = Session["LogUser"] as UserDto;
            return Json(_customerService.AddCustomer(customerDto, currentCustomer));
        }
        public ActionResult Update(Guid customerId)
        {
            var customer = _customerService.GetOneCustomer(customerId);
            return View(customer);
        }
        [HttpPost]
        public ActionResult Update(CustomerDto customerDto)
        {
            var currentCustomer = Session["LogUser"] as UserDto;
            return Json(_customerService.UpdateCustomer(customerDto, currentCustomer));
        }
        [HttpPost]
        public ActionResult Delete(Guid customerId)
        {
            return Json(_customerService.DeleteCustomer(customerId));
        }
        public ActionResult Car()
        {
            return View();
        }
    }
}