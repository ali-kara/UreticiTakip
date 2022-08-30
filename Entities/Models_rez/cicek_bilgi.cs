namespace Entities.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class cicek_bilgi
    {
        public int ID { get; set; }

        public short? kod { get; set; }

        [StringLength(20)]
        public string tur { get; set; }

        public short? kodu { get; set; }

        [StringLength(20)]
        public string cinsi { get; set; }

        public short? demetteki_dal_adedi { get; set; }

        public short? demet_adedi { get; set; }

        [Column(TypeName = "money")]
        public decimal? dal_icin_taban_fiyat { get; set; }

        [StringLength(10)]
        public string s_no { get; set; }
    }
}
