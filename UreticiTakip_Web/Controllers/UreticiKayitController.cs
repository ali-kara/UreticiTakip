using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Business.Managers;
using Entities.Models;
using Entities.ViewModels;
using UreticiTakip_Web.Classes;
using UreticiTakip_Web.Filters;

namespace UreticiTakip_Web.Controllers
{
    [Uretici]
    public class UreticiKayitController : MyController
    {
        public ActionResult Index()
        {
            vmDuyurularIndex vm = new vmDuyurularIndex
            {
                //KayitBasliklar = ureticiKayitManager.KayitBaslikGetir(CurrentSession.UreticiID, CurrentSession.FilterDate_Start, CurrentSession.FilterDate_End),
                ur_toplam = ureticiKayitManager.Getir(CurrentSession.UreticiID, CurrentSession.FilterDate_Start, CurrentSession.FilterDate_End),
                Duyurular = duyuruManager.DuyurularimiGetir(CurrentSession.Uretici)
            };

            return View(vm);
        }
        [HttpPost]
        public ActionResult Index(DateTime? dateBaslangic, DateTime? dateBitis)
        {
            CurrentSession.Set(SessionKeys.FilterDate_Start, dateBaslangic.Value);
            CurrentSession.Set(SessionKeys.FilterDate_End, dateBitis.Value);


            vmDuyurularIndex vm = new vmDuyurularIndex
            {
                //KayitBasliklar = ureticiKayitManager.KayitBaslikGetir(CurrentSession.UreticiID, CurrentSession.FilterDate_Start, CurrentSession.FilterDate_End),
                ur_toplam = ureticiKayitManager.Getir(CurrentSession.UreticiID, CurrentSession.FilterDate_Start, CurrentSession.FilterDate_End)
            };

            return View(vm);
        }

        public ActionResult KayitDetay(string sube, DateTime? tarih, int sira_no)
        {
            //List<KAYIT_DETAY> model = db.Kayit_Detay.Where(x => x.KAYIT_BASLIK_ID == kayit_id && x.DEPO_SIRA_NO != 0).ToList();
            List<KAYIT_DETAY> model = ureticiKayitManager.KayitDetayGetir(CurrentSession.UreticiID, sube, tarih, sira_no);

            return View(model);
        }
        public ActionResult IndexDetayli()
        {
            List<KAYIT_BASLIK> list = ureticiKayitManager.KayitBaslikGetir(CurrentSession.UreticiID, CurrentSession.FilterDate_Start, CurrentSession.FilterDate_End);

            return View(list);
        }        
        [HttpPost]
        public ActionResult IndexDetayli(DateTime? dateBaslangic, DateTime? dateBitis)
        {
            CurrentSession.Set(SessionKeys.FilterDate_Start, dateBaslangic.Value);
            CurrentSession.Set(SessionKeys.FilterDate_End, dateBitis.Value);

            List<KAYIT_BASLIK> list = ureticiKayitManager.KayitBaslikGetir(CurrentSession.UreticiID, dateBaslangic.Value, dateBitis.Value);


            return View(list);
        }
        public ActionResult KayitDetayDetayli(string sube, DateTime? tarih, int sira_no)
        {
            List<KAYIT_DETAY> model = ureticiKayitManager.KayitDetayGetir(CurrentSession.UreticiID, sube, tarih, sira_no);

            return View(model);
        }
        public ActionResult GecmisKayitlarim()
        {
            ViewBag.Years = new SelectList(IslemYili.YillariGetir(), "Yil", "YilAdi");

            if (CurrentSession.Get(SessionKeys.SecilenYil) == null)
            {
                ViewBag.SelectedYears = "2021";
                CurrentSession.Set(SessionKeys.SecilenYil, "2021");
            }
            else
            {
                ViewBag.SelectedYears = CurrentSession.Get(SessionKeys.SecilenYil).ToString();
            }

            List<KAYIT_BASLIK> list = ureticiKayitManager.KayitBaslikGetir(CurrentSession.UreticiID, CurrentSession.FilterDate_Start, CurrentSession.FilterDate_End, Convert.ToInt32(ViewBag.SelectedYears));

            return View(list);
        }        
        [HttpPost]
        public ActionResult GecmisKayitlarim(DateTime? dateBaslangic, DateTime? dateBitis, string SelectedYears)
        {
            CurrentSession.Set(SessionKeys.FilterDate_Start, dateBaslangic.Value);
            CurrentSession.Set(SessionKeys.FilterDate_End, dateBitis.Value);


            ViewBag.Years = new SelectList(IslemYili.YillariGetir(), "Yil", "YilAdi");
            ViewBag.SelectedYears = SelectedYears;

            CurrentSession.Set(SessionKeys.SecilenYil, ViewBag.SelectedYears);

            List<KAYIT_BASLIK> list = ureticiKayitManager.KayitBaslikGetir(CurrentSession.UreticiID, dateBaslangic.Value, dateBitis.Value, Convert.ToInt32(SelectedYears.ToString()));

            return View(list);
        }
        public ActionResult GecmisKayitDetay(string sube, DateTime? tarih, int sira_no)
        {
            int Yil = Convert.ToInt32(CurrentSession.Get(SessionKeys.SecilenYil));

            List<KAYIT_DETAY> model = ureticiKayitManager.KayitDetayGetir(CurrentSession.UreticiID, sube, tarih, sira_no, Yil);

            return View(model);
        }
    }
}