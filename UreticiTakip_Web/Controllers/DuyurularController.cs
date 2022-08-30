using Entities.Log.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

using UreticiTakip_Web.Classes;
using UreticiTakip_Web.Filters;

namespace UreticiTakip_Web.Controllers
{
    [Admin]
    public class DuyurularController : MyController
    {
        public ActionResult Index()
        {
            List<Duyurular> list = duyuruManager.GetIEnum(x=>x.Pasif != true).OrderByDescending(z => z.OlusturmaTarihi).ToList();
            return View(list);
        }

        public ActionResult Yeni()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Yeni(Duyurular model, string[] sehirler)
        {
            if (model.HerkeseMi == false && sehirler == null)
            {
                ViewBag.Error = "Lütfen Kime Gönderileceğini Seçiniz.";
                return View(model);

            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // Birden fazla bölge var ise bu şekilde kayıt yapılır.

            if (model.BitisTarihi == null)
            {
                model.BitisTarihi = DateTime.Today;
            }

            if (model.HerkeseMi)
            {
                duyuruManager.Insert(model);
            }
            else
            {
                foreach (string item in sehirler)
                {
                    model.Bolge = item;
                    duyuruManager.Insert(model);
                }
            }


            #region Old


            // Duyuru Kayıtlara boş kayıt açıp onaylayınca true'a çekiyoruz.
            // Artık sadece onaylayınca insert edeceğiz.

            //if (model.OnayGerekir)
            //{
            //	if (model.HerkeseMi)
            //	{
            //		// Tüm üreticilere gönderilecek
            //		duyurularKayitManager.DuyuruyaTumUreticilereEkle(model.DuyuruID);
            //	}
            //	else
            //	{
            //		// Secilen sehirlere göre kayıt ekleniyor.
            //		foreach (string item in sehirler)
            //		{
            //			List<URETICILER> ureticiler = ureticiManager.UreticileriSehreGoreGetir(item);
            //			duyurularKayitManager.DuyuruyaUreticiEkle(model.DuyuruID, ureticiler);

            //		}
            //	}
            //}


            #endregion

            return RedirectToAction("Index");
        }

        public ActionResult Duzenle(int id)
        {
            Duyurular duyuru = duyuruManager.Get(x => x.DuyuruID == id);
            return View(duyuru);
        }

        [HttpPost]
        public ActionResult Duzenle(int id, Duyurular model, string[] sehirler)
        {

            Duyurular duyurular = duyuruManager.Get(x => x.DuyuruID == id);

            //if (model.HerkeseMi == false && sehirler == null)
            //{
            //    ViewBag.Error = "Lütfen Kime Gönderileceğini Seçiniz.";
            //    return View(model);

            //}

            //if (!ModelState.IsValid)
            //{
            //    return View(model);
            //}


            //if (model.HerkeseMi)
            //{
            //    duyuruManager.Update(model);
            //}
            //else
            //{
            //    foreach (string item in sehirler)
            //    {
            //        model.Bolge = item;
            //        duyuruManager.Insert(model);
            //    }
            //}



            try
            {
                duyurular.Mesaj = model.Mesaj;
                duyurular.Baslik = model.Baslik;
                duyurular.BitisTarihi = model.BitisTarihi;
                duyurular.GuncellemeTarihi = DateTime.Now;


                duyuruManager.Update(duyurular);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Duyurular/Delete/5
        public ActionResult Sil(int id)
        {
            duyuruManager.Sil(id);

          

            return RedirectToAction("Index");
        }

        public PartialViewResult UreticiSehirleriGetir()
        {
            List<Country> list = ureticiManager.UreticiSehirleriGetir();
            return PartialView("_UreticiSehirler", list);
        }

        public PartialViewResult DuyurularımıGetir(int param)
        {
            //List<Duyurular> list = duyuruManager.DuyurularimiGetir(CurrentSession.Uretici.URETICI_NO);
            Duyurular duyurular = duyuruManager.Get(x => x.DuyuruID == param);

            return PartialView("_Duyurular", duyurular);
        }

        [HttpPost]
        public ActionResult DuyuruOnayla(string UreticiNo, int DuyuruID)
        {
            duyurularKayitManager.DuyuruOnayla(UreticiNo, DuyuruID);
            return Json(new { success = true, responseText = "Başarıyla Kaydedildi" }, JsonRequestBehavior.AllowGet);

        }

        public PartialViewResult DuyuruModal(int id)
        {
            Duyurular d = duyuruManager.Get(x => x.DuyuruID == id);
            return PartialView("_DuyuruModal", d);
        }

    }
}
