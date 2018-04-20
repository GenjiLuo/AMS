using System.Web.Mvc;

namespace 汽车维修管理系统.Areas.AutoRepair
{
    public class AutoRepairAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "AutoRepair";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "AutoRepair_default",
                "AutoRepair/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}