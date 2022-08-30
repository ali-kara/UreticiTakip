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
        [DisplayName("�ube Ad�")]
        public string SubeAdi { get; set; }

        [StringLength(10)]
        [DisplayName("�ube Ad�")]
        public string SubeKisaAdi { get; set; }

        [DisplayName("Toplam Tutar")]
        public decimal? ToplamTutar { get; set; } = 0;

        [DisplayName("Ortalama")]
        public decimal? Ortalama { get; set; } = 0;

        [DisplayName("Koli Say�s�")]
        public int ToplamKoliSayisi { get; set; }

        [DisplayName("Sat�lan Koli Say�s�")]
        public int SatilanKoliSayisi { get; set; }

        [DisplayName("Kalan Koli Say�s�")]
        public int KalanKoliSayisi { get; set; }

        [DisplayName("M��teri Say�s�")]
        public int? MusteriSayisi { get; set; }

        [Column(TypeName = "date")]
        [DisplayName("Tarih")]
        public DateTime? Tarih { get; set; }

        [StringLength(250)]
        [DisplayName("A��klama")]
        public string Aciklama { get; set; }
    }
}
