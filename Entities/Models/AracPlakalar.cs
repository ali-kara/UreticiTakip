namespace Entities.Models
{
    using Newtonsoft.Json;
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
