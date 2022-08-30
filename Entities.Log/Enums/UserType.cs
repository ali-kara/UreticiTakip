using System.ComponentModel;

namespace Entities.Log.Enums
{
	public enum UserType
	{
		[Description("Sistem Yöneticisi")]
		Admin = 0,
		[Description("Üretici")]
		Üretici = 1,
		[Description("Nakliyeci")]
		Nakliyeci = 2,
		[Description("Mezat Görevlisi")]
		MezatGorevlisi = 3,
	}
}
