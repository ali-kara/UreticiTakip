using System.Web.Mvc;

namespace UreticiTakip_Web.Filters
{
    public class CustomHttpsAttribute : RequireHttpsAttribute
    {
        protected override void HandleNonHttpsRequest(AuthorizationContext filterContext)
        {
            string host = filterContext.HttpContext.Request.Url.Host;

            if (!host.Contains("localhost")) // && !host.Contains("192.168.1.58"))&& !host.Contains("185.106.209.219"))
            {
                base.HandleNonHttpsRequest(filterContext);
            }
        }

    }
}