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
    public class PartsTypeController : Controller
    {
        private readonly IPartsTypeService _partsTypeService;
        public PartsTypeController()
        {
            _partsTypeService=new PartsTypeService();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PartsType_TreeListDataSource()
        {
            return Json(_partsTypeService.GetAllPartsType(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Add(string parentName, Guid? parentId)
        {
            var partsType = new PartsTypeDto() { ParentId = parentId ?? new Guid() ,ParentName = parentName};
            return PartialView("Add_PartialView", partsType);
        }
        [HttpPost]
        public ActionResult Add(PartsTypeDto partsTypeDto)
        {
            var currentUser = Session["LogUser"] as UserDto;
            return Json(_partsTypeService.AddPartsType(partsTypeDto, currentUser));
        }
        public ActionResult Update(Guid partsTypeId)
        {
            var partsType = _partsTypeService.GetOnePartsType(partsTypeId);
            if (!partsType.ParentId.HasValue)
            {
                partsType.ParentId=new Guid();
                partsType.ParentName = "配件类型";
            }
            return PartialView("Update_PartialView",partsType);
        }
        [HttpPost]
        public ActionResult Update(PartsTypeDto partsTypeDto)
        {
            var currentUser = Session["LogUser"] as UserDto;
            return Json(_partsTypeService.UpdatePartsType(partsTypeDto, currentUser));
        }
        [HttpPost]
        public ActionResult Delete(Guid partsTypeId)
        {
            return Json(_partsTypeService.DeletePartsType(partsTypeId));
        }
    }
}