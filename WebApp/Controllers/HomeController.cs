using Business.Managers;
using Entities.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
	public class HomeController : Controller
	{
		public UreticiKayitManager ureticiKayitManager { get; set; } = new UreticiKayitManager();

		public ActionResult Index()
		{
			vmDuyurularIndex vm = new vmDuyurularIndex
			{
				//KayitBasliklar = ureticiKayitManager.KayitBaslikGetir(CurrentSession.UreticiID, CurrentSession.FilterDate_Start, CurrentSession.FilterDate_End),
				ur_toplam = ureticiKayitManager.Getir(575, DateTime.Now.AddDays(-200), DateTime.Now),
			};

			return View(vm);
		}
	}
}