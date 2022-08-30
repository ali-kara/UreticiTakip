using Business.Managers;
using Entities.Models;
using Entities.Results;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace UreticiTakip_Web.Controllers.api
{
    public class TombalaController : ApiController
    {
        UreticiManager ureticiManager;
        SoforlerManager soforlerManager;
        NakliyeManager nakliyeManager;

        public TombalaController()
        {
            ureticiManager = new UreticiManager();
            soforlerManager = new SoforlerManager();
            nakliyeManager = new NakliyeManager();
        }


        [Route("api/tombala/get")]
        [HttpPost]
        public IHttpActionResult Get([FromBody] JObject data)
        {
            var response = new DListResult<NakliyeTombala>();
            String Sofor_Kodu, Bolge, Plaka;


            try
            {
                Sofor_Kodu = data["Sofor_Kodu"].ToString();
                Bolge = data["Bolge"].ToString();
                Plaka = data["Plaka"].ToString();
            }
            catch (Exception)
            {
                response.Success = false;
                response.Message = "Parametre Hatalı";

                return Ok(response);
                
            }


            List<NakliyeTombala> list = nakliyeManager.TombalaGetir(Sofor_Kodu, Bolge, Plaka);

            response.Data = list;


            return Ok(response);

        }

        [Route("api/tombala/delete")]
        [HttpGet]
        public IHttpActionResult Delete(int id)
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



        [Route("api/tombala/insert")]
        [HttpPost]
        public IHttpActionResult Insert([FromBody] JObject data)
        {
            var response = new DResult<NakliyeTombala>();

            string Barkod = data["Barkod"].ToString();
            string UreticiKodu = data["UreticiKodu"].ToString();
            string Adet = data["Adet"].ToString();
            string Bolge = data["Bolge"].ToString();
            string Plaka = data["Plaka"].ToString();
            string Sofor_Kodu = data["Sofor_Kodu"].ToString();


            int Adett;

            try
            {
                Adett = Convert.ToInt32(Adet);
            }
            catch (Exception ex)
            {
                //TODO:lOG
                response.Message = "Adet Uygun formatta girilmedi.";
                response.Success = false;


                return Ok(response);
            }


            Soforler soforler = soforlerManager.Get(x => x.Kodu == Sofor_Kodu);

            if (soforler == null)
            {
                response.Message = "Şoför bulunamadı.";
                response.Success = false;


                return Ok(response);
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
                    response.Message = "Uygun Barkod Okutulmadı.";
                    response.Success = false;


                    return Ok(response);
                }

                if (Barkod.Length < 10 || Barkod.Length > 12)
                {
                    response.Message = "Uygun Barkod Okutulmadı.";
                    response.Success = false;

                    return Ok(response);
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
                response.Message = "Geçerli bir üretici bulunamadı";
                response.Success = false;

                return Ok(response);
            }


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
                response.Message = "Başarıyla Kaydedildi.";

                return Ok(response);
            }
            else
            {
                response.Message = "Hata Oluştu.";
                response.Success = false;
            }

            return Ok(response);

        }


        string RemoveLeadingZeros(string str)
        {
            string regex = "^0+(?!$)";

            str = System.Text.RegularExpressions.Regex.Replace(str, regex, "");

            return str;
        }
    }
}