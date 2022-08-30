using Entities.NBS_Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.NBS
{
    public class NBSdb_Context : DbContext
    {
        public NBSdb_Context() : base("NBSdbContext")
        {
            //Configuration.LazyLoadingEnabled = true;
            //Configuration.ProxyCreationEnabled = true;


            Configuration.ValidateOnSaveEnabled = false;
            Configuration.AutoDetectChangesEnabled = false;

            Database.SetInitializer(new UniDBInitializer<NBSdb_Context>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Location>().Property(x => x.latitude).HasPrecision(8,6);
            modelBuilder.Entity<Location>().Property(x => x.longitude).HasPrecision(9, 6);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Location> Locations { get; set; }
        public DbSet<SoforSessionLogs> SoforSessionLogs { get; set; }

#if DEBUG
        private class UniDBInitializer<T> : DropCreateDatabaseIfModelChanges<NBSdb_Context>
#else
		private class UniDBInitializer<T> : CreateDatabaseIfNotExists<NBSdb_Context>
#endif
        {
            protected override void Seed(NBSdb_Context db)
            {
                KullanicilariEkle(db);

                base.Seed(db);
            }

            void KullanicilariEkle(NBSdb_Context db)
            {


                //foreach (Sube item in db.Subeler.ToList())
                //{
                //	db.Set<Users>().AddIfNotExists(new Users()
                //	{
                //		Name = item.SubeKisaAdi,
                //		TcKimlikNo = item.SubeKisaAdi,
                //		Password = item.SubeKisaAdi,
                //		userType = UserType.Nakliyeci,
                //		SubeId = item.SubeID
                //	}, x => x.Name == item.SubeKisaAdi);
                //}

                //db.SaveChanges();


            }
        }
    }
}