namespace CarsSystem.ConsoleClient
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using CarsViewModels;
    using CarsSystem.Data;
    using CarsSystem.Models;
    using Newtonsoft.Json;

    public static class JsonCarsImporer
    {
        public static void Import()
        {
            List<CarViewModel> carsToAdd = Directory
                .GetFiles(string.Format("{0}/JsonFiles/", Directory.GetCurrentDirectory()))
                .Where(f => f.EndsWith(".json"))
                .Select(fs => File.ReadAllText(fs))
                .SelectMany(str => JsonConvert.DeserializeObject<ICollection<CarViewModel>>(str))
                .ToList();

            var addedManufacturers = new Dictionary<string, Manufacturer>();
            var addedCities = new Dictionary<string, City>();

            var db = new CarsDbContext();
            db.Configuration.AutoDetectChangesEnabled = false;
            db.Configuration.ValidateOnSaveEnabled = false;

            int addedCars = 0;

            Console.WriteLine("Adding cars");

            foreach (CarViewModel car in carsToAdd)
            {
                string cityName = car.Dealer.City;

                if (!addedCities.ContainsKey(cityName))
                {
                    addedCities.Add(cityName, new City
                    {
                        Name = car.Dealer.City
                    });
                }

                City cityToAdd = addedCities[cityName];

                string manufaturer = car.ManufacturerName;

                if (!addedManufacturers.ContainsKey(manufaturer))
                {
                    addedManufacturers.Add(manufaturer, new Manufacturer
                    {
                        Name = manufaturer
                    });
                }

                Manufacturer manufacturerToAdd = addedManufacturers[manufaturer];

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
              
                db.Cars.Add(carToAdd);

                if (addedCars % 100 == 0)
                {
                    Console.Write("_");
                }

                //if (addedCars % 100 == 0)
                //{
                //    db.SaveChanges();
                //    db.Dispose();
                //    db = new CarsDbContext();
                //    db.Configuration.AutoDetectChangesEnabled = false;
                //    db.Configuration.ValidateOnSaveEnabled = false;
                //}

                addedCars++;
            }

            Console.WriteLine();
            db.SaveChanges();
            db.Configuration.AutoDetectChangesEnabled = true;
            db.Configuration.ValidateOnSaveEnabled = true;
        }
    }
}