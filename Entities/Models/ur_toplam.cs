namespace Entities.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ur_toplam
    {
        public int id { get; set; }

        [Column(TypeName = "date")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? tarih { get; set; }

        [StringLength(10)]
        public string ur_no { get; set; }

        [StringLength(10)]
        public string tedno { get; set; }

        public decimal? toplam { get; set; }

        public decimal? koopgid { get; set; }

        public decimal? koop_gid_or { get; set; }

        public decimal? stopaj { get; set; }

        public decimal? stopaj_or { get; set; }

        public decimal? fon { get; set; }

        public decimal? fon_pay_or { get; set; }

        public decimal? bagkur { get; set; }

        public decimal? bagkur_or { get; set; }

        public decimal? hamaliye { get; set; }

        public decimal? nakliye { get; set; }

        public decimal? net { get; set; }

        public decimal? odenecek { get; set; }

        public short? depo_sira_no { get; set; }

        public decimal? borsapay { get; set; }

        public decimal? bors_pay_or { get; set; }

        public decimal? nak_zarar { get; set; }

        [StringLength(30)]
        public string il { get; set; }

        [StringLength(30)]
        public string uretici { get; set; }

        [StringLength(10)]
        public string tip { get; set; }

        [StringLength(10)]
        public string sube { get; set; }

        [StringLength(10)]
        public string tediye_yazildimi { get; set; }

        [StringLength(30)]
        public string yedek1_string { get; set; }

        public int? yedek_int { get; set; }

        public int? yedek1_int { get; set; }

        public decimal? yedek_decimal { get; set; }

        public decimal? yedek1_decimal { get; set; }
    }
}
