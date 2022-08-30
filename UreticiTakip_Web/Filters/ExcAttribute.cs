using Business.Managers;
using Common.Logging;
using Entities.Log.Models;
using System;
using System.Web.Mvc;

using UreticiTakip_Web.Classes;

namespace UreticiTakip_Web.Filters
{
    public class ExcAttribute : FilterAttribute, IExceptionFilter
    {
        public WebExceptionManager webExceptionManager { get; set; } = new WebExceptionManager();

        public void OnException(ExceptionContext filterContext)
        {
            try
            {
                filterContext.ExceptionHandled = true;

                webExceptionManager.Insert(new WebExceptionLogs()
                {
                    OlusturmaTarihi = DateTime.Now,
                    ActionName = filterContext.RouteData.Values["action"].ToString(),
                    Controller = filterContext.RouteData.Values["controller"].ToString(),
                    Message = filterContext.Exception.Message,
                    Stacktrace = filterContext.Exception.StackTrace,
                    InnerException = (filterContext.Exception.InnerException == null) ? "" : filterContext.Exception.InnerException.ToString()
                });


                CurrentSession.Set(SessionKeys.Exception, filterContext.Exception);

            }
            catch (Exception ex)
            {
                Log.Log2Txt(ex);
            }

            filterContext.Result = new RedirectResult("/Default/Hata");

        }
    }
}