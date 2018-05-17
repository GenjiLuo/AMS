using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AMS.Model.dto;
using AMS.Model.Enum;
using AMS.Service.Services.Implements;
using AMS.Service.Services.Interfaces;

namespace 汽车维修管理系统.Areas.AutoRepair.Controllers
{
    public class RepairManagementController : Controller
    {
        private readonly IServiceRepairService _serviceRepairService;
        private readonly ICarService _carService;
        private readonly IServiceBookingService _serviceBookingService;
        private readonly ICustomerService _customerService;
        private readonly IUserService _userService;
        private readonly IRepairTypeService _repairTypeService;
        private readonly IServiceAccountTypeService _serviceAccountTypeService;
        private readonly IPartsService _partsService;
        private readonly IRepairItemService _repairItemService;
        public RepairManagementController()
        {
            _serviceRepairService=new ServiceRepairService();
            _carService=new CarService();
            _serviceBookingService=new ServiceBookingService();
            _customerService=new CustomerService();
            _userService = new UserService();
            _repairTypeService=new RepairTypeService();
            _serviceAccountTypeService=new ServiceAccountTypeService();
            _partsService=new PartsService();
            _repairItemService=new RepairItemService();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ServiceRepair_GridDataSource()
        {
            return Json(_serviceRepairService.GetAllServiceRepair(), JsonRequestBehavior.AllowGet);
        }
        
        public ActionResult History()
        {
            return View();
        }
        public ActionResult WashCarCreate()
        {
            return View();
        }
        public ActionResult RepairCreate()
        {
            return View();
        }

        public ActionResult Car_ComboBoxDataSource(string keyword)
        {
            if (string.IsNullOrEmpty(keyword))
            {
                return Json(_carService.GetAllCar(), JsonRequestBehavior.AllowGet);
            }

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
        public ActionResult MainOperator_DropDownListDataSource()
        {
            return Json(_userService.GetAllAdvisor(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult ServiceBooking_DropDownListDataSource(Guid carId)
        {
            return Json(_serviceBookingService.GetServiceBookingByCarId(carId), JsonRequestBehavior.AllowGet);
        }

        public ActionResult RepairHistory_GridDataSource(Guid carId)
        {
            return Json(_serviceRepairService.GetHistoryRepairByCarId(carId), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult GetCustomerInfo(Guid customerId)
        {
            return Json(_customerService.GetOneCustomer(customerId));
        }
        [HttpPost]
        public ActionResult AddServiceRepair(ServiceRepairDto serviceRepair)
        {
            var currentUser = Session["LogUser"] as UserDto;
            return Json(_serviceRepairService.AddServiceRepair(serviceRepair, currentUser));
        }
        public ActionResult AddRepairItem_PartialView()
        {
            return PartialView("AddRepairItem_PartialView");
        }
        public ActionResult AddRepairParts_PartialView()
        {
            return PartialView("AddRepairParts_PartialView");
        }
        public ActionResult ServiceAccountType_DropDownListDataSource()
        {
            return Json(_serviceAccountTypeService.GetAllServiceAccountType(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult RepairItem_DropDownListDataSource()
        {
            return Json(_repairItemService.GetAllRepairItem(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult Parts_GridDataSource()
        {
            return Json(_partsService.GetAllParts(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult Create()
        {
            return View("RepairCreate");
        }
        public ActionResult Edit(Guid serviceRepairId)
        {
            var serviceRepair = _serviceRepairService.GetOneServiceRepair(serviceRepairId);
            if (serviceRepair.ServiceType == ServiceType.洗车)
            {
                return View("EditWashCar",serviceRepair);
            }
            return View("EditCarRepair",serviceRepair);
        }

        public ActionResult RepairAccount(Guid serviceRepairId)
        {
            var serviceRepair = _serviceRepairService.GetOneServiceRepair(serviceRepairId);
            return View("RepairAccount", serviceRepair);
        }

        public ActionResult RepairCash(Guid serviceRepairId)
        {
            var serviceRepair = _serviceRepairService.GetOneServiceRepair(serviceRepairId);
            return View("RepairCash", serviceRepair);
        }
        [HttpPost]
        public ActionResult Update(ServiceRepairDto serviceRepair)
        {
            var currentUser = Session["LogUser"] as UserDto;
            return Json(_serviceRepairService.UpdateServiceRepair(serviceRepair, currentUser));
        }
        public ActionResult TurnToInvalid(Guid serviceRepairId)
        {
            return null;
        }

        public ActionResult TurnToRepair(Guid serviceRepairId)
        {
            return null;
        }

        public ActionResult TurnToFinish(Guid serviceRepairId)
        {
            return null;
        }
        [HttpPost]
        public ActionResult Finish(ServiceRepairDto serviceRepairDto)
        {
            var currentUser = Session["LogUser"] as UserDto;
            return Json(_serviceRepairService.Finish(serviceRepairDto, currentUser));
        }
        [HttpPost]
        public ActionResult UnFinish(Guid serviceRepairId)
        {
            return null;
        }
        public ActionResult ViewDetail(Guid serviceRepairId)
        {
            var serviceRepair = _serviceRepairService.GetOneServiceRepair(serviceRepairId);
            return View(serviceRepair);
        }
        public ActionResult Query(string keyword)
        {
            return null;
        }
    }
}