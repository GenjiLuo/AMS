using System.Web;
using System.Web.Mvc;

namespace 汽车维修管理系统
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new LoginAuthAttribute());
            filters.Add(new HandleErrorAttribute());
        }
    }
}
