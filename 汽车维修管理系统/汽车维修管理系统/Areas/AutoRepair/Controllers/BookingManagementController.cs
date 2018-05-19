using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AMS.Model.dto;
using AMS.Service.Services.Implements;
using AMS.Service.Services.Interfaces;

namespace 汽车维修管理系统.Areas.AutoRepair.Controllers
{
    public class BookingManagementController : Controller
    {
        private readonly IServiceBookingService _serviceBookingService;
        private readonly ICarService _carService;
        private readonly IUserService _userService;
        private readonly IRepairTypeService _repairTypeService;
        private readonly IRepairItemService _repairItemService;
        private readonly IServiceAccountTypeService _serviceAccountTypeService;
        private readonly IPartsService _partsService;
        private readonly ICustomerService _customerService;
        public BookingManagementController()
        {
            _serviceBookingService=new ServiceBookingService();
            _carService=new CarService();
            _userService=new UserService();
            _repairTypeService=new RepairTypeService();
            _repairItemService=new RepairItemService();
            _serviceAccountTypeService=new ServiceAccountTypeService();
            _partsService=new PartsService();
            _customerService=new CustomerService();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ServiceBooking_GridDataSource()
        {
            return Json(_serviceBookingService.GetAllServiceBooking(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Car_ComboBoxDataSource(string keyword)
        {
            return Json(_carService.QueryCar(keyword), JsonRequestBehavior.AllowGet);
        }

        public ActionResult RepairAdvisor_DropDownListDataSource()
        {
            return Json(_userService.GetAllAdvisor(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult RepairType_DropDownListDataSource()
        {
            return Json(_repairTypeService.GetAllRepairType(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Parts_GridDataSource()
        {
            return Json(_partsService.GetAllParts(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult AddRepairItem_PartialView()
        {
            return PartialView("AddRepairItem_PartialView");
        }
        public ActionResult AddEstimateParts_PartialView()
        {
            return PartialView("AddEstimateParts_PartialView");
        }

        public ActionResult RepairItem_DropDownListDataSource()
        {
            return Json(_repairItemService.GetAllRepairItem(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult ServiceAccountType_DropDownListDataSource()
        {
            return Json(_serviceAccountTypeService.GetAllServiceAccountType(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetCustomerInfo(Guid customerId)
        {
            return Json(_customerService.GetOneCustomer(customerId), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Create(ServiceBookingDto serviceBookingDto)
        {
            var currrentUser = Session["LogUser"] as UserDto;
            return Json(_serviceBookingService.AddServiceBooking(serviceBookingDto,currrentUser));
        }
        public ActionResult Update(Guid serviceBookingId)
        {
            var serviceBooking = _serviceBookingService.GetOneServiceBooking(serviceBookingId);
            return View(serviceBooking);
        }
        public ActionResult ViewDetail(Guid serviceBookingId)
        {
            var serviceBooking = _serviceBookingService.GetOneServiceBooking(serviceBookingId);
            return View(serviceBooking);
        }
        [HttpPost]
        public ActionResult Update(ServiceBookingDto serviceBookingDto)
        {
            var currrentUser = Session["LogUser"] as UserDto;
            return Json(_serviceBookingService.UpdateServiceBooking(serviceBookingDto, currrentUser));
        }
        [HttpPost]
        public ActionResult TurnToRepair(Guid serviceBookingId)
        {
            var currrentUser = Session["LogUser"] as UserDto;
            return Json(_serviceBookingService.TurnToRepair(serviceBookingId));
        }
        [HttpPost]
        public ActionResult TurnToInvalid(Guid serviceBookingId)
        {
            var currrentUser = Session["LogUser"] as UserDto;
            return Json(_serviceBookingService.TurnToInvalid(serviceBookingId));
        }
        [HttpPost]
        public ActionResult Query(string keyword)
        {
            return Json(_serviceBookingService.QueryServiceBooking(keyword));
        }
    }
}