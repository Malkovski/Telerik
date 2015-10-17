namespace NorthwindDbContext
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class EF
    {
        public static void Find1997ShippedToCanadaOrders(NorthEntities db)
        {
            IQueryable<string> orders = db.Customers
                                          .Join(db.Orders, (c => c.CustomerID), (o => o.CustomerID), (c, o) => new
                                          {
                                              Name = c.CompanyName,
                                              Date = o.ShippedDate,
                                              Country = o.ShipCountry
                                          })
                                          .Where(c => c.Country == "Canada")
                                          .Where(c => c.Date.Value.Year == 1997)
                                          .Select(c => c.Name);

            foreach (string order in orders)
            {
                Console.WriteLine(order);
            }
        }

        public static void Find1997ShippedToCanadaOrdersUsingSql(NorthEntities db)
        {
            string query = "select c.CompanyName from Customers c inner join Orders o on c.CustomerID = o.CustomerID where o.ShipCountry = 'Canada' and year(o.ShippedDate) = 1997";

            List<string> companyNames = db.Database.SqlQuery<string>(query).ToList();

            foreach (string name in companyNames)
            {
                Console.WriteLine("{0}", name);
            }
        }

        public static void FindSalesInRange(NorthEntities db, string region, DateTime startDate, DateTime endDate)
        {
            IQueryable<string> sales = db.Customers
                                         .Join(db.Orders, (c => c.CustomerID), (o => o.CustomerID), (c, o) => new
                                         {
                                             Name = c.CompanyName,
                                             Region = c.Region,
                                             DeliveryDate = o.ShippedDate
                                         })
                                         .Where(c => c.Region == region)
                                         .Where(c => c.DeliveryDate >= startDate)
                                         .Where(c => c.DeliveryDate <= endDate)
                                         .Select(c => c.Name);

            foreach (string sale in sales)
            {
                Console.WriteLine(sale);
            }
        }

        private static void Main()
        {
            using (var db = new NorthEntities())
            {
                CustomerOperations.Insert(db, "AAAA", "Chistota");
                //CustomerOperations.Update(db, "test", "StolichnaChistota", "Malkovski", "Malkovski", "Malkovski", "Malkovski", "Malkovski", "Malkovski", "Malkovski", "Malkovski", "Malkovski");
                //CustomerOperations.Delete(db, "test");
                //Find1997ShippedToCanadaOrders(db);
                //Console.WriteLine("--------------------------");
                //Find1997ShippedToCanadaOrdersUsingSql(db);
                //Console.WriteLine("--------------------------");
                //FindSalesInRange(db, "BC", new DateTime(1996, 08, 01), new DateTime(1997, 08, 01));
            }
        }
    }
}