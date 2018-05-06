using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AMS.Model.dto;
using AMS.Model.Repositories.Interfaces;
using AMS.Service.Services.Implements;
using AMS.Service.Services.Interfaces;

namespace 汽车维修管理系统.Areas.BaseInfo.Controllers
{
    public class CarModelController : Controller
    {
        private readonly ICarModelService _carModelService;

        public CarModelController()
        {
            _carModelService = new CarModelService();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Grid_CarModelDataSource()
        {
            return Json(_carModelService.GetAllCarModel(),JsonRequestBehavior.AllowGet);
        }

        public ActionResult Add()
        {
            return View();
        }

        public ActionResult Brand_AutoComplateDataSource(string brandKeyWord)
        {
            return Json(_carModelService.GetBrandByKeyWord(brandKeyWord), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Series_AutoComplateDataSource(string brandName,string seriesKeyWord)
        {
            return Json(_carModelService.GetSeriesByBrandAndKeyWord(brandName, seriesKeyWord),
                JsonRequestBehavior.AllowGet);
        }
        public ActionResult Model_AutoComplateDataSource(string seriesName,string modelKeyWord)
        {
            return Json(_carModelService.GetModelBySeriesAndKeyWord(seriesName, modelKeyWord),
                JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Add(CarModelDto carModelDto)
        {
            var currentUser = Session["LogUser"] as UserDto;
            return Json(_carModelService.AddCarModel(carModelDto, currentUser));
        }
        public ActionResult Update(Guid carModelId)
        {
            var carModel = _carModelService.GetOneCarModel(carModelId);
            return View(carModel);
        }

        [HttpPost]
        public ActionResult Update(CarModelDto carModelDto)
        {
            var currentUser = Session["LogUser"] as UserDto;
            return Json(_carModelService.UpdateCarModel(carModelDto, currentUser));
        }
        [HttpPost]
        public ActionResult Delete(Guid carModelId)
        {
            return Json(_carModelService.DeleteCarModel(carModelId));
        }

        public ActionResult Query(string keyword)
        {
            return Json(_carModelService.QueryCarModel(keyword), JsonRequestBehavior.AllowGet);
        }
    }
}