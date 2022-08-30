using Common.Logging;
using Entities.Log.Models;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Web.Mvc;

using UreticiTakip_Web.Classes;
using UreticiTakip_Web.Filters;

namespace UreticiTakip_Web.Controllers
{
    public class DefaultController : MyController
    {

        public ActionResult Index()
        {
            return View();
        }

        [Uretici]
        public ActionResult Subeler()
        {
            List<SubeSatis> list = subeManager.GetAll();

            return View(list);
        }

        public ActionResult Hata()
        {
            return View();
        }
        public ActionResult Yardim()
        {
            return View();
        }

        public ActionResult BizeYazin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult BizeYazin(ContactUs model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //db.ContactUs.Add(model);
                    //db.SaveChanges();

                    //if (await MailAt(model))
                    //{
                    //    ViewBag.Result = "Mailiniz İletilmiştir. Teşekkür Ederiz.";
                    //    ViewBag.Status = "success";

                    //    ModelState.Clear();
                    //    return View(new ContactUs());
                    //}
                    //else
                    //{
                    //    ViewBag.Result = "Mesaj İletilirken Problem Oluştu. Lütfen Daha Sonra Tekrar Deneyiniz.";
                    //    ViewBag.Status = "danger";
                    //}
                }
                catch (Exception ex)
                {
                    // Logging.Logla(ex);

                    ViewBag.Result = "Mesaj İletilirken Problem Oluştu. Lütfen Daha Sonra Tekrar Deneyiniz.";
                    ViewBag.Status = "danger";
                }
            }

            return View(model);
        }


        public bool MailAt(ContactUs model)
        {
            // Mail Atma Kısmı
            var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";

            var message = new MailMessage();
            message.To.Add(new MailAddress("alikara658@gmail.com"));  // replace with valid value 
            message.From = new MailAddress("alikara06@outlook.com");  // replace with valid value
            message.Subject = "(Bize Yazin)-> " + model.Baslik;
            message.Body = string.Format(body, model.AdiSoyadi, model.Mail, model.Mesaj);
            message.IsBodyHtml = true;

            using (var smtp = new SmtpClient())
            {
                try
                {
                    var credential = new NetworkCredential
                    {
                        UserName = "alikara06@outlook.com",
                        Password = "Ali1905@"
                    };

                    smtp.Credentials = credential;
                    smtp.Host = "smtp-mail.outlook.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    smtp.SendMailAsync(message);

                    return true;
                }
                catch (Exception ex)
                {
                    Log.Log2Txt(ex);
                    return false;
                }
            }
        }
    }
}