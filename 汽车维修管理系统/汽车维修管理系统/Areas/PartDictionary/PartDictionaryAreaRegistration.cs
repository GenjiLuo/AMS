using System.Web.Mvc;

namespace 汽车维修管理系统.Areas.PartDictionary
{
    public class PartDictionaryAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "PartDictionary";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "PartDictionary_default",
                "PartDictionary/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}