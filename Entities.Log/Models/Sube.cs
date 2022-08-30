using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Entities.Log.Models
{
    [Table("Sube")]
    public class Sube : BaseClass
    { 
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), DisplayName("Şube No")]
        public int SubeID { get; set; }

        [StringLength(50), Required, DisplayName("Şube Adı")]
        public string SubeAdi { get; set; }

        [StringLength(10), DisplayName("Şube Kısa Adı")]
        public string SubeKisaAdi { get; set; }

        [StringLength(250)]
        [DisplayName("Açıklama")]
        public string Aciklama { get; set; }

        public int CountryID { get; set; }

        public virtual Country il { get; set; }
    }
}