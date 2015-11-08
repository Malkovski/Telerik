namespace WebApiExam.Api
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using WebApiExam.Data;
    using WebApiExam.Data.Migrations;

    public class DatabaseConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>());
            ApplicationDbContext.Create().Database.Initialize(true);
        }
    }
}