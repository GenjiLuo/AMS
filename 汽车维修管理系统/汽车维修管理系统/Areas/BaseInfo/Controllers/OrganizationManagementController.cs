using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace 汽车维修管理系统.Areas.BaseInfo.Controllers
{
    public class OrganizationManagementController : Controller
    {
        // GET: BaseInfo/OrganizationManagement
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult JobManagement()
        {
            return View();
        }
        public ActionResult EmployeeManagement()
        {
            return View();
        }
    }
}