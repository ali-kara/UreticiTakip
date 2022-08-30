using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Log.Models
{
    [Table("ContactUs")]
    public class ContactUs : BaseClass
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Kayıt No")]
        public int ID { get; set; }

        [StringLength(50)]
        [Required]
        [DisplayName("Adınız Soyadınız")]
        public string AdiSoyadi { get; set; }

        [StringLength(50)]
        [EmailAddress()]
        [DisplayName("Mail Adresiniz")]
        public string Mail { get; set; }

        [DataType(DataType.PhoneNumber, ErrorMessage = "Geçersiz Telefon Numara")]
        [StringLength(50), DisplayName("Telefon Numaranız")]
        public string TelefonNo { get; set; }

        [StringLength(100)]
        [DisplayName("Konu")]
        public string Baslik { get; set; }

        [DataType(DataType.MultilineText)]
        [Required]
        [StringLength(1000)]
        [DisplayName("Mesajınız")]
        public string Mesaj { get; set; }
    }
}