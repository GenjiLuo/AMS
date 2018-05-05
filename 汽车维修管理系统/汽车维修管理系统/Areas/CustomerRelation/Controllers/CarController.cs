using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AMS.Model.dto;
using AMS.Service.Services.Implements;
using AMS.Service.Services.Interfaces;
using 汽车维修管理系统.Models;

namespace 汽车维修管理系统.Areas.CustomerRelation.Controllers
{
    public class CarController : Controller
    {
        private readonly ICarService _carService;

        public CarController()
        {
            _carService=new CarService();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Car_GridDataSource()
        {
            return Json(_carService.GetAllCar(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(CarDto carDto)
        {
            var currentUser = Session["LogUser"] as UserDto;
            return Json(_carService.AddCar(carDto,currentUser));
        }
        public ActionResult Update(Guid carId)
        {
            var car = _carService.GetOneCar(carId);
            return View(car);
        }
        [HttpPost]
        public ActionResult Update(CarDto carDto)
        {
            var currentUser = Session["LogUser"] as UserDto;
            return Json(_carService.UpdateCar(carDto, currentUser));
        }
        [HttpPost]
        public ActionResult Delete(Guid carId)
        {
            return Json(_carService.DeleteCar(carId));
        }
        [HttpPost]
        public ActionResult SimpleQuery(string keyword)
        {
            return Json(_carService.QueryCar(keyword));
        }
        [HttpPost]
        public ActionResult AdvancedQuery(CarSearchModel carSearchModel)
        {
            return Json(_carService.AdvancedQueryCar(carSearchModel.Keyword));
        }
    }
}