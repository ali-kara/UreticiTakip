using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace Entities.Log
{
    [DebuggerStepThrough]
	public class BaseClass
    {
        //[DisplayName("{0} No")]
        //[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int Id { get; set; }

        [DisplayName("Pasif")]
        [ScaffoldColumn(false)]
        public bool? Pasif { get; set; } = false;

        [DataType(DataType.DateTime)]
        [DisplayName("Oluşturma Tarihi")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy HH:mm:ss}", ApplyFormatInEditMode = true)]
        [ScaffoldColumn(false)]
        public DateTime? OlusturmaTarihi { get; set; } = DateTime.Now;

        [DataType(DataType.DateTime)]
        [DisplayName("Güncelleme Tarihi")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy HH:mm:ss}", ApplyFormatInEditMode = true)]
        [ScaffoldColumn(false)]
        public DateTime? GuncellemeTarihi { get; set; }

        [DisplayName("Son Güncelleyen")]
        [ScaffoldColumn(false)]
        [StringLength(20)]
        public string SonGuncelleyen { get; set; }
    }
}