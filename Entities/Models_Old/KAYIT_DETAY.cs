using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Entities.Models
{
    [DataContract(IsReference = true)]
    public class KAYIT_DETAY : BaseClass
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        
        [DisplayName("Kayıt Detay No")]
        [Key]
        public int KAYIT_DETAY_ID { get; set; }

        
        [DisplayName("Kayıt Başlık No")]
        public int KAYIT_BASLIK_ID { get; set; }

        
        [DisplayName("Çiçek Adı")]
        public string CICEK_ADI { get; set; }

        
        [DisplayName("Demet")]
        public int? DEMET { get; set; }

        
        [DisplayName("Kalem No")]
        public int? KALEM_NO { get; set; }

        
        [DisplayName("Adet")]
        public int? ADET { get; set; }

        
        [DisplayName("Satış Fiyatı")]
        public decimal? ALICI_TUTAR { get; set; }

        
        [DisplayName("Birim Fiyat")]
        [StringLength(20)]
        public string ALICI_KODU { get; set; }

        
        [DisplayName("Alıcı Sandalye")]
        public int? ALICI_SAND { get; set; }

        
        [DisplayName("Fatura Yaz")]
        [StringLength(10)]
        public string FATURA_YAZ { get; set; }

        
        [DisplayName("Tediye Yaz")]
        [StringLength(10)]
        public string TEDIYE_YAZ { get; set; }

        
        [DisplayName("Depo Sıra No")]
        public int? DEPO_SIRA_NO { get; set; }

        
        [DisplayName("Sıra No")]
        public int? SIRA_NO { get; set; }

        
        [DisplayName("Satış Tablo No")]
        public int? satis_id { get; set; }
    }
}