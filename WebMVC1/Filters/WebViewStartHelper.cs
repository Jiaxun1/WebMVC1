using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVC1.Controllers;
using WebMVC1.Models;

namespace WebMVC1.Filters
{
    public abstract class WebViewStartHelper : ViewStartPage
    {
        public BaseController BaseController
        {
            get { return this.ViewContext.Controller as BaseController; }
        }
    }

    public abstract class WebViewPageHelper<TModel> : WebViewPage<TModel>
    {
        public BaseController BaseController
        {
            get { return this.ViewContext.Controller as BaseController; }
        }
    }
}