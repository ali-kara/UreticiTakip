namespace MobileApp.Api.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Bolgeler")]
    public partial class Bolgeler
    {
        [Key]
        public int BolgeId { get; set; }

        [Required]
        [StringLength(10)]
        public string BolgeAdi { get; set; }

        [StringLength(50)]
        public string Aciklama { get; set; }

        public bool? Pasif { get; set; }

        public DateTime? OlusturmaTarihi { get; set; }

        public DateTime? GuncellemeTarihi { get; set; }

        [StringLength(20)]
        public string SonGuncelleyen { get; set; }
    }
}
