namespace BullsAndCows.Api
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using BullsAndCows.Data;
    using BullsAndCows.Data.Migrations;

    public class DatabaseConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>());
            ApplicationDbContext.Create().Database.Initialize(true);
        }
    }
}