namespace CarsSystem.ConsoleClient
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using CarsViewModels;
    using CarsSystem.Models;
using CarsSystem.Data;

    public static class JsonCarsImporer
    {
        public static void Import()
        {
            var carsToAdd = Directory.GetFiles(Directory.GetCurrentDirectory() + "/JsonFiles/")
                .Where(f => f.EndsWith(".json"))
                .Select(fs => File.ReadAllText(fs))
                .SelectMany(str => JsonConvert.DeserializeObject<ICollection<CarViewModel>>(str))
                .ToList();

            var addedManufacturers = new Dictionary<string, Manufacturer>();
            var addedCities = new Dictionary<string, City>();

            var db = new CarsDbContext();
            db.Configuration.AutoDetectChangesEnabled = false;

            var addedCars = 0;

            foreach (var car in carsToAdd)
            {
                var cityName = car.Dealer.City;

                if (!addedCities.ContainsKey(cityName))
                {
                    addedCities.Add(cityName, new City
                    {
                        Name = car.Dealer.City
                    });
                }

                var cityToAdd = addedCities[cityName];

                var manufaturer = car.ManufacturerName;

                if (!addedManufacturers.ContainsKey(manufaturer))
                {
                    addedManufacturers.Add(manufaturer, new Manufacturer
                    {
                        Name = manufaturer
                    });
                }

                var manufacturerToAdd = addedManufacturers[manufaturer];

                var dealerToAdd = new Dealer
                {
                    Name = car.Dealer.Name
                };

                dealerToAdd.Cities.Add(cityToAdd);

                var carToAdd = new Car
                {
                    Model = car.Model,
                    Year = car.Year,
                    Price = car.Price,
                    Transmission = (TransmissionType)car.TransmissionType,
                    Manufacturer = manufacturerToAdd,
                    Dealer = dealerToAdd

                };

                db.Cars.Local.Add(carToAdd);

                if (addedCars % 100 == 0)
                {
                    db.SaveChanges();
                    db.Dispose();
                    db = new CarsDbContext();
                    db.Configuration.AutoDetectChangesEnabled = false;
                }

                addedCars++;
            }

            db.SaveChanges();
            db.Configuration.AutoDetectChangesEnabled = true;
        }

    }
}