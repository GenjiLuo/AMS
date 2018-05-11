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
    public class ServiceTicketTypeController : Controller
    {
        private readonly IServiceTicketTypeService _serviceTicketTypeService;
        public ServiceTicketTypeController()
        {
            _serviceTicketTypeService = new ServiceTicketTypeService();
        }

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ServiceTicketType_GridDataSource()
        {
            return Json(_serviceTicketTypeService.GetAllServiceTicketType(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(ServiceTicketTypeDto serviceTicketType)
        {
            var currentUser = Session["LogUser"] as UserDto;
            return Json(_serviceTicketTypeService.AddServiceTicketType(serviceTicketType, currentUser));
        }
        public ActionResult Update(Guid serviceTicketTypeId)
        {
            var serviceTicketType = _serviceTicketTypeService.GetOneServiceTicketType(serviceTicketTypeId);
            return View(serviceTicketType);
        }
        [HttpPost]
        public ActionResult Update(ServiceTicketTypeDto serviceTicketType)
        {
            var currentUser = Session["LogUser"] as UserDto;
            return Json(_serviceTicketTypeService.UpdateServiceTicketType(serviceTicketType, currentUser));
        }
        [HttpPost]
        public ActionResult Delete(Guid serviceTicketTypeId)
        {
            return Json(_serviceTicketTypeService.DeleteServiceTicketType(serviceTicketTypeId));
        }

        public ActionResult Query(string keyword)
        {
            return Json(_serviceTicketTypeService.QueryServiceTicketType(keyword), JsonRequestBehavior.AllowGet);
        }
    }
}