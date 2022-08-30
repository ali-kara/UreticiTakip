using Business.Managers;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace NakliyeBilgiSistemi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NakliyeController : ControllerBase
    {
        NakliyeManager nakliyeManager;
        UreticiManager ureticiManager;

        public NakliyeController()
        {
            nakliyeManager = new NakliyeManager();
            ureticiManager = new UreticiManager();
        }


        public IActionResult Get(string Kodu, string Bolge, string Plaka)
        {
            List<NakliyeTombala> list = new List<NakliyeTombala>();

            list = nakliyeManager.TombalaGetir(Kodu, Bolge, Plaka);

            return Ok(list);

        }

        public IActionResult Delete(int id)
        {
            bool durum = nakliyeManager.TombalaSil(id);

            if (durum)
            {
                return Ok("Kayıt Silindi");
            }
            else
            {
                return BadRequest("Hata Kayıt Silinemedi.");

            }
        }
        public IActionResult Insert(string Barkod, string UreticiKodu, string Adet)
        {
            int Adett;

            try
            {
                Adett = Convert.ToInt32(Adet);
            }
            catch (Exception ex)
            {
                //TODO:lOG
                return BadRequest("Adet Uygun formatta girilmedi.");
            }


            Soforler soforler = new Soforler();
                //CurrentSession.Get<Soforler>(SessionKeys.Sofor);


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
                    return BadRequest("Uygun Barkod Okutulmadı.");
                }

                if (Barkod.Length < 10 || Barkod.Length > 12)
                {
                    return BadRequest("Uygun Barkod Okutulmadı.");
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
                return BadRequest("Geçerli bir üretici bulunamadı");
            }

            string Bolge = "";
            //CurrentSession.Get(SessionKeys.NakliyeBolge).ToString();
            string Plaka = "";
            //CurrentSession.Get(SessionKeys.NakliyePlaka).ToString();



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
                return Ok("Başarıyla Kaydedildi");
            }
            else
            {
                return BadRequest("Hata");
            }
        }

        string RemoveLeadingZeros(string str)
        {
            string regex = "^0+(?!$)";

            str = System.Text.RegularExpressions.Regex.Replace(str, regex, "");

            return str;
        }
    }
}