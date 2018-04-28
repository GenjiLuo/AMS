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
    public class OrganizationManagementController : Controller
    {
        private readonly IOrgService _orgService;

        public OrganizationManagementController()
        {
            _orgService=new OrgService();
        }
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
        public class Orgdatasource
        {
            public int Id { get; set; }
            public int? ParentId { get; set; }
            public string Name { get; set; }
            public string Description  { get; set; }
        }
        public ActionResult TreeList_OrgDatasource()
        {
            return Json(_orgService.GetOrganization(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult AddOrgPartialView(Guid? parentOrgId, string parentOrgName)
        {
            TempData["parentOrgId"] = parentOrgId ?? new Guid();
            TempData["parentOrgName"] = string.IsNullOrEmpty(parentOrgName) ? "总部" : parentOrgName;
            return PartialView("AddOrg_PartialView");
        }
        public ActionResult UpdateOrgPartialView(Guid selectedOrgId)
        {
            return PartialView("UpdateOrg_PartialView");
        }

        [HttpPost]
        public ActionResult AddNewOrganization(OrgDto orgDto)
        {
            if (orgDto.ParentId == Guid.Empty)
            {
                orgDto.ParentId = null;
            }
            var currentUser = Session["LogUser"] as UserDto;
            return Json(_orgService.AddOrganization(orgDto, currentUser));
        }
        [HttpPost]
        public ActionResult UpdateOrganization(OrgDto orgDto)
        {
            var currentUser = Session["LogUser"] as UserDto;
            return Json(_orgService.UpdateOrganization(orgDto, currentUser));
        }
        [HttpPost]
        public ActionResult DeleteOrganization(OrgDto orgDto)
        {
            return Json(_orgService.DeleteOrganization(orgDto));
        }

        [HttpPost]
        public ActionResult DisableOrganization(OrgDto orgDto)
        {
            var currentUser = Session["LogUser"] as UserDto;
            return Json(_orgService.DisableOrganization(orgDto, currentUser));
        }
        [HttpPost]
        public ActionResult ActiveOrganization(OrgDto orgDto)
        {
            var currentUser = Session["LogUser"] as UserDto;
            return Json(_orgService.AcitveOrganization(orgDto, currentUser));
        }

    }
}