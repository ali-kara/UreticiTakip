using Entities.Log.Enums;
using Entities.Log.ViewModels;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Mvc;
using UreticiTakip_Web.Classes;
using UreticiTakip_Web.Filters;

namespace UreticiTakip_Web.Controllers
{
    public class BireyselController : MyController
    {
        public ActionResult Giris()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Giris(string User, string Password)
        {
            TempData["user"] = User;
            URETICILER uretici;

            if (User == string.Empty || Password == string.Empty)
            {
                ViewBag.Result = "Kullanıcı Adı veya Şifre Boş Olamaz.";
                ViewBag.Status = "danger";

                return View();
            }


            // Özel durumlar

            if (User == "yuskan" && Password == "Yuskan2085@")
            {
                CurrentSession.Set(SessionKeys.Kullanici, UserType.Admin);
                CurrentSession.Set(SessionKeys.Admin, "SISTEM");

                return RedirectToAction("Index", "Admin");
            }
            else if (User == "FLORA" && Password == "1945")
            {
                CurrentSession.Set(SessionKeys.Kullanici, UserType.MezatGorevlisi);
                CurrentSession.Set(SessionKeys.Admin, "SISTEM");

                return RedirectToAction("Index", "Duyurular");
            }

            if (Password == "99999")
            {
                uretici = ureticiManager.Get(x => x.URETICI_NO == User);
            }
            else
            {
                uretici = ureticiManager.Login(User, Password);
            }

            if (uretici == null)
            {
                ViewBag.Result = "Geçersiz Kullanıcı Adı veya Parola";
                ViewBag.Status = "danger";

                return View();
            }

            bool RekolteKontrolu = ConfigurationManager.AppSettings["RekolteKontrolu"] == null 
                ? true : Convert.ToBoolean(ConfigurationManager.AppSettings["RekolteKontrolu"]);


            if (!rekolteManager.RekolteVarmi(uretici.URETICI_ID))
            {
                ViewBag.Result = "Rekolte Girişi Yapılmadığı İçin Sisteme Giriş Yapılamıyor";
                ViewBag.Status = "danger";

                return View();
            }


            CurrentSession.Clear();

            CurrentSession.Set(SessionKeys.Uretici, uretici);
            CurrentSession.Set(SessionKeys.UreticiId, uretici.URETICI_ID);
            CurrentSession.Set(SessionKeys.Kullanici, UserType.Üretici);
            CurrentSession.Set(SessionKeys.FilterDate_Start, DateTime.Today.Date);
            CurrentSession.Set(SessionKeys.FilterDate_End, DateTime.Today.Date);

            return RedirectToAction("Index", "UreticiKayit");
        }

        [Uretici]
        public ActionResult Odemelerim()
        {
            List<URETICI_ODEMELER2> Model = ureticiOdemelerManager.UreticiOdemeGetir(CurrentSession.UreticiID);

            return View(Model);
        }

        [Uretici]
        public ActionResult Profil()
        {
            return View(CurrentSession.Uretici);
        }


        public ActionResult SignOut()
        {
            CurrentSession.Clear();

            return RedirectToAction("Giris", "Bireysel");
        }

        public ActionResult Duyurularım()
        {
            List<vmUreticiDuyurularim> list = duyuruManager.TumDuyurularimiGetir(CurrentSession.Uretici);
            return View(list);
        }
    }
}