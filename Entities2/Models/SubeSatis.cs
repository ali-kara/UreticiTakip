namespace Entities2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SubeSatis
    {
        [Key]
        public int SubeID { get; set; }

        [StringLength(20)]
        public string SubeAdi { get; set; }

        [StringLength(10)]
        [DisplayName("Þube")]
        public string SubeKisaAdi { get; set; }

        [DisplayName("Toplam Tutar")]
        public decimal? ToplamTutar { get; set; }

        [DisplayName("Ortalama")]
        public decimal? Ortalama { get; set; }

        [DisplayName("Toplam Koli Sayýsý")]
        public int? ToplamKoliSayisi { get; set; }

        [DisplayName("Satýlan Koli Sayýsý")]
        public int? SatilanKoliSayisi { get; set; }

        [DisplayName("Kalan Koli Sayýsý")]
        public int? KalanKoliSayisi { get; set; }

        [DisplayName("Müþteri Sayýsý")]
        public int? MusteriSayisi { get; set; }

        [DisplayName("Tarih")]
        [Column(TypeName = "date")]
        public DateTime? Tarih { get; set; }

        [StringLength(250)]
        [DisplayName("Açýklama")]
        public string Aciklama { get; set; }
    }
}
