using System.Web.Mvc;

namespace 汽车维修管理系统.Areas.CustomerRelation
{
    public class CustomerRelationAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "CustomerRelation";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "CustomerRelation_default",
                "CustomerRelation/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}