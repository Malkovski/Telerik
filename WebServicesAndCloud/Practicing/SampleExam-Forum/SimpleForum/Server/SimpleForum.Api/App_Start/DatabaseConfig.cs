namespace SimpleForum.Api
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using SimpleForum.Data;
    using SimpleForum.Data.Migrations;

    public class DatabaseConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SimpleForumDbContext, Configuration>());
            SimpleForumDbContext.Create().Database.Initialize(true);
        }
    }
}