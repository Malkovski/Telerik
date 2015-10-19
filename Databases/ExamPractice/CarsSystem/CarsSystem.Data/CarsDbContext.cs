namespace CarsSystem.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using CarsSystem.Models;
    using CarsSystem.Data.Migrations;

    public class CarsDbContext : DbContext
    {
        public CarsDbContext() 
            : base("CarsDb")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CarsDbContext, Configuration>());
        }

        public virtual DbSet<City> Cities { get; set; }
                 
        public virtual DbSet<Car> Cars { get; set; }
                 
        public virtual DbSet<Manufacturer> Manufacturers { get; set; }
                 
        public virtual DbSet<Dealer> Dealers { get; set; }
    }
}