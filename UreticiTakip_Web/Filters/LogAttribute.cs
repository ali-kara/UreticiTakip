using System.Web.Mvc;
using System.Net;

using System.Web.Routing;
using System.Web;

namespace UreticiTakip_Web.Filters
{
    public class LogAttribute : FilterAttribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            //HttpSessionStateBase session = filterContext.HttpContext.Session;

            //if (session != null && session["uretici"] == null)
            //{
            //    //filterContext.Result = new RedirectToRouteResult(
            //    //    new RouteValueDictionary {
            //    //                { "Controller", "Default" },
            //    //                { "Action", "Giris" }
            //    //                });
            //}
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {

        }
    }
}