namespace StudentSystem.Services
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using StudentsSystem.Data;
    using StudentsSystem.Data.Migrations;

    public static class DatabaseConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StudentsSystemDbContext, Configuration>());
        }
    }
}