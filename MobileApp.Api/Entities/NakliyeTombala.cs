namespace MobileApp.Api.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("NakliyeTombala")]
    public partial class NakliyeTombala
    {
        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        public string UreticiKodu { get; set; }

        [StringLength(50)]
        public string UreticiAdiSoyadi { get; set; }

        [StringLength(20)]
        public string UreticiIli { get; set; }

        [StringLength(20)]
        public string SoforKodu { get; set; }

        [StringLength(10)]
        public string Plaka { get; set; }

        [StringLength(50)]
        public string Bolge { get; set; }

        public int? Adet { get; set; }

        public decimal? BirimFiyat { get; set; }

        public decimal? ToplamFiyat { get; set; }

        [StringLength(50)]
        public string Nakliyeci { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Tarih { get; set; }

        public bool? Pasif { get; set; }

		public DateTime? OlusturmaTarihi { get; set; } = DateTime.Now;

        public DateTime? GuncellemeTarihi { get; set; }

        [StringLength(20)]
        public string SonGuncelleyen { get; set; }
    }
}
