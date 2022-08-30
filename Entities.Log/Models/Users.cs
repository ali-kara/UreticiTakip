using Entities.Log.Enums;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Log.Models
{


	[Table("Users")]
    public class Users : BaseClass
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Kullanıcı ID")]
        [Key]
        public int UserID { get; set; }

        [DisplayName("Şube No")]
        public int? SubeId { get; set; }

        [DisplayName("Adı")]
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [DisplayName("Soyadı")]
        [StringLength(50)]
        public string Surname { get; set; }

        [DisplayName("TC Kimlik No")]
        [MaxLength(11)]
        [Required]
        public string TcKimlikNo { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Doğum Tarihi")]
        public DateTime? DateOfBirth { get; set; }

        [DisplayName("Telefon Numarası")]
        public string PhoneNumber { get; set; }

        [DataType(DataType.Password)]
        [DisplayName("Şifre")]
        public string Password { get; set; }

        [DisplayName("Onaylı")]
        public bool IsApproved { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Onay Tarihi")]
        public DateTime? ApproveDate { get; set; }

        [DisplayName("Bloke")]
        public bool IsBlocked { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Bloke Tarihi")]
        public DateTime? BlockDate { get; set; }

        [DisplayName("Kullanıcı Yetkisi")]
        public UserType userType { get; set; }

        public virtual Sube sube { get; set; }
    }
}