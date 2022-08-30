namespace Entities.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Soforler")]
    public partial class Soforler
    {
        [Key]
        public int SoforID { get; set; }

        [Required]
        [StringLength(20)]
        public string Kodu { get; set; }

        [Required]
        [StringLength(50)]
        public string Adi { get; set; }

        [Required]
        [StringLength(50)]
        public string Soyadi { get; set; }

        [StringLength(10)]
        public string Plaka { get; set; }

        [StringLength(30)]
        public string Sehir { get; set; }

        [StringLength(30)]
        public string Bolge { get; set; }

        [StringLength(20)]
        [JsonIgnore]
        public string Parola { get; set; }

        [StringLength(50)]
        public string Nakliyeci { get; set; }

        [JsonIgnore]
        public bool? Pasif { get; set; }

        [JsonIgnore]
        public DateTime? OlusturmaTarihi { get; set; }

        [JsonIgnore]
        public DateTime? GuncellemeTarihi { get; set; }

        [StringLength(20)]
        [JsonIgnore]
        public string SonGuncelleyen { get; set; }
    }
}
