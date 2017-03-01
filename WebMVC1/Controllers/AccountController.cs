using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebMVC1.Filters;
using WebMVC1.Models;

namespace WebMVC1.Controllers
{
    [RoutePrefix("Account")]
    public partial class AccountController : BaseController
    {
        [AllowAnonymous]
        [HttpGet]
        [Route("Login")]
        public virtual ActionResult Login()
        {
            var model = new LoginModel();
            return View(model);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Login")]
        public virtual ActionResult Login(LoginModel model)
        {
            //if (username == "Tom" && password == "123")
            if (model.UserName == "Tom" && model.Password == "123")
            {
                FormsAuthenticationTicket ticket = this.GetFormsAuthenticationTicket(model.UserName, false, "");
                HttpCookie ticketCookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(ticket));

                DateTime? dateExpires = ticket.IsPersistent ? DateTime.UtcNow.AddMinutes(30) : new Nullable<DateTime>();

                SetCookie(ticketCookie, dateExpires
                    , FormsAuthentication.FormsCookiePath
                    , FormsAuthentication.RequireSSL
                    , FormsAuthentication.CookieDomain);

                HttpContext.Session.Clear();
            }

            return Redirect("~/Test/Mvc");
        }

        private HttpCookie SetCookie(HttpCookie cookie)
        {
            HttpContext.Response.Cookies.Add(cookie);

            return cookie;
        }

        private HttpCookie SetCookie(HttpCookie cookie, DateTime? expires, string path, bool? secure, string domain)
        {
            cookie.HttpOnly = true;
            cookie.Path = string.IsNullOrEmpty(path) ? "/" : path;
            cookie.Secure = secure.HasValue ? secure.Value : false;

            if (string.IsNullOrEmpty(domain))
            {
                cookie.Domain = domain;
            }

            if (expires.HasValue)
            {
                cookie.Expires = expires.Value;
            }

            return SetCookie(cookie);
        }

        private FormsAuthenticationTicket GetFormsAuthenticationTicket(string account, bool isCreatePersistentCookie, string userData)
        {
            DateTime utcNow = DateTime.UtcNow;
            DateTime expirationUtc = utcNow.AddMinutes((double)FormsAuthentication.Timeout.TotalMinutes);

            return new FormsAuthenticationTicket(
                        1,
                        account,
                        utcNow.ToLocalTime(),
                        expirationUtc.ToLocalTime(),
                        isCreatePersistentCookie,
                        userData,
                        FormsAuthentication.FormsCookiePath);
        }
    }
}
