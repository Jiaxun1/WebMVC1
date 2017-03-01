using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.Interface;
using WebMVC1.Filters;

namespace WebMVC1.Controllers
{
    [AuthorizeFilter]
    [RoutePrefix("Test")]
    public partial class HomeController : BaseController
    {
        private ITestService testService;

        public HomeController(ITestService testService)
        {
            this.testService = testService;
        }

        [Route("Mvc")]
        [Route("~/")]
        [HttpGet]
        public virtual ActionResult Index()
        {
            ViewBag.Hello = "Hello World";
            var model = this.testService.GetPersons();
            return View(model);
        }

        [ChildActionOnly]
        public virtual ActionResult GetGrid()
        {
            var model = this.testService.GetPersons();
            return PartialView(MVC.Shared.Views._Grid, model);
        }
    }
}
