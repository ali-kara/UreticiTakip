using Entities.Log.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Log.Models
{
    [Table("Duyurular")]
    public class Duyurular : BaseClass
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Numara")]
        [Key]
        public int DuyuruID { get; set; }

        [DisplayName("Başlık")]
		[Required]
        public string Baslik { get; set; }

        [DisplayName("Mesaj")]
        [DataType(DataType.MultilineText)]
		[Required]
		public string Mesaj { get; set; }

        //[DisplayName("Önem Derecesi")]
        //[DefaultValue(Priority.Normal)]
        //public Priority PriorityLevel { get; set; } = Priority.Normal;

        [Column(TypeName = "DateTime")]
        [DisplayName("Bitis Tarihi")]
        [DataType(DataType.DateTime)]
        public DateTime? BitisTarihi { get; set; }

        [DisplayName("Bölge")]
        public string Bolge { get; set; }

		[DisplayName("Duyuru Herkese mi Gönderilsin?")]
		[DefaultValue(false)]
		public bool HerkeseMi { get; set; } = false;

		[DisplayName("Onaya Sunulacak mı?")]
		[DefaultValue(true)]
		public bool OnayGerekir { get; set; } = true;

		[DisplayName("Süresi Geçmiş")]
		[DefaultValue(false)]
		public bool IsExpired { get; set; } = false;

		public virtual List<DuyurularKayit> DuyurularKayit { get; set; }
    }
}
