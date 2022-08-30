using Entities.Log.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using UreticiTakip_Web.Classes;

namespace UreticiTakip_Web.Filters
{
    public class UreticiAttribute : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (CurrentSession.Get(SessionKeys.Kullanici) == null && CurrentSession.Get(SessionKeys.Uretici) == null)
            {
                filterContext.Result = new RedirectResult("/Bireysel/Giris");
            }
        }
    }

    public class NakliyeAttribute : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (CurrentSession.Get(SessionKeys.Kullanici) == null && CurrentSession.Get(SessionKeys.Sofor) == null)
            {
                filterContext.Result = new RedirectResult("/Nakliye/Giris");
            }
        }
    }

    public class AdminAttribute : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (CurrentSession.Get(SessionKeys.Kullanici) == null && CurrentSession.Get(SessionKeys.Admin) == null)
            {
                filterContext.Result = new RedirectResult("/Default/Index");
            }
        }
    }
}