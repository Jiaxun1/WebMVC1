using System.Web;
using System.Web.Mvc;
using WebMVC1.Filters;

namespace WebMVC1
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new GlobalAuthorizationFilter());
        }
    }
}
