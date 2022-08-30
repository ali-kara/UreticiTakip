using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace Entities.Models
{
    public partial class URETICI_ODEMELER2
    {
        [Key]
        [DisplayName("Kayýt No")]
        public int URETICI_ODEME_ID { get; set; }

        [Required]
        [StringLength(50)]
        [Index(IsUnique = true)]
        [DisplayName("Üretici No")]
        public int URETICI_ID { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [DisplayName("Tarih")]
        public DateTime? TARIH { get; set; }

        [StringLength(200)]
        [DisplayName("Ödeme")]
        public string ODEME { get; set; }

        [StringLength(200)]
        [DisplayName("Açýklama")]
        public string ACIKLAMA { get; set; }
    }
}
