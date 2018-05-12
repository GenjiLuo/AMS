using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AMS.Model.dto;
using AMS.Service.Services.Implements;
using AMS.Service.Services.Interfaces;

namespace 汽车维修管理系统.Areas.SystemSetting.Controllers
{
    public class SystemSettingController : Controller
    {
        private readonly IBillNoSettingService _billNoSettingService;

        public SystemSettingController()
        {
            _billNoSettingService=new BillNoSettingService();
        }

        public ActionResult ParameterControll()
        {
            return View();
        }
        public ActionResult OrderNoSetting()
        {
            var billNoSettings = _billNoSettingService.GetAllBillNoSetting();
            return View(billNoSettings);
        }
        [HttpPost]
        public ActionResult Update(List<BillNoSettingDto> billNoSettingDtos)
        {
            var currentUser = Session["LogUser"] as UserDto;
            return Json(_billNoSettingService.UpdateBillNoSetting(billNoSettingDtos, currentUser));
        }
    }
}