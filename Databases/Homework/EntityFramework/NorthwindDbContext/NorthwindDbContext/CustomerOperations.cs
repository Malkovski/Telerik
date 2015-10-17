namespace NorthwindDbContext
{
    using System;
    using System.Linq;

    public class CustomerOperations
    {
        public static void Insert(NorthEntities northEntities, string customerID, string companyName, string contactName = null, string contactTitle = null,
            string address = null, string city = null, string region = null, string postalCode = null, string country = null, string phone = null, string fax = null)
        {
            var customer = new Customer
            {
                CustomerID = customerID,
                CompanyName = companyName,
                ContactName = contactName,
                ContactTitle = contactTitle,
                Address = address,
                City = city,
                Region = region,
                PostalCode = postalCode,
                Country = country,
                Phone = phone,
                Fax = fax
            };

            northEntities.Customers.Add(customer);
            northEntities.SaveChanges();
        }

        public static void Update(NorthEntities northEntities, string id, string companyName, string contactName = null, string contactTitle = null,
            string address = null, string city = null, string region = null, string postalCode = null, string country = null, string phone = null, string fax = null) 
        {
            Customer customerToUpdate = FindById(northEntities, id);
               
            customerToUpdate.CompanyName = companyName;
            customerToUpdate.ContactName = contactName;
            customerToUpdate.ContactTitle = contactTitle;
            customerToUpdate.Address = address;
            customerToUpdate.City = city;
            customerToUpdate.Region = region;
            customerToUpdate.PostalCode = postalCode;
            customerToUpdate.Country = country;
            customerToUpdate.Phone = phone;
            customerToUpdate.Fax = fax;

            northEntities.SaveChanges();
        }

        public static void Delete(NorthEntities northEntities, string id)
        {
            Customer customerToDelete = FindById(northEntities, id);

            northEntities.Customers.Remove(customerToDelete);
            northEntities.SaveChanges();
        }

        public static Customer FindById(NorthEntities northEntities, string id)
        {
            Customer customer = northEntities.Customers
                                             .FirstOrDefault(c => c.CustomerID == id);

            return customer;
        }
    }
}