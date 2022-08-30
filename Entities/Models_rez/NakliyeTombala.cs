using Entities.Abstract;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("NakliyeTombala")]
    public partial class NakliyeTombala : BaseClass
    {
        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        [DisplayName("�retici Kodu")]
        public string UreticiKodu { get; set; }

        [StringLength(50)]
        [DisplayName("�retici Ad�")]
        public string UreticiAdiSoyadi { get; set; }

        [StringLength(20)]
        [DisplayName("�retici �li")]
        public string UreticiIli { get; set; }

        [StringLength(20)]
        [DisplayName("�of�r Kodu")]
        public string SoforKodu { get; set; }

        [StringLength(10)]
        [DisplayName("Plaka")]
        public string Plaka { get; set; }

        [StringLength(50)]
        [DisplayName("B�lge")]
        public string Bolge { get; set; }

        [DisplayName("Adet")]
        public int? Adet { get; set; }

        public decimal? BirimFiyat { get; set; }

        public decimal? ToplamFiyat { get; set; }

        [StringLength(50)]
        public string Nakliyeci { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Tarih { get; set; } = DateTime.Now;
    }
}
