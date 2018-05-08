using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AMS.Model.dto;
using AMS.Service.Services.Implements;
using AMS.Service.Services.Interfaces;

namespace 汽车维修管理系统.Areas.PartDictionary.Controllers
{
    public class PartsDictionaryController : Controller
    {
        private readonly IPartsDictionaryService _partsDictionaryService;
        private readonly ICarModelService _carModelService;
        private readonly IPartsTypeService _partsTypeService;
        public PartsDictionaryController()
        {
            _partsDictionaryService = new PartsDictionaryService();
            _carModelService=new CarModelService();
            _partsTypeService=new PartsTypeService();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PartsDictionary_GridDataSource()
        {
            return Json(_partsDictionaryService.GetAllPartsDictionary(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Add()
        {
            return View();
        }

        public ActionResult PartsType_DropDownTreeViewDataSource()
        {
            var allItems = _partsTypeService.GetAllPartsType();
            var topItems = allItems.Where(i => !i.ParentId.HasValue).ToList();
            var hierarchicalPartsTypes = _partsTypeService.GetHierarchcalPartsType(topItems, allItems);
            return Json(hierarchicalPartsTypes, JsonRequestBehavior.AllowGet);
        }

        public ActionResult CarBrand_DropDownListDataSource()
        {
            return Json(_carModelService.GetBrandByKeyWord(""), JsonRequestBehavior.AllowGet);
        }
        public ActionResult CarSeries_DropDownListDataSource(string brandName)
        {
            return Json(_carModelService.GetSeriesByBrandAndKeyWord(brandName, ""), JsonRequestBehavior.AllowGet);
        }
        public ActionResult CarModel_DropDownListDataSource(string seriesName)
        {
            return Json(_carModelService.GetModelBySeriesAndKeyWord(seriesName, ""), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Add(PartsDictionaryDto partsDictionaryDto)
        {
            var currentUser = Session["LogUser"] as UserDto;
            return Json(_partsDictionaryService.AddPartsDictionary(partsDictionaryDto, currentUser));
        }
        public ActionResult Update(Guid partsDictionaryId)
        {
            var partsDictionary = _partsDictionaryService.GetOnePartsDictionary(partsDictionaryId);
            return View(partsDictionary);
        }
        [HttpPost]
        public ActionResult Update(PartsDictionaryDto partsDictionaryDto)
        {
            var currentUser = Session["LogUser"] as UserDto;
            return Json(_partsDictionaryService.UpdatePartsDictionary(partsDictionaryDto, currentUser));
        }

        [HttpPost]
        public ActionResult Delete(Guid partsDictionaryId)
        {
            return Json(_partsDictionaryService.DeletePartsDictionary(partsDictionaryId));
        }
        public ActionResult Query(string keyword)
        {
            return Json(_partsDictionaryService.QueryPartsDictionary(keyword));
        }

    }
}