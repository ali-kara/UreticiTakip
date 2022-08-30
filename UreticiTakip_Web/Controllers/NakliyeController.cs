using Entities.Log.Enums;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

using UreticiTakip_Web.Classes;
using UreticiTakip_Web.Filters;

namespace UreticiTakip_Web.Controllers
{
	public class NakliyeController : MyController
	{
		public ActionResult Giris()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Giris(string Kodu, string Password)
		{
			TempData["kodu"] = Kodu;

			if (Kodu == string.Empty || Password == string.Empty)
			{
				ViewBag.Result = "Kullanıcı Adı veya Şifre Boş Olamaz.";
				ViewBag.Status = "danger";

				return View();
			}


			Soforler sofor = soforlerManager.Login(Kodu, Password);

			if (sofor == null)
			{
				ViewBag.Result = "Geçersiz Kullanıcı Adı veya Şifre";
				ViewBag.Status = "danger";

				return View();
			}


			CurrentSession.Clear();

			CurrentSession.Set(SessionKeys.Sofor, sofor);
			CurrentSession.Set(SessionKeys.SoforKodu, sofor.Kodu);
			CurrentSession.Set(SessionKeys.Kullanici, UserType.Nakliyeci);

			return RedirectToAction("GirisBilgi");
		}
		[Nakliye]
		public ActionResult GirisBilgi()
		{
			ViewBag.Plaka = new SelectList(nakliyeManager.PlakalarList(), "Plaka", "Plaka");
			ViewBag.Bolge = new SelectList(nakliyeManager.BolgelerList(), "BolgeAdi", "BolgeAdi");

			Soforler soforler = CurrentSession.Get<Soforler>(SessionKeys.Sofor);

			ViewModelNakliye viewModel = new ViewModelNakliye
			{
				Soforler = soforler,
				Sehirler = 1 // cmb değeleri tutsun diye
			};


			return View(viewModel);
		}

		[HttpPost]
		[Nakliye]
		public ActionResult GirisBilgi(string Plaka, string Bolge)
		{

			CurrentSession.Set(SessionKeys.NakliyeBolge, Bolge);
			CurrentSession.Set(SessionKeys.NakliyePlaka, Plaka);

			return RedirectToAction("Index");
		}
		[Nakliye]
		public ActionResult Index()
		{
			Soforler soforler = CurrentSession.Get<Soforler>(SessionKeys.Sofor);


			ViewModelNakliye viewModel = new ViewModelNakliye
			{
				Soforler = soforler,
				Sehirler = 1
			};

			ViewBag.Plaka = new SelectList(nakliyeManager.PlakalarList(), "Plaka", "Plaka");
			ViewBag.Bolge = new SelectList(nakliyeManager.BolgelerList(), "BolgeAdi", "BolgeAdi");




			return View(viewModel);
		}

		[HttpPost]
		[Nakliye]
		public ActionResult Index(ViewModelNakliye viewModel)
		{
			var a = viewModel;

			ViewBag.Plaka = new SelectList(nakliyeManager.PlakalarList(), "Plaka", "Plaka");
			ViewBag.Bolge = new SelectList(nakliyeManager.BolgelerList(), "BolgeAdi", "BolgeAdi");


			return View(viewModel);
		}


		[HttpPost]
		public ActionResult NakliyeTombalaGetir()
		{
			Soforler soforler = CurrentSession.Get<Soforler>(SessionKeys.Sofor);

			if (soforler == null)
			{
				Session.Clear();
				return RedirectToAction("Giris", "Nakliye");
			}

			string Bolge = CurrentSession.Get(SessionKeys.NakliyeBolge).ToString();
			string Plaka = CurrentSession.Get(SessionKeys.NakliyePlaka).ToString();

			List<NakliyeTombala> list = new List<NakliyeTombala>();

			list = nakliyeManager.TombalaGetir(soforler.Kodu, Bolge, Plaka);



			//System.Threading.Thread.Sleep(3000);



			return PartialView("_PartialNakliyeTombala", list);
		}

		[HttpPost]
		public ActionResult NakliyeTombalaKaydet(string Barkod, string UreticiKodu, string Adet)
		{
			int Adett;

			try
			{
				Adett = Convert.ToInt32(Adet);
			}
			catch (Exception ex)
			{
				//TODO:lOG
				return Json(new { success = false, responseText = "Adet Uygun formatta girilmedi." }, JsonRequestBehavior.AllowGet);
			}


			Soforler soforler = CurrentSession.Get<Soforler>(SessionKeys.Sofor);

			if (soforler == null)
			{
				Session.Clear();
				return RedirectToAction("Giris", "Nakliye");
			}



			URETICILER uretici = null;

			if (UreticiKodu.Trim() != "")
			{
				uretici = ureticiManager.GetById(UreticiKodu);
			}



			else if (Barkod.Trim() != "")
			{
				string Barkodd = "";

				if (!Barkod.ToUpper().StartsWith("FLORA"))
				{
					return Json(new { success = false, responseText = "Uygun Barkod Okutulmadı." }, JsonRequestBehavior.AllowGet);
				}

				if (Barkod.Length < 10 || Barkod.Length > 12)
				{
					return Json(new { success = false, responseText = "Uygun Barkod Okutulmadı." }, JsonRequestBehavior.AllowGet);
				}

				Barkodd = Barkod.Substring(8);

				if (Barkodd.StartsWith("0"))
				{
					Barkodd = RemoveLeadingZeros(Barkodd);
				}

				uretici = ureticiManager.GetById(Barkodd);

			}

			if (uretici == null)
			{
				return Json(new { success = false, responseText = "Geçerli bir üretici bulunamadı" }, JsonRequestBehavior.AllowGet);
			}

			string Bolge = CurrentSession.Get(SessionKeys.NakliyeBolge).ToString();
			string Plaka = CurrentSession.Get(SessionKeys.NakliyePlaka).ToString();



			NakliyeTombala nakliyeTombala = new NakliyeTombala
			{
				Bolge = Bolge,
				Plaka = Plaka,
				SoforKodu = soforler.Kodu,
				SonGuncelleyen = soforler.Kodu,
				UreticiAdiSoyadi = uretici.ADI + " " + uretici.SOYADI,
				UreticiIli = uretici.IL,
				UreticiKodu = uretici.URETICI_NO,
				Adet = Convert.ToInt32(Adet),
				Nakliyeci = soforler.Nakliyeci,
				OlusturmaTarihi = DateTime.Now,
				Tarih = DateTime.Now,
				
			};

			bool durum = nakliyeManager.TombalaKaydet(nakliyeTombala);


			if (durum)
			{
				return Json(new { success = true, responseText = "Başarıyla Kaydedildi" }, JsonRequestBehavior.AllowGet);
			}
			else
			{
				return Json(new { success = false, responseText = "Hata" }, JsonRequestBehavior.AllowGet);
			}
		}

		string RemoveLeadingZeros(string str)
		{
			string regex = "^0+(?!$)";

			str = System.Text.RegularExpressions.Regex.Replace(str, regex, "");

			return str;
		}

		public ActionResult NakliyeTombalaSil(int id)
		{
			if (CurrentSession.Get<Soforler>(SessionKeys.Sofor) == null)
			{
				Session.Clear();
				return RedirectToAction("Giris", "Nakliye");
			}


			bool durum = nakliyeManager.TombalaSil(id);

			if (durum)
			{
				return Json(new { success = true, responseText = "Kayıt Silindi" }, JsonRequestBehavior.AllowGet);
			}
			else
			{
				return Json(new { success = false, responseText = "Hata" }, JsonRequestBehavior.AllowGet);
			}
		}

		public ActionResult SignOut()
		{
			CurrentSession.Clear();

			return RedirectToAction("Giris", "Nakliye");
		}


	}
}

public class ViewModelNakliye
{
	public Soforler Soforler { get; set; }

	public NakliyeTombala NakliyeTombala { get; set; }
	public int Sehirler { get; set; }
}


/*

Üretici Giriş Formu aynı başlık Nakliyeci Giriş Formu

Plakalar Tablosu olacak.

Şoförler Tablosu

Kodu
Adı
Soyadı	
Bölge
Plaka
İl
Şifre

Plaka
İl 
Bölge değerleri seçili gelecek

Ama combobox ile değiştirebilecek

Altta

NakliyeTombala
Id
ÜreticiKodu
ÜreticiAdıSoyadı
ÜreticiIli
ŞoförKodu
Plaka
İl
Bölge


Barkodda
İlk 5 hane FLORA
6. karakter - 
7 tür (1,0)
8 karakter - 
9,10,11,12 karakter üretici kodu

Bölgeler
İzmir
Antalya
Adana
Mersin
Yalova
 


 
 
 */