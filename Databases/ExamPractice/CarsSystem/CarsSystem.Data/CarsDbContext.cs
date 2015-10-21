namespace CarsSystem.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using CarsSystem.Models;
    using CarsSystem.Data.Migrations;

    public class CarsDbContext : DbContext, ICarsDbContext
    {
        public CarsDbContext() 
            : base("CarsDb")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CarsDbContext, Configuration>());
        }

        public IDbSet<City> Cities { get; set; }
                 
        public IDbSet<Car> Cars { get; set; }
                 
        public IDbSet<Manufacturer> Manufacturers { get; set; }
                 
        public IDbSet<Dealer> Dealers { get; set; }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        public new void SaveChanges()
        {
            base.SaveChanges();
        }

        public new void Dispose()
        {
            base.Dispose();
        }
    }
}