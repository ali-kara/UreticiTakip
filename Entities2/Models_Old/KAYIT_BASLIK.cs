using Entities.Abstract;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("KAYIT_BASLIK")]
    public class KAYIT_BASLIK : BaseClass
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]        
        [DisplayName("Kayıt Başlık No")]
        [Key]
        public int KAYIT_BASLIK_ID { get; set; }

        [Column(TypeName = "Date")]
        
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        [DisplayName("İşlem Tarihi")]
        public DateTime? ISLEM_TARIHI { get; set; }

        
        [DisplayName("Üretici No")]
        public int? URETICI_ID { get; set; }

        
        [DisplayName("Şube No")]
        public int? SUBE_ID { get; set; }

        
        [DisplayName("Il")]
        public string _IL { get; set; }

        
        [DisplayName("Şube Adı")]
        [StringLength(15)]
        public string _SUBE { get; set; }

        
        [DisplayName("Uretici Adı")]
        [StringLength(50)]
        public string _URETICI { get; set; }

        
        [DisplayName("Üretici NO")]
        public string _URETICI_NO { get; set; }

        
        [DisplayName("Tediye No")]
        public string TED_NO { get; set; }

        
        [DisplayName("Bağkur")]
        public decimal? BAGKUR { get; set; } = 0;

        
        [DisplayName("Bağkur Or")]
        public decimal? BAGKUR_OR { get; set; } = 0;

        
        [DisplayName("Borsa Pay")]
        public decimal? BORSA_PAY { get; set; } = 0;

        
        [DisplayName("Borsa Pay Or")]
        public decimal? BORSA_PAY_OR { get; set; } = 0;

        
        [DisplayName("Fon")]
        public decimal? FON { get; set; } = 0;

        
        [DisplayName("Fon Pay Or")]
        public decimal? FON_PAY_OR { get; set; } = 0;

        
        [DisplayName("Hamaliye")]
        public decimal? HAMALIYE { get; set; } = 0;

        
        [DisplayName("Nakliye")]
        public decimal? NAKLIYE { get; set; } = 0;

        
        [DisplayName("Nakliye Zarar")]
        public decimal? NAKLIYE_ZARAR { get; set; } = 0;

        
        [DisplayName("Koop Gider")]
        public decimal? KOOP_GID { get; set; } = 0;

        
        [DisplayName("Koop Gider Or")]
        public decimal? KOOP_GID_OR { get; set; } = 0;

        
        [DisplayName("Stopaj")]
        public decimal? STOPAJ { get; set; } = 0;

        
        [DisplayName("Stopaj Or")]
        public decimal? STOPAJ_OR { get; set; } = 0;

        
        [DisplayName("Net")]
        public decimal? NET { get; set; } = 0;

        
        [DisplayName("Ödenecek")]
        public decimal? ODENECEK { get; set; } = 0;

        
        [DisplayName("Toplam")]
        public decimal? TOPLAM { get; set; } = 0;

        
        [DisplayName("Tip")]
        [StringLength(15)]
        public string TIP { get; set; }

        
        [DisplayName("UR_TOPLAM_ID")]
        public int? UR_TOPLAM_ID { get; set; }

        
        [DisplayName("Depo Sıra No")]
        public int DEPO_SIRA_NO { get; set; }




    }
}