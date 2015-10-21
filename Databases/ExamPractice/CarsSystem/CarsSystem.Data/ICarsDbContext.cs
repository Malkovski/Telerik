namespace CarsSystem.Data
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using CarsSystem.Models;

    public interface ICarsDbContext
    {
        IDbSet<City> Cities { get; set; }

        IDbSet<Car> Cars { get; set; }

        IDbSet<Manufacturer> Manufacturers { get; set; }

        IDbSet<Dealer> Dealers { get; set; }

        IDbSet<T> Set<T>() where T : class;

        DbEntityEntry<T> Entry<T>(T entity) where T : class;

        void SaveChanges();

        void Dispose();
    }
}