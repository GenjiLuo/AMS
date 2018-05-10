using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace 汽车维修管理系统.Areas.CustomerRelation.Controllers
{
    public class MemberCardController : Controller
    {
        // GET: CustomerRelation/MemberCard
        public ActionResult Create()
        {
            return View();
        }
    }
}