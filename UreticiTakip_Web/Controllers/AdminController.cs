using Business.Managers;
using Entities.Log.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using UreticiTakip_Web.Classes;
using UreticiTakip_Web.Filters;

namespace UreticiTakip_Web.Controllers
{
    [Admin]
    public class AdminController : MyController
    {
        public WebExceptionManager webExceptionManager { get; set; } = new WebExceptionManager();

        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult ExceptionLogsGetir()
        {
            List<WebExceptionLogs> list = webExceptionManager.GetIEnum().OrderByDescending(x=>x.OlusturmaTarihi).ToList();
            return PartialView("_ExceptionLogs", list);
        }
    }
}
