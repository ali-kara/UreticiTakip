using Business.Managers;
using System.Web.Http;

namespace UreticiTakip_Web.Controllers.api
{
    public class GirisController : ApiController
    {
        NakliyeManager _nakliyeManager { get; set; }
        public GirisController()
        {
            _nakliyeManager = new NakliyeManager();
        }

        [HttpGet]
        [Route("api/giris/plakagetir")]
        public IHttpActionResult PlakaGet()
        {
            return Ok(_nakliyeManager.PlakalarList());
        }

        [HttpGet]
        [Route("api/giris/bolgegetir")]
        public IHttpActionResult BolgeGet()
        {
            return Ok(_nakliyeManager.BolgelerList());
        }
    }
}
