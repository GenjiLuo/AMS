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
        private readonly IParameterControlService _parameterControlService;

        public SystemSettingController()
        {
            _billNoSettingService=new BillNoSettingService();
            _parameterControlService=new ParameterControlService();
        }

        public ActionResult ParameterControl()
        {
            var parameterControls = _parameterControlService.GetAllParameterControls();
            return View(parameterControls);
        }
        [HttpPost]
        public ActionResult UpdateParameterControl(List<ParameterControlDto> parameterControlDtos)
        {
            var currentUser = Session["LogUser"] as UserDto;
            return Json(_parameterControlService.UpdateParameterControl(parameterControlDtos, currentUser));
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