using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace WebMVC1.Filters
{
    public class AuthorizeFilter : AuthorizeAttribute
    {
        private string role;

        public AuthorizeFilter()
        { }

        public AuthorizeFilter(string role)
        {
            this.role = role;
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext.User.Identity.IsAuthenticated)
                return true;
            else
                return false;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectResult(FormsAuthentication.LoginUrl);
            //base.HandleUnauthorizedRequest(filterContext);
        }
    }
}