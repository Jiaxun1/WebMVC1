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
            var bl = base.AuthorizeCore(httpContext);
            return bl;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectResult(FormsAuthentication.LoginUrl);
        }
    }
}