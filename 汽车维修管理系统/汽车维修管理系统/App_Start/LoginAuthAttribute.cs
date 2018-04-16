using AMS.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace 汽车维修管理系统.App_Start
{
    public class LoginAuthAttribute:AuthorizeAttribute
    {
        public bool IsLogin = false;
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            try
            {
                var webSession = httpContext.Session["LogUser"];
                var logUser = webSession as User;
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
                    string returnUrl = filterContext.HttpContext.Request.Url.PathAndQuery;
                    string loginUrl = $"~/Account/Index?returnUrl={returnUrl}";
                    filterContext.HttpContext.Response.Redirect(loginUrl);
                }
            }
        }
    }
}