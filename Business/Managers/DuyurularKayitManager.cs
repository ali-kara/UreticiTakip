using DAL.Log;
using Entities.Log.Models;
using System.Linq;

namespace Business.Managers
{
	public class DuyurularKayitManager : BaseManager<DuyurularKayit, UreticiLogDBEntities>
    {
        public bool DuyuruOnayla(string UreticiNo, int DuyuruID)
        {
            Duyurular d = context.Duyurular.Where(x => x.DuyuruID == DuyuruID).FirstOrDefault();

            Insert(new DuyurularKayit
            {
                DuyuruID = DuyuruID,
                UreticiNo = UreticiNo,
                Onaylandi = true,
                SonGuncelleyen = UreticiNo,
                Baslik = d.Baslik,
                Mesaj = d.Mesaj
            });

            return true;
        }
    }
}
