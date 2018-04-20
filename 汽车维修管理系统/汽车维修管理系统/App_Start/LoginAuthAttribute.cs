using System;
using System.Web;
using System.Web.Mvc;
using AMS.Model.dto;

namespace 汽车维修管理系统
{
    public class LoginAuthAttribute:AuthorizeAttribute
    {
        public bool IsLogin = false;
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            try
            {
                var webSession = httpContext.Session["LogUser"];
                var logUser = webSession as UserDto;
                if (webSession != null && logUser != null)
                {
                    IsLogin = true;
                }
                else
                {
                    IsLogin = false;
                }
            }
            catch (Exception e)
            {
                return IsLogin;
            }
            return IsLogin;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (filterContext == null)
            {
                throw new ArgumentNullException("filterContext");
            }
            else 
            {
                if (!IsLogin)
                {
                    var returnUrl = filterContext.HttpContext.Request.Url.PathAndQuery;
                    string loginUrl = $"~/Account/Index?returnUrl={returnUrl}";
                    filterContext.HttpContext.Response.Redirect(loginUrl);
                }
            }
        }
    }
}