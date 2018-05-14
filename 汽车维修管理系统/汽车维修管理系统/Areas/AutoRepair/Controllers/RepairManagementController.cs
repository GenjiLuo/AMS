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
        public RepairManagementController()
        {
            _serviceRepairService=new ServiceRepairService();
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
        [HttpPost]
        public ActionResult Add(ServiceRepairDto serviceRepair)
        {
            return null;
        }

        public ActionResult Create()
        {
            return View("RepairCreate");
        }
        public ActionResult Edit()
        {
//            var serviceRepair = _serviceRepairService.GetOneServiceRepair(serviceRepairId);
//            if (serviceRepair.ServiceType == ServiceType.洗车)
//            {
//                return View("EditWashCar",serviceRepair);
//            }
//            return View("EditCarRepair",serviceRepair);
            return View("EditCarRepair");
        }

        public ActionResult RepairAccount()
        {
            return View("RepairAccount");
        }

        public ActionResult RepairCash()
        {
            return View("RepairCash");
        }
        [HttpPost]
        public ActionResult Update(ServiceRepairDto serviceRepair)
        {
            return null;
        }
        public ActionResult Delete(Guid serviceRepairId)
        {
            return null;
        }
        public ActionResult Query(string keyword)
        {
            return null;
        }
    }
}