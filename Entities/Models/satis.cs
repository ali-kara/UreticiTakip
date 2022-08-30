namespace Entities.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class satis
    {
        public int id { get; set; }

        public short? sira_no { get; set; }

        public short? cic_kod { get; set; }

        [StringLength(20)]
        public string cic_adi { get; set; }

        public short? cic_demet { get; set; }

        public short? cic_adet { get; set; }

        [StringLength(10)]
        public string uretici_kodu { get; set; }

        [StringLength(30)]
        public string uretici_adi { get; set; }

        public decimal? satis_fiyat { get; set; }

        public short? alici_sand { get; set; }

        [StringLength(10)]
        public string alici_kodu { get; set; }

        public short? d_s_no { get; set; }

        public short? s_no { get; set; }

        [Column(TypeName = "date")]
        public DateTime? tarih { get; set; }

        public decimal? toplam_tutar { get; set; }

        public short? cic_ana_kod { get; set; }

        [StringLength(20)]
        public string cic_tur { get; set; }

        [StringLength(10)]
        public string sube { get; set; }

        [StringLength(30)]
        public string yedek_string { get; set; }

        [StringLength(30)]
        public string yedek1_string { get; set; }

        public int? yedek_int { get; set; }

        public int? yedek1_int { get; set; }

        public decimal? yedek_decimel { get; set; }

        public decimal? yedek1_decimal { get; set; }
    }
}
