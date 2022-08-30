namespace Entities.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class URETICI_ODEMELER2
    {
        [Key]
        public int URETICI_ODEME_ID { get; set; }

        public int URETICI_ID { get; set; }

        public DateTime? TARIH { get; set; }

        [StringLength(50)]
        public string ODEME { get; set; }

        [StringLength(50)]
        public string ACIKLAMA { get; set; }

        public DateTime? OlusturmaTarihi { get; set; }

        public DateTime? GuncellemeTarihi { get; set; }

        [StringLength(20)]
        public string SonGuncelleyen { get; set; }

        public bool? Pasif { get; set; }
    }
}
