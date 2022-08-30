using System;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using UreticiTakip_Web.App_Start;
using UreticiTakip_Web.Filters;

namespace UreticiTakip_Web
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            AreaRegistration.RegisterAllAreas();
            RegisterGlobalFilters(GlobalFilters.Filters);

            GlobalConfiguration.Configure(WebApiConfig.Register);

            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

        }

        public void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            GlobalFilters.Filters.Add(new CustomHttpsAttribute());
            GlobalFilters.Filters.Add(new ExcAttribute());
            GlobalFilters.Filters.Add(new LogAttribute());
        }
    }
}