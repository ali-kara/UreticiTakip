using Entities.Abstract;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("URETICILER")]
    public partial class URETICILER
    {
        [Key]
        public int URETICI_ID { get; set; }

        [Required]
        //[StringLength(50)]
        [DisplayName("Üretici No")]
        public string URETICI_NO { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Adý")]
        public string ADI { get; set; }

        [StringLength(50)]
        [DisplayName("Soyadý")]
        public string SOYADI { get; set; }

		[StringLength(11)]
		[DisplayName("TC Kimlik No")]
        //[DisplayFormat(NullDisplayText = "-")]
        public string TCKIMLIK_NO { get; set; }

        //[DataType(DataType.Date)]
		[DisplayName("Doðum Tarihi")]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
		public DateTime? DOGUM_TARIHI { get; set; }

        [StringLength(50)]
		[DisplayName("Doðum Yeri")]
        public string DOGUM_YERI { get; set; }

        [StringLength(20)]
		[DisplayName("Cep Telefonu")]
		//[DataType(DataType.PhoneNumber)]
		public string CEP_TELEFONU { get; set; }

        [StringLength(100)]
        [DisplayName("E-mail Adresi")]
		//[DataType(DataType.EmailAddress)]
		public string EMAIL { get; set; }

        [StringLength(30)]
		[DisplayName("Ýl")]
        public string IL { get; set; }

        [StringLength(200)]
        [DisplayName("Adres")]
        public string ADRES { get; set; }

        [StringLength(50)]
		[DisplayName("Doðum Yeri")]
        public string BAGKUR_NO { get; set; }

		[StringLength(10)]
		public string Parola { get; set; }


        [StringLength(10)]
        [DisplayName("Yetki")]
        public string Yetki { get; set; }

        public bool? Pasif { get; set; }

        public DateTime? OlusturmaTarihi { get; set; }

        public DateTime? GuncellemeTarihi { get; set; }

        [StringLength(20)]
        public string SonGuncelleyen { get; set; }

    }
}
