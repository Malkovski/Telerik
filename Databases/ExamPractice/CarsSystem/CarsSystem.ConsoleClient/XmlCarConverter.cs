namespace CarsSystem.ConsoleClient
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Xml.Serialization;
    using CarsSystem.ConsoleClient.XmlCarViewModels;
    using CarsSystem.Data;

    public class XmlCarConverter
    {
        public void Convert()
        {
            const string QueriesFileName = "Queries.xml";
            if (!File.Exists(QueriesFileName))
            {
                Console.WriteLine("{0} file not found!", QueriesFileName);
                return;
            }

            var serializer = new XmlSerializer(typeof(List<Query>), new XmlRootAttribute("Queries"));

            IEnumerable<Query> queries;

            using (var fs = new FileStream(QueriesFileName, FileMode.Open))
            {
                queries = (IEnumerable<Query>)serializer.Deserialize(fs);
            }

            foreach (Query query in queries)
            {
                ProcessQuery(query);
            }
        }

        private static void ProcessQuery(Query query)
        {
            var db = new CarsDbContext();
            IQueryable<XmlCar> dataQuery = db.Cars.Select(
                car => new XmlCar
                {
                    Id = car.Id,
                    Manufacturer = car.Manufacturer.Name,
                    Model = car.Model,
                    Price = car.Price,
                    Year = car.Year,
                    TransmissionType =
                                      car.Transmission == Models.TransmissionType.Manual ? "manual" : "automatic",
                    Dealer =
                        new XmlDealer
                        {
                            Name = car.Dealer.Name,
                            Cities = car.Dealer.Cities.Select(city => city.Name).ToList(),
                        }
                });

            switch (query.OrderBy)
            {
                case "Id":
                    dataQuery = dataQuery.OrderBy(x => x.Id);
                    break;
                case "Year":
                    dataQuery = dataQuery.OrderBy(x => x.Year);
                    break;
                case "Model":
                    dataQuery = dataQuery.OrderBy(x => x.Model);
                    break;
                case "Price":
                    dataQuery = dataQuery.OrderBy(x => x.Price);
                    break;
                case "Manufacturer":
                    dataQuery = dataQuery.OrderBy(x => x.Manufacturer);
                    break;
                case "Dealer":
                    dataQuery = dataQuery.OrderBy(x => x.Dealer.Name);
                    break;
            }

            foreach (WhereClause whereClause in query.WhereClauses)
            {
                if (whereClause.PropertyName == "Id")
                {
                    int constant = int.Parse(whereClause.Value);
                    switch (whereClause.TypeAsEnum)
                    {
                        case WhereTypes.Equals:
                            dataQuery = dataQuery.Where(x => x.Id == constant);
                            break;
                        case WhereTypes.GreaterThan:
                            dataQuery = dataQuery.Where(x => x.Id > constant);
                            break;
                        case WhereTypes.LessThan:
                            dataQuery = dataQuery.Where(x => x.Id < constant);
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
                else if (whereClause.PropertyName == "Year")
                {
                    int constant = int.Parse(whereClause.Value);
                    switch (whereClause.TypeAsEnum)
                    {
                        case WhereTypes.Equals:
                            dataQuery = dataQuery.Where(x => x.Year == constant);
                            break;
                        case WhereTypes.GreaterThan:
                            dataQuery = dataQuery.Where(x => x.Year > constant);
                            break;
                        case WhereTypes.LessThan:
                            dataQuery = dataQuery.Where(x => x.Year < constant);
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
                else if (whereClause.PropertyName == "Price")
                {
                    decimal constant = decimal.Parse(whereClause.Value);
                    switch (whereClause.TypeAsEnum)
                    {
                        case WhereTypes.Equals:
                            dataQuery = dataQuery.Where(x => x.Price == constant);
                            break;
                        case WhereTypes.GreaterThan:
                            dataQuery = dataQuery.Where(x => x.Price > constant);
                            break;
                        case WhereTypes.LessThan:
                            dataQuery = dataQuery.Where(x => x.Price < constant);
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
                else if (whereClause.PropertyName == "Model")
                {
                    switch (whereClause.TypeAsEnum)
                    {
                        case WhereTypes.Equals:
                            dataQuery = dataQuery.Where(x => x.Model == whereClause.Value);
                            break;
                        case WhereTypes.Contains:
                            dataQuery = dataQuery.Where(x => x.Model.Contains(whereClause.Value));
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
                else if (whereClause.PropertyName == "Manufacturer")
                {
                    switch (whereClause.TypeAsEnum)
                    {
                        case WhereTypes.Equals:
                            dataQuery = dataQuery.Where(x => x.Manufacturer == whereClause.Value);
                            break;
                        case WhereTypes.Contains:
                            dataQuery = dataQuery.Where(x => x.Manufacturer.Contains(whereClause.Value));
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
                else if (whereClause.PropertyName == "Dealer")
                {
                    switch (whereClause.TypeAsEnum)
                    {
                        case WhereTypes.Equals:
                            dataQuery = dataQuery.Where(x => x.Dealer.Name == whereClause.Value);
                            break;
                        case WhereTypes.Contains:
                            dataQuery = dataQuery.Where(x => x.Dealer.Name.Contains(whereClause.Value));
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
                else if (whereClause.PropertyName == "City")
                {
                    switch (whereClause.TypeAsEnum)
                    {
                        case WhereTypes.Equals:
                            dataQuery = dataQuery.Where(x => x.Dealer.Cities.Contains(whereClause.Value));
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
            }

            List<XmlCar> data = dataQuery.ToList();
            var serializer = new XmlSerializer(data.GetType(), new XmlRootAttribute("Cars"));
            using (var fs = new FileStream(query.OutputFileName, FileMode.Create))
            {
                serializer.Serialize(fs, data);
            }

            Console.WriteLine("{0} ready.", query.OutputFileName);
        }
    }
}