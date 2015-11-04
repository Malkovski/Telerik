namespace SourceControlSystem.Api
{
    using SourceControlSystem.Data;
    using SourceControlSystem.Data.Migrations;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class DatabaseConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SourceControlSystemDbContext, Configuration>());
            SourceControlSystemDbContext.Create().Database.Initialize(true);
        }
    }
}