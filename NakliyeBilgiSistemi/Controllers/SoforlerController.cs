using Business.Managers;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NakliyeBilgiSistemi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SoforlerController : ControllerBase
    {
		SoforlerManager soforlerManager;

		public SoforlerController()
        {
			soforlerManager = new SoforlerManager();
        }

        public IActionResult Login(string Kodu, string Password)
		{
			if (Kodu == string.Empty || Password == string.Empty)
            {
				return BadRequest("Kullanıcı Adı veya Şifre Boş Olamaz.");
			}


			Soforler sofor = soforlerManager.Login(Kodu, Password);

			if (sofor == null)
			{
				return Unauthorized("Geçersiz Kullanıcı Adı veya Şifre");
			}


			return Ok("GirisBilgi");
		}
	}
}
