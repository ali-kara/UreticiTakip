using Entities.Log.Models;
using Entities.Models;
using System.Collections.Generic;

namespace Entities.ViewModels
{
    public class vmDuyurularIndex
    {
        // Tablo Ba�l�klar� i�in
        public KAYIT_BASLIK dummy { get; set; }
        public List<ur_toplam> ur_toplam { get; set; }
        public List<Duyurular> Duyurular { get; set; }
    }
}