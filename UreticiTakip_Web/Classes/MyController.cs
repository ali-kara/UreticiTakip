using Business.Managers;
using Common.Logging;
using System.Web.Mvc;


namespace UreticiTakip_Web.Classes
{
    public class MyController : Controller
	{
		//protected CacheManager<T> cm { get; set; } = new CacheManager<T>();

		public UreticiOdemelerManager ureticiOdemelerManager { get; set; } = new UreticiOdemelerManager();
		public UreticiManager ureticiManager { get; set; } = new UreticiManager();
		public DuyuruManager duyuruManager { get; set; } = new DuyuruManager();
		public DuyurularKayitManager duyurularKayitManager { get; set; } = new DuyurularKayitManager();
		public SubeManager subeManager { get; set; } = new SubeManager();
		public UreticiKayitManager ureticiKayitManager { get; set; } = new UreticiKayitManager();
		public SoforlerManager soforlerManager { get; set; } = new SoforlerManager();
		public NakliyeManager nakliyeManager { get; set; } = new NakliyeManager();

		public RekolteManager rekolteManager { get; set; } = new RekolteManager();


	}

}