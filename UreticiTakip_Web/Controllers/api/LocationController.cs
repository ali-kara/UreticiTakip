using Business.Managers;
using Entities.NBS_Models;
using Entities.Results;
using Newtonsoft.Json.Linq;
using System;
using System.Web.Http;

namespace UreticiTakip_Web.Controllers.api
{
    public class LocationController : ApiController
    {
        LocationManager locationManager { get; set; }
        public LocationController()
        {
            locationManager = new LocationManager();
        }

        [HttpGet]
        [Route("api/location/getall")]
        public IHttpActionResult GetAll()
        {
            DListResult<Location> response = new DListResult<Location>();

            try
            {
                response= locationManager.GetAll();
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return Ok(response);
            
        }

        [HttpPost]
        [Route("api/location/insert")]
        public IHttpActionResult Insert([FromBody] LocationInsert locationInsert)
        {
            var response = new DResult<Location>();

            try
            {
                var ins = new Location();

                decimal lat, lon;

                //if (decimal.TryParse(locationInsert["latitude"].ToString(), out lat))
                //{
                //    ins.latitude = lat;
                //}

                //if (decimal.TryParse(locationInsert["longitude"].ToString(), out lon))
                //{
                //    ins.longitude = lon;
                //}

                //ins.SoforKodu = locationInsert["SoforKodu"].ToString();

                response = locationManager.InsertLocation(locationInsert);

            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.StackTrace;

            }

            return Ok(response);

        }



    }
}