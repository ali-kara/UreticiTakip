namespace DAL.Log.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<UreticiLogDBEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;

			

            //ContextKey = "UreticiTakip_Model.Models.LogDBEntities";
        }

        protected override void Seed(UreticiLogDBEntities context)
        {
            //base.Seed(context);
        }


    }
}
