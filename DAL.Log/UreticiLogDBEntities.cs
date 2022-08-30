using Entities.Log.Enums;
using Entities.Log.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;

namespace DAL.Log
{
	public static class DbSetExtensions
	{
		public static T AddIfNotExists<T>(this DbSet<T> dbSet, T entity, Expression<Func<T, bool>> predicate = null) where T : class, new()
		{
			var exists = predicate != null ? dbSet.Any(predicate) : dbSet.Any();
			return !exists ? dbSet.Add(entity) : null;
		}
	}

	public class UreticiLogDBEntities : DbContext
	{
		public UreticiLogDBEntities() : base("UreticiLogDBEntities")
		{
			//Configuration.LazyLoadingEnabled = true;
			//Configuration.ProxyCreationEnabled = true;


			Configuration.ValidateOnSaveEnabled = false;
			Configuration.AutoDetectChangesEnabled = false;

			Database.SetInitializer(new UniDBInitializer<UreticiLogDBEntities>());
		}

		protected override void Dispose(bool disposing)
		{
			//Configuration.LazyLoadingEnabled = false;
			base.Dispose(disposing);
		}

		public DbSet<Country> Country { get; set; }
		public DbSet<Sube> Subeler { get; set; }
		public DbSet<ContactUs> ContactUs { get; set; }
		public DbSet<WebExceptionLogs> WebExceptionLogs { get; set; }
		public DbSet<Users> Kullanicilar { get; set; }
		public DbSet<Duyurular> Duyurular { get; set; }
		public DbSet<DuyurularKayit> DuyurularKayit { get; set; }




#if DEBUG
		private class UniDBInitializer<T> : DropCreateDatabaseIfModelChanges<UreticiLogDBEntities>
#else
		private class UniDBInitializer<T> : CreateDatabaseIfNotExists<UreticiLogDBEntities>
#endif
		{
			protected override void Seed(UreticiLogDBEntities db)
			{
				CountryiEkle(db);
				SubeleriEkle(db);
				KullanicilariEkle(db);

				base.Seed(db);
			}

			void CountryiEkle(UreticiLogDBEntities db)
			{
				db.Country.AddOrUpdate(p => p.CountryName,
						new Country { CountryName = "ADANA" },
						new Country { CountryName = "ADIYAMAN" },
						new Country { CountryName = "AFYON" },
						new Country { CountryName = "AĞRI" },
						new Country { CountryName = "AMASYA" },
						new Country { CountryName = "ANKARA" },
						new Country { CountryName = "ANTALYA" },
						new Country { CountryName = "ARTVİN" },
						new Country { CountryName = "AYDIN" },
						new Country { CountryName = "BALIKESİR" },
						new Country { CountryName = "BİLECİK" },
						new Country { CountryName = "BİNGÖL" },
						new Country { CountryName = "BİTLİS" },
						new Country { CountryName = "BOLU" },
						new Country { CountryName = "BURDUR" },
						new Country { CountryName = "BURSA" },
						new Country { CountryName = "ÇANAKKALE" },
						new Country { CountryName = "ÇANKIRI" },
						new Country { CountryName = "ÇORUM" },
						new Country { CountryName = "DENİZLİ" },
						new Country { CountryName = "DİYARBAKIR" },
						new Country { CountryName = "EDİRNE" },
						new Country { CountryName = "ELAZIĞ" },
						new Country { CountryName = "ERZİNCAN" },
						new Country { CountryName = "ERZURUM" },
						new Country { CountryName = "ESKİŞEHİR" },
						new Country { CountryName = "GAZİANTEP" },
						new Country { CountryName = "GİRESUN" },
						new Country { CountryName = "GÜMÜŞHANE" },
						new Country { CountryName = "HAKKARİ" },
						new Country { CountryName = "HATAY" },
						new Country { CountryName = "ISPARTA" },
						new Country { CountryName = "MERSİN" },
						new Country { CountryName = "İSTANBUL" },
						new Country { CountryName = "İZMİR" },
						new Country { CountryName = "KARS" },
						new Country { CountryName = "KASTAMONU" },
						new Country { CountryName = "KAYSERİ" },
						new Country { CountryName = "KIRKLARELİ" },
						new Country { CountryName = "KIRŞEHİR" },
						new Country { CountryName = "KOCAELİ" },
						new Country { CountryName = "KONYA" },
						new Country { CountryName = "KÜTAHYA" },
						new Country { CountryName = "MALATYA" },
						new Country { CountryName = "MANİSA" },
						new Country { CountryName = "KAHRAMANMARAŞ" },
						new Country { CountryName = "MARDİN" },
						new Country { CountryName = "MUĞLA" },
						new Country { CountryName = "MUŞ" },
						new Country { CountryName = "NEVŞEHİR" },
						new Country { CountryName = "NİĞDE" },
						new Country { CountryName = "ORDU" },
						new Country { CountryName = "RİZE" },
						new Country { CountryName = "SAKARYA" },
						new Country { CountryName = "SAMSUN" },
						new Country { CountryName = "SİİRT" },
						new Country { CountryName = "SİNOP" },
						new Country { CountryName = "SİVAS" },
						new Country { CountryName = "TEKİRDAĞ" },
						new Country { CountryName = "TOKAT" },
						new Country { CountryName = "TRABZON" },
						new Country { CountryName = "TUNCELİ" },
						new Country { CountryName = "ŞANLIURFA" },
						new Country { CountryName = "UŞAK" },
						new Country { CountryName = "VAN" },
						new Country { CountryName = "YOZGAT" },
						new Country { CountryName = "ZONGULDAK" },
						new Country { CountryName = "AKSARAY" },
						new Country { CountryName = "BAYBURT" },
						new Country { CountryName = "KARAMAN" },
						new Country { CountryName = "KIRIKKALE" },
						new Country { CountryName = "BATMAN" },
						new Country { CountryName = "ŞIRNAK" },
						new Country { CountryName = "BARTIN" },
						new Country { CountryName = "ARDAHAN" },
						new Country { CountryName = "IĞDIR" },
						new Country { CountryName = "YALOVA" },
						new Country { CountryName = "KARABÜK" },
						new Country { CountryName = "KİLİS" },
						new Country { CountryName = "OSMANİYE" },
						new Country { CountryName = "DÜZCE" }
					);

				db.SaveChanges();
			}
			void KullanicilariEkle(UreticiLogDBEntities db)
			{

				db.Set<Users>().AddIfNotExists(new Users()
				{
					Name = "Ali",
					Surname = "Kara",
					TcKimlikNo = "123456",
					Password = "123456",
					PhoneNumber = "05066311256",
					userType = UserType.Admin
				}, x => x.Name == "Ali");

				foreach (Sube item in db.Subeler.ToList())
				{
					db.Set<Users>().AddIfNotExists(new Users()
					{
						Name = item.SubeKisaAdi,
						TcKimlikNo = item.SubeKisaAdi,
						Password = item.SubeKisaAdi,
						userType = UserType.Nakliyeci,
						SubeId = item.SubeID
					}, x => x.Name == item.SubeKisaAdi);
				}

				db.SaveChanges();


			}
			void SubeleriEkle(UreticiLogDBEntities db)
			{
				db.Subeler.AddRange(new List<Sube>
				{
					new Sube
					{
						SubeAdi = "Ayazağa",
						SubeKisaAdi = "AYZ",
						CountryID = db.Country.Where(x => x.CountryName == "İSTANBUL").FirstOrDefault().CountryID,
						SonGuncelleyen = "Admin"
					},
					new Sube
					{
						SubeAdi = "Bayrampaşa",
						SubeKisaAdi = "BYR",
						CountryID = db.Country.Where(x => x.CountryName == "İSTANBUL").FirstOrDefault().CountryID,
						SonGuncelleyen = "Admin"
					},
					new Sube
					{
						SubeAdi = "Kadıköy",
						SubeKisaAdi = "KAD",
						CountryID = db.Country.Where(x => x.CountryName == "İSTANBUL").FirstOrDefault().CountryID,
						SonGuncelleyen = "Admin"
					},
					new Sube
					{
						SubeAdi = "Çorlu",
						SubeKisaAdi = "COR",
						CountryID = db.Country.Where(x => x.CountryName == "TEKİRDAĞ").FirstOrDefault().CountryID,
						SonGuncelleyen = "Admin"
					},
					new Sube
					{
						SubeAdi = "İzmir",
						SubeKisaAdi = "IZM",
						CountryID = db.Country.Where(x => x.CountryName == "İZMİR").FirstOrDefault().CountryID,
						SonGuncelleyen = "Admin"
					},
					new Sube
					{
						SubeAdi = "İzmir İh.",
						SubeKisaAdi = "IZMIH",
						CountryID = db.Country.Where(x => x.CountryName == "İZMİR").FirstOrDefault().CountryID,
						SonGuncelleyen = "Admin"
					},
					new Sube
					{
						SubeAdi = "İzmir Tp.",
						SubeKisaAdi = "IZMTP",
						CountryID = db.Country.Where(x => x.CountryName == "İZMİR").FirstOrDefault().CountryID,
						SonGuncelleyen = "Admin"
					},
					new Sube
					{
						SubeAdi = "Yalova",
						SubeKisaAdi = "YAL",
						CountryID = db.Country.Where(x => x.CountryName == "YALOVA").FirstOrDefault().CountryID,
						SonGuncelleyen = "Admin"
					},
					new Sube
					{
						SubeAdi = "Yalova İh.",
						SubeKisaAdi = "YALIH",
						CountryID = db.Country.Where(x => x.CountryName == "YALOVA").FirstOrDefault().CountryID,
						SonGuncelleyen = "Admin"
					},
					new Sube
					{
						SubeAdi = "Antalya",
						SubeKisaAdi = "ANT",
						CountryID = db.Country.Where(x => x.CountryName == "ANTALYA").FirstOrDefault().CountryID,
						SonGuncelleyen = "Admin"
					},
					new Sube
					{
						SubeAdi = "Antalya İh.",
						SubeKisaAdi = "ANTIH",
						CountryID = db.Country.Where(x => x.CountryName == "ANTALYA").FirstOrDefault().CountryID,
						SonGuncelleyen = "Admin"
					},
					new Sube
					{
						SubeAdi = "Antalya Tp.",
						SubeKisaAdi = "ANTTP",
						CountryID = db.Country.Where(x => x.CountryName == "ANTALYA").FirstOrDefault().CountryID,
						SonGuncelleyen = "Admin"
					},
					new Sube
					{
						SubeAdi = "Ankara",
						SubeKisaAdi = "ANK",
						CountryID = db.Country.Where(x => x.CountryName == "ANKARA").FirstOrDefault().CountryID,
						SonGuncelleyen = "Admin"
					},
					new Sube
					{
						SubeAdi = "Trabzon",
						SubeKisaAdi = "TRZ",
						CountryID = db.Country.Where(x => x.CountryName == "TRABZON").FirstOrDefault().CountryID,
						SonGuncelleyen = "Admin"
					},
					new Sube
					{
						SubeAdi = "Gaziantep",
						SubeKisaAdi = "GAN",
						CountryID = db.Country.Where(x => x.CountryName == "GAZİANTEP").FirstOrDefault().CountryID,
						SonGuncelleyen = "Admin"
					},
					new Sube
					{
						SubeAdi = "Konya",
						SubeKisaAdi = "KON",
						CountryID = db.Country.Where(x => x.CountryName == "KONYA").FirstOrDefault().CountryID,
						SonGuncelleyen = "Admin"
					},
					new Sube
					{
						SubeAdi = "Eskişehir",
						SubeKisaAdi = "ESK",
						CountryID = db.Country.Where(x => x.CountryName == "ESKİŞEHİR").FirstOrDefault().CountryID,
						SonGuncelleyen = "Admin"
					},
					new Sube
					{
						SubeAdi = "Mersin",
						SubeKisaAdi = "MER",
						CountryID = db.Country.Where(x => x.CountryName == "MERSİN").FirstOrDefault().CountryID,
						SonGuncelleyen = "Admin"
					},
					new Sube
					{
						SubeAdi = "Adana",
						SubeKisaAdi = "ADN",
						CountryID = db.Country.Where(x => x.CountryName == "ADANA").FirstOrDefault().CountryID,
						SonGuncelleyen = "Admin"
					},
					new Sube
					{
						SubeAdi = "Kocaeli",
						SubeKisaAdi = "KOC",
						CountryID = db.Country.Where(x => x.CountryName == "KOCAELİ").FirstOrDefault().CountryID,
						SonGuncelleyen = "Admin"
					},
					new Sube
					{
						SubeAdi = "Samsun",
						SubeKisaAdi = "SAM",
						CountryID = db.Country.Where(x => x.CountryName == "SAMSUN").FirstOrDefault().CountryID,
						SonGuncelleyen = "Admin"
					},
					new Sube
					{
						SubeAdi = "Bursa",
						SubeKisaAdi = "BUR",
						CountryID = db.Country.Where(x => x.CountryName == "BURSA").FirstOrDefault().CountryID,
						SonGuncelleyen = "Admin"
					},
			});

				db.SaveChanges();
			}
		}
	}
}