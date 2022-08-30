using Entities.Log.Abstract;
using Entities.Log.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Log.ViewModels
{
    public class vmUreticiDuyurularim : BaseViewModel
    {
        [DisplayName("Başlık")]
        public string Baslik { get; set; }
        [DisplayName("Mesaj")]
        public string Mesaj { get; set; }
        [DisplayName("Duyuru Tarihi")]
        public DateTime DuyuruTarihi { get; set; }
        [DisplayName("Onay Tarihi")]
        public DateTime? OnayTarihi { get; set; }
    }

}
