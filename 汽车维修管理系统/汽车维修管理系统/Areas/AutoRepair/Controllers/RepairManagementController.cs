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
        private readonly IServiceTicketTypeService _serviceTicketTypeService;
        private readonly IPaymentTypeService _paymentTypeService;
        private readonly IWashItemService _washItemService;
        private readonly IServiceRepairHistoryService _serviceRepairHistoryService;
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
            _serviceTicketTypeService=new ServiceTicketTypeService();
            _paymentTypeService=new PaymentTypeService();
            _washItemService=new WashItemService();
            _serviceRepairHistoryService=new ServiceRepairHistoryService();
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
            return Json(_serviceBookingService.GetUnBoundServiceBookingByCarId(carId), JsonRequestBehavior.AllowGet);
        }

        public ActionResult RepairHistory_GridDataSource(Guid carId)
        {
            return Json(_serviceRepairHistoryService.GetHistoryRepairByCarId(carId), JsonRequestBehavior.AllowGet);
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

        public ActionResult AddWashCar(ServiceRepairDto serviceRepair)
        {
            var currentUser = Session["LogUser"] as UserDto;
            return Json(_serviceRepairService.AddWashCar(serviceRepair, currentUser));
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

        public ActionResult WashItem_ButtonGroupDataSource()
        {
            return Json(_washItemService.GetAllWashItem(), JsonRequestBehavior.AllowGet);
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
                return View("EditWashCar", serviceRepair);
            }
            return View("EditCarRepair",serviceRepair);
        }

        public ActionResult RepairAccount(Guid serviceRepairId)
        {
            var serviceRepair = _serviceRepairService.GetOneServiceRepair(serviceRepairId);
            var serviceRepairAccountTicket=new ServiceRepairAccountTicketDto(){ ServiceRepair = serviceRepair };
            return View("RepairAccount", serviceRepairAccountTicket);
        }

        public ActionResult RepairCash(Guid serviceRepairId)
        {
            var serviceAccountTicket = _serviceRepairService.GetOneAccountTicketByRepairId(serviceRepairId);
            var serviceRepairCashTicket=new ServiceRepairCashTicketDto(){ ServiceRepairAccountTicket  = serviceAccountTicket };
            return View("RepairCash", serviceRepairCashTicket);
        }

        public ActionResult ServiceTickType_ButtonGroupDataSource()
        {
            return Json(_serviceTicketTypeService.GetAllServiceTicketType(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult PaymentType_Choose()
        {
            return Json(_paymentTypeService.GetAllPaymentType(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult ViewDetail(Guid serviceRepairId)
        {
            var serviceRepair = _serviceRepairService.GetOneServiceRepair(serviceRepairId);
            if (serviceRepair.ServiceType == ServiceType.洗车)
            {
                var serviceRepairCashTicket = _serviceRepairService.GetOneCashTicketByRepairId(serviceRepairId);
                if (serviceRepairCashTicket == null)
                {
                    serviceRepairCashTicket=new ServiceRepairCashTicketDto()
                    {
                        ServiceRepairPayments = new List<ServiceRpairPaymentDto>()
                        {
                            new ServiceRpairPaymentDto()
                        }
                    };
                    serviceRepair.ServiceWashItem = new ServiceWashItemDto();
                }
                serviceRepairCashTicket.ServiceRepair = serviceRepair;
                return View("WashCarView", serviceRepairCashTicket);
            }
            return View(serviceRepair);
        }
        [HttpPost]
        public ActionResult Update(ServiceRepairDto serviceRepair)
        {
            var currentUser = Session["LogUser"] as UserDto;
            return Json(_serviceRepairService.UpdateServiceRepair(serviceRepair, currentUser));
        }
        [HttpPost]
        public ActionResult TurnToInvalid(Guid serviceRepairId)
        {
            var currentUser = Session["LogUser"] as UserDto;
            return Json(_serviceRepairService.TurnToInvalid(serviceRepairId, currentUser));
        }
        [HttpPost]
        public ActionResult TurnToRepair(Guid serviceRepairId)
        {
            var currentUser = Session["LogUser"] as UserDto;
            return Json(_serviceRepairService.TurnToRepair(serviceRepairId, currentUser));
        }
        [HttpPost]
        public ActionResult TurnToFinish(Guid serviceRepairId)
        {
            var currentUser = Session["LogUser"] as UserDto;
            return Json(_serviceRepairService.TurnToFinish(serviceRepairId, currentUser));
        }
        [HttpPost]
        public ActionResult TurnToUnFinish(Guid serviceRepairId)
        {
            var currentUser = Session["LogUser"] as UserDto;
            return Json(_serviceRepairService.TurnToFinish(serviceRepairId, currentUser));
        }
        [HttpPost]
        public ActionResult TurnToAccount(Guid serviceRepairId)
        {
            var currentUser = Session["LogUser"] as UserDto;
            return Json(_serviceRepairService.TurnToAccount(serviceRepairId, currentUser));
        }
        [HttpPost]
        public ActionResult TurnToCash(Guid serviceRepairId)
        {
            var currentUser = Session["LogUser"] as UserDto;
            return Json(_serviceRepairService.TurnToCash(serviceRepairId, currentUser));
        }
        [HttpPost]
        public ActionResult TurnToLeave(Guid serviceRepairId)
        {
            var currentUser = Session["LogUser"] as UserDto;
            return Json(_serviceRepairService.TurnToLeave(serviceRepairId, currentUser));
        }
        [HttpPost]
        public ActionResult SaveAndTurnToAccount(ServiceRepairAccountTicketDto serviceRepairAccountTicketDto)
        {
            var currentUser = Session["LogUser"] as UserDto;
            return Json(_serviceRepairService.SaveAndAccount(serviceRepairAccountTicketDto, currentUser));
        }
        [HttpPost]
        public ActionResult SaveAndTurnToFinish(ServiceRepairDto serviceRepairDto)
        {
            var currentUser = Session["LogUser"] as UserDto;
            return Json(_serviceRepairService.SaveAndFinish(serviceRepairDto, currentUser));
        }
        [HttpPost]
        public ActionResult SaveAndTurnToCash(ServiceRepairCashTicketDto serviceRepairCashTicketDto)
        {
            var currentUser = Session["LogUser"] as UserDto;
            return Json(_serviceRepairService.SaveAndCash(serviceRepairCashTicketDto, currentUser));
        }
        [HttpPost]
        public ActionResult WashCarTurnToCash(ServiceRepairCashTicketDto serviceRepairCashTicketDto)
        {
            var currentUser = Session["LogUser"] as UserDto;
            return Json(_serviceRepairService.WashCarSaveAndCash(serviceRepairCashTicketDto, currentUser));
        }
        [HttpPost]
        public ActionResult Query(string keyword)
        {
            return Json(_serviceRepairService.QueryServiceRepair(keyword));
        }
    }
}