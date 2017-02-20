using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVC1.Models;

namespace WebMVC1.Controllers
{
    public partial class BaseController : Controller
    {
        public SecurityUser CurrentUser
        {
            get
            {
                if (Session["SecurityUser"] == null)
                    return null;
                return Session["SecurityUser"] as SecurityUser;
            }
        }
    }
}