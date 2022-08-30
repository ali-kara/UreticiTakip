using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace Entities2.Abstract
{
	[DebuggerStepThrough]
	public class BaseClass
	{
		[DisplayName("Pasif")]
		[ScaffoldColumn(false)]
		public bool? Pasif { get; set; } = false;

		[DisplayName("Oluşturma Tarihi")]
		[DisplayFormat(DataFormatString = "{0:dd-MM-yyyy HH:mm:ss}", ApplyFormatInEditMode = true)]
		[ScaffoldColumn(false)]
		public DateTime? OlusturmaTarihi { get; set; } = DateTime.Now;

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