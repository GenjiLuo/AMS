using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AMS.Service.Services.Implements;
using AMS.Service.Services.Interfaces;

namespace 汽车维修管理系统.Areas.SystemSetting.Controllers
{
    public class SystemLogController : Controller
    {
        private readonly IOperationLogService _operationLogService;

        public SystemLogController()
        {
            _operationLogService=new OperationLogService();
        }
        public ActionResult OperationLog()
        {
            return View();
        }

        public ActionResult OperationLog_GridDataSource()
        {
            return Json(_operationLogService.GetAllOperationLog(),JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Delete()
        {
            return Json(_operationLogService.DeleteOperationLog());
        }
        public ActionResult Query(string keyword)
        {
            return Json(_operationLogService.QueryOperationLog(keyword));
        }
    }
}