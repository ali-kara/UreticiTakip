using DAL.NBS;
using Entities.NBS_Models;
using Entities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Managers
{
    public class LocationManager : BaseManager<Location, NBSdb_Context>
    {
        public DResult<Location> InsertLocation(LocationInsert location)
        {
            var response = new DResult<Location>();

            try
            {
                //Insert(location);
            }
             catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;

        }

        public new DListResult<Location> GetAll()
        {
            var response = new DListResult<Location>();

            try
            {
                response.Data = context.Locations.ToList();
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;

        }
    }
}
