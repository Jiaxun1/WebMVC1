using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebMVC1.Filters;

namespace WebMVC1.Controllers
{
    [AuthorizeFilter]
    [RoutePrefix("Account")]
    public partial class AccountController : BaseController
    {
        [AllowAnonymous]
        [HttpGet]
        [Route("Login")]
        public virtual ActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Login")]
        public virtual ActionResult Login(string userName, string password)
        {
            if (userName == "Tom" && password == "123")
            {
                //FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(userName, true, 20);
                //var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(ticket));
                //cookie.HttpOnly = true;
                //HttpContext.Response.Cookies.Add(cookie);

                FormsAuthentication.SetAuthCookie(userName, false);
                FormsAuthentication.RedirectFromLoginPage(userName, false);
            }

            return Redirect("~/Test/Mvc");
        }
    }
}
