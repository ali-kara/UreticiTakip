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
        [DisplayName("Kay�t No")]
        public int URETICI_ODEME_ID { get; set; }

        [Required]
        [StringLength(50)]
        [Index(IsUnique = true)]
        [DisplayName("�retici No")]
        public int URETICI_ID { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [DisplayName("Tarih")]
        public DateTime? TARIH { get; set; }

        [StringLength(200)]
        [DisplayName("�deme")]
        public string ODEME { get; set; }

        [StringLength(200)]
        [DisplayName("A��klama")]
        public string ACIKLAMA { get; set; }
    }
}
