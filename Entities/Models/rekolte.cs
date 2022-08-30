using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace Entities.Models
{
    [Table("rekolte")]
    public partial class rekolte
    {
        [Key]
        public int rekolte_id { get; set; }

        public int? ur_no { get; set; }

        [StringLength(50)]
        public string unvani { get; set; }

        [StringLength(15)]
        public string sezon { get; set; }

        [StringLength(50)]
        public string cesit { get; set; }

        [StringLength(50)]
        public string alan { get; set; }

        [Column(TypeName = "money")]
        public decimal? miktar_sogan { get; set; }

        [Column("rekolte", TypeName = "money")]
        public decimal? rekolte1 { get; set; }

        public int? cic_kodu_sogan { get; set; }

        [StringLength(50)]
        public string urun_cinsi_sogan { get; set; }

        public int? ay { get; set; }

        [Column(TypeName = "money")]
        public decimal? miktar_cicek { get; set; }

        public int? cic_kodu_cicek { get; set; }

        [StringLength(50)]
        public string urun_cinsi_cicek { get; set; }

        [StringLength(10)]
        public string ay_adi { get; set; }

        public short? cic_ana_kod { get; set; }

        [StringLength(20)]
        public string cic_tur { get; set; }
    }
}
