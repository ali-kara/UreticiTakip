namespace Entities.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AracPlakalar")]
    public partial class AracPlakalar
    {
        [Key]
        public int PlakaId { get; set; }

        [Required]
        [StringLength(10)]
        public string Plaka { get; set; }

        [StringLength(50)]
        public string Aciklama { get; set; }

        public bool? Pasif { get; set; }

        public DateTime? OlusturmaTarihi { get; set; }

        public DateTime? GuncellemeTarihi { get; set; }

        [StringLength(20)]
        public string SonGuncelleyen { get; set; }
    }
}
