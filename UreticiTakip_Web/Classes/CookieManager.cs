
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UreticiTakip_Web.Classes
{
    public class CookieManager
    {
        HttpContext context;
        public CookieManager(HttpContext _context)
        {
            context = _context;
        }

        public void CreateCookie(string name, string value)
        {
            HttpCookie cookieVisitor = new HttpCookie(name, value);
            // cookieVisitor.Expires = DateTime.Now.AddDays(2);
            context.Response.Cookies.Add(cookieVisitor);
        }
        public string GetCookie(string name)
        {
            //Böyle bir cookie mevcut mu kontrol ediyoruz
            if (context.Request.Cookies.AllKeys.Contains(name))
            {
                //böyle bir cookie varsa bize geri değeri döndürsün
                return context.Request.Cookies[name].Value;
            }
            return null;
        }
        public void DeleteCookie(string name)
        {
            //Böyle bir cookie var mı kontrol ediyoruz
            if (GetCookie(name) != null)
            {
                //Varsa cookiemizi temizliyoruz
                context.Response.Cookies.Remove(name);
                //ya da 
                context.Response.Cookies[name].Expires = DateTime.Now.AddDays(-1);
            }
        }
    }
}