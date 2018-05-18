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
    public class WashItemController : Controller
    {
        public readonly IWashItemService _WashItemService;

        public WashItemController()
        {
            _WashItemService=new WashItemService();
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Add()
        {
            return View();
        }

        public ActionResult WashItem_GridDataSource()
        {
            return Json(_WashItemService.GetAllWashItem(), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Add(WashItemDto washItemDto)
        {
            var currentUser = Session["LogUser"] as UserDto;
            return Json(_WashItemService.AddWashItem(washItemDto,currentUser));
        }
        public ActionResult Update(Guid washItemId)
        {
            var washItem = _WashItemService.GetOneWashItem(washItemId);
            return View(washItem);
        }
        [HttpPost]
        public ActionResult Update(WashItemDto washItemDto)
        {
            var currentUser = Session["LogUser"] as UserDto;
            return Json(_WashItemService.UpdateWashItem(washItemDto, currentUser));
        }
        [HttpPost]
        public ActionResult Delete(Guid washItemId)
        {
            return Json(_WashItemService.DeleteWashItem(washItemId));
        }
        [HttpPost]
        public ActionResult Query(string keyword)
        {
            return Json(_WashItemService.QueryWashItem(keyword));
        }
    }
}