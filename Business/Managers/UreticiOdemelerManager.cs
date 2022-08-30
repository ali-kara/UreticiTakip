using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;


namespace Business.Managers
{
    public class UreticiOdemelerManager : BaseManager<URETICI_ODEMELER2, FloratediyeDBEntities>
    {
        public List<URETICI_ODEMELER2> UreticiOdemeGetir(int URETICI_ID)
        {
            List<URETICI_ODEMELER2> list = GetIEnum(x => x.URETICI_ID == URETICI_ID).OrderByDescending(x => x.URETICI_ODEME_ID).ToList();
            return list;
        }

    }
}
