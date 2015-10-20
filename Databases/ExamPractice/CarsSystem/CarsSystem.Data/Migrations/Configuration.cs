namespace CarsSystem.Data.Migrations
{
    using CarsSystem.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CarsDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "CarsSystem.Data.CarsDbContext";
        }

        protected override void Seed(CarsDbContext context)
        {
            //this.SeededDataCreator(context);
        }

        private void SeededDataCreator(CarsDbContext context)
        {
            for (int i = 0; i < 10; i++)
            {
                var city = new City
                {
                    Name = "City-" + i
                };

                context.Cities.AddOrUpdate(c => c.Name, city);

                var manu = new Manufacturer
                {
                    Name = "Opel-" + i
                };

                context.Manufacturers.AddOrUpdate(m => m.Name, manu);

                var dealer = new Dealer
                {
                    Name = "SeededDealer-" + i
                };

                context.Dealers.AddOrUpdate(d => d.Name, dealer);

                TransmissionType trans;
                if (i % 2 == 0)
                {
                    trans = TransmissionType.Automatic;
                }
                else
                {
                    trans = TransmissionType.Manual;
                }

                var car = new Car
                {
                    Model = "Model" + i + i,
                    Year = 1111,
                    Price = 20000 + (1250 * i),
                    DealerId = 1,
                    ManufacturerId = 1,
                    Transmission = trans
                };

                context.Cars.Add(car);
            }
        }
    }
}
