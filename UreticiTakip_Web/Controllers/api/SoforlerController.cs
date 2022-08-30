using Business.Managers;
using Entities.Models;
using Entities.Results;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace UreticiTakip_Web.Controllers.api
{
    //[Route("api/[controller]")]
    public class SoforlerController : ApiController
    {
        SoforlerManager soforlerManager { get; set; }

        public SoforlerController()
        {
            soforlerManager = new SoforlerManager();
        }

        [Route("api/sofor/getall")]
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var response = new DListResult<Soforler>();

            try
            {
                List<Soforler> list = soforlerManager.GetAll();

                response.Data = list;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            

            return Ok(response);
        }

        [Route("api/sofor/login")]
        [HttpPost]
        public IHttpActionResult Login([FromBody] JObject soforLoginDTO)
        {
            var response = new DResult<Soforler>();

            try
            {
                string SoforKodu = soforLoginDTO["SoforKodu"].ToString();
                string Parola = soforLoginDTO["Parola"].ToString();

                Soforler sofor = soforlerManager.Login(SoforKodu, Parola);


                if (sofor == null)
                {
                    response.Message = "Böyle bir şoför yok";
                    response.Success = false;
                }
                else
                {
                    response.Data = sofor;
                }


            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;

            }

            return Ok(response);

        }
    }
}


