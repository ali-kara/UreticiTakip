using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace Entities.Models
{
    internal sealed class Configuration : DbMigrationsConfiguration<FloratediyeDBEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(FloratediyeDBEntities context)
        {
            //base.Seed(context);
        }


    }



    public partial class FloratediyeDBEntities : DbContext
    {
        public FloratediyeDBEntities() : base("FloratediyeDB")
        {
            
        }

        public FloratediyeDBEntities(string ConnString) : base(ConnString)
        {

        }

        public virtual DbSet<AracPlakalar> AracPlakalar { get; set; }
        public virtual DbSet<Bolgeler> Bolgeler { get; set; }
        public virtual DbSet<cicek_bilgi> cicek_bilgi { get; set; }
        public virtual DbSet<NakliyeTombala> NakliyeTombala { get; set; }
        public virtual DbSet<rekolte> rekolte { get; set; }
        public virtual DbSet<satis> satis { get; set; }
        public virtual DbSet<Soforler> Soforler { get; set; }
        public virtual DbSet<SubeSatis> SubeSatis { get; set; }
        public virtual DbSet<ur_toplam> ur_toplam { get; set; }
        public virtual DbSet<URETICI_ODEMELER2> URETICI_ODEMELER2 { get; set; }
        public virtual DbSet<URETICILER> URETICILER { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<cicek_bilgi>()
                .Property(e => e.tur)
                .IsFixedLength();

            modelBuilder.Entity<cicek_bilgi>()
                .Property(e => e.cinsi)
                .IsFixedLength();

            modelBuilder.Entity<cicek_bilgi>()
                .Property(e => e.dal_icin_taban_fiyat)
                .HasPrecision(19, 4);

            modelBuilder.Entity<cicek_bilgi>()
                .Property(e => e.s_no)
                .IsFixedLength();

            modelBuilder.Entity<rekolte>()
                .Property(e => e.miktar_sogan)
                .HasPrecision(19, 4);

            modelBuilder.Entity<rekolte>()
                .Property(e => e.rekolte1)
                .HasPrecision(19, 4);

            modelBuilder.Entity<rekolte>()
                .Property(e => e.miktar_cicek)
                .HasPrecision(19, 4);

            modelBuilder.Entity<satis>()
                .Property(e => e.cic_adi)
                .IsUnicode(false);

            modelBuilder.Entity<satis>()
                .Property(e => e.uretici_kodu)
                .IsUnicode(false);

            modelBuilder.Entity<satis>()
                .Property(e => e.uretici_adi)
                .IsUnicode(false);

            modelBuilder.Entity<satis>()
                .Property(e => e.satis_fiyat)
                .HasPrecision(18, 3);

            modelBuilder.Entity<satis>()
                .Property(e => e.alici_kodu)
                .IsUnicode(false);

            modelBuilder.Entity<satis>()
                .Property(e => e.cic_tur)
                .IsUnicode(false);

            modelBuilder.Entity<satis>()
                .Property(e => e.sube)
                .IsUnicode(false);

            modelBuilder.Entity<satis>()
                .Property(e => e.yedek_string)
                .IsUnicode(false);

            modelBuilder.Entity<satis>()
                .Property(e => e.yedek1_string)
                .IsUnicode(false);

            modelBuilder.Entity<ur_toplam>()
                .Property(e => e.ur_no)
                .IsUnicode(false);

            modelBuilder.Entity<ur_toplam>()
                .Property(e => e.tedno)
                .IsUnicode(false);

            modelBuilder.Entity<ur_toplam>()
                .Property(e => e.il)
                .IsUnicode(false);

            modelBuilder.Entity<ur_toplam>()
                .Property(e => e.uretici)
                .IsUnicode(false);

            modelBuilder.Entity<ur_toplam>()
                .Property(e => e.tip)
                .IsUnicode(false);

            modelBuilder.Entity<ur_toplam>()
                .Property(e => e.sube)
                .IsUnicode(false);

            modelBuilder.Entity<ur_toplam>()
                .Property(e => e.tediye_yazildimi)
                .IsUnicode(false);

            modelBuilder.Entity<ur_toplam>()
                .Property(e => e.yedek1_string)
                .IsUnicode(false);
        }
    }
}

