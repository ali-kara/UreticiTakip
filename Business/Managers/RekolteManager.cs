using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Managers
{
    public class RekolteManager : BaseManager<rekolte, FloratediyeDBEntities>
    {
        public bool RekolteVarmi(int UreticiID)
        {
            List<rekolte> list = GetList(x => x.ur_no == UreticiID && x.sezon == DateTime.Now.Year.ToString()).ToList();

            if (list != null && list.Count != 0)
            {
                return true;
            }

            return false;
        }
    }
}
