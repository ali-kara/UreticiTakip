using System.ComponentModel;

namespace Entities.Log.Enums
{
	public enum SubeTuru
	{
		[Description("İç Piyasa")]
		IC_PIYASA = 0,
		[Description("İhracat")]
		IHRACAT = 1,
		[Description("Toptan")]
		TOPTAN = 2,
	}
}
