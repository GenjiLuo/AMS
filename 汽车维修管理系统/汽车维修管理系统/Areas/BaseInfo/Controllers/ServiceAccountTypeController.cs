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
    public class ServiceAccountTypeController : Controller
    {
        private readonly IServiceAccountTypeService _serviceAccountTypeService;
        public ServiceAccountTypeController()
        {
            _serviceAccountTypeService=new ServiceAccountTypeService();
        }

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ServiceAccountType_GridDataSource()
        {
            return Json(_serviceAccountTypeService.GetAllServiceAccountType(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(ServiceAccountTypeDto serviceAccountTypeDto)
        {
            var currentUser = Session["LogUser"] as UserDto;
            return Json(_serviceAccountTypeService.AddServiceAccountType(serviceAccountTypeDto, currentUser));
        }
        public ActionResult Update(Guid serviceAccountTypeId)
        {
            var serviceAccountType = _serviceAccountTypeService.GetOneServiceAccountType(serviceAccountTypeId);
            return View(serviceAccountType);
        }
        [HttpPost]
        public ActionResult Update(ServiceAccountTypeDto serviceAccountTypeDto)
        {
            var currentUser = Session["LogUser"] as UserDto;
            return Json(_serviceAccountTypeService.UpdateServiceAccountType(serviceAccountTypeDto, currentUser));
        }
        [HttpPost]
        public ActionResult Delete(Guid serviceAccountTypeId)
        {
            return Json(_serviceAccountTypeService.DeleteServiceAccountType(serviceAccountTypeId));
        }

        public ActionResult Query(string keyword)
        {
            return Json(_serviceAccountTypeService.QueryServiceAccountType(keyword), JsonRequestBehavior.AllowGet);
        }
    }
}
