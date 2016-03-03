namespace TeleimotBg.Api
{
    using System.Data.Entity;

    using TeleimotBg.Data;
    using TeleimotBg.Data.Migrations;

    public class DatabaseConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TeleimotDbContext, Configuration>());
            TeleimotDbContext.Create().Database.Initialize(true);
        }
    }
}