using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVC1.Controllers;
using WebMVC1.Models;

namespace WebMVC1.Filters
{
    public class GlobalAuthorizationFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            BaseController controller = filterContext.Controller as BaseController;
            if (!filterContext.IsChildAction)
            {
                var bl = filterContext.HttpContext.User.Identity.IsAuthenticated;
                if (bl && controller != null)
                {
                    SecurityUser user = new SecurityUser();
                    user.UserName = filterContext.HttpContext.User.Identity.Name;
                    controller.CurrentUser = user;
                }
            }
        }
    }
}