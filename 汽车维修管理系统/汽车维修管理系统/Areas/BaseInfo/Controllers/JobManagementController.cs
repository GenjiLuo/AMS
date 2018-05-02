using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AMS.Model.dto;
using AMS.Model.poco;
using AMS.Service.Services.Implements;
using AMS.Service.Services.Interfaces;

namespace 汽车维修管理系统.Areas.BaseInfo.Controllers
{
    public class JobManagementController : Controller
    {
        private readonly IJobService _jobService;
        private readonly IOrgService _orgService;

        public JobManagementController()
        {
            _jobService=new JobService();
            _orgService=new OrgService();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Grid_JobDataSource()
        {
            return Json(_jobService.GetAllJob(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult DropDownList_OrgDataSource()
        {
            return Json(_orgService.GetOrganization(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult AddJob()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddJob(JobDto jobDto)
        {
            var currentUser = Session["LogUser"] as UserDto;
            return Json(_jobService.AddJob(jobDto, currentUser));
        }
        public ActionResult UpdateJob(Guid jobId)
        {
            var job = _jobService.GetOneJob(jobId);
            return View(job);
        }
        [HttpPost]
        public ActionResult UpdateJob(JobDto jobDto)
        {
            var currentUser = Session["LogUser"] as UserDto;
            return Json(_jobService.UpdateJob(jobDto, currentUser));
        }
        [HttpPost]
        public ActionResult DeleteJob(Guid jobId)
        {
            return Json(_jobService.DeleteJob(jobId));
        }
    }
}