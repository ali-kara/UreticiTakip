using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public partial class SubeSatis
    {
        [Key]
        public int SubeID { get; set; }

        [StringLength(20)]
        [DisplayName("Þube Adý")]
        public string SubeAdi { get; set; }

        [StringLength(10)]
        [DisplayName("Þube Adý")]
        public string SubeKisaAdi { get; set; }

        [DisplayName("Toplam Tutar")]
        public decimal? ToplamTutar { get; set; } = 0;

        [DisplayName("Ortalama")]
        public decimal? Ortalama { get; set; } = 0;

        [DisplayName("Koli Sayýsý")]
        public int ToplamKoliSayisi { get; set; }

        [DisplayName("Satýlan Koli Sayýsý")]
        public int SatilanKoliSayisi { get; set; }

        [DisplayName("Kalan Koli Sayýsý")]
        public int KalanKoliSayisi { get; set; }

        [DisplayName("Müþteri Sayýsý")]
        public int? MusteriSayisi { get; set; }

        [Column(TypeName = "date")]
        [DisplayName("Tarih")]
        public DateTime? Tarih { get; set; }

        [StringLength(250)]
        [DisplayName("Açýklama")]
        public string Aciklama { get; set; }
    }
}
