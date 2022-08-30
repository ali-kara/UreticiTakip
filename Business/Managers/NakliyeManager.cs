using DAL.Log;
using Entities;
using Entities.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Managers
{
    public class NakliyeManager : BaseManager<NakliyeTombala, FloratediyeDBEntities>
    {

        public List<AracPlakalar> PlakalarList()
        {
            List<AracPlakalar> list = new List<AracPlakalar>();
            list = context.AracPlakalar.ToList();
            return list;
        }

        public List<Bolgeler> BolgelerList()
        {
            List<Bolgeler> list = new List<Bolgeler>();
            list = context.Bolgeler.ToList();
            return list;
        }

        public List<NakliyeTombala> TombalaGetir(string SoforKodu, string Bolge, string Plaka)
        {
            list = GetList(x => x.SoforKodu == SoforKodu
            && x.Bolge == Bolge
            && x.Plaka == Plaka
            && x.Pasif != true
            && DbFunctions.TruncateTime(x.OlusturmaTarihi.Value) == DbFunctions.TruncateTime(DateTime.Now)).OrderByDescending(x => x.OlusturmaTarihi).ToList();

            return list;
        }

        public bool TombalaKaydet(NakliyeTombala nakliyeTombala)
        {
            Insert(nakliyeTombala);
            return true;
        }

        public bool TombalaSil(int id)
        {
            NakliyeTombala nakliye = Get(x => x.Id == id);
            nakliye.Pasif = true;
            nakliye.GuncellemeTarihi = DateTime.Now;

            Update(nakliye);

            return true;
        }
    }
}
