namespace NorthwindDbContext.Tests
{
    using System;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using NorthwindDbContext;

    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void InsertShouldInsertNewRecord()
        {
            var db = new NorthEntities();
            string customerId = "AAAAA";

            CustomerOperations.Insert(db, customerId, "Test company");

            Customer customer = CustomerOperations.FindById(db, customerId);

            CustomerOperations.Delete(db, customerId);

            Assert.AreEqual(customer.CustomerID, customerId);
        }

        [TestMethod]
        public void UpdateShouldChangeTheData()
        {
            var db = new NorthEntities();
            string customerId = "AAAAA";
            string newCompanyName = "qqqqqqqqqqqqq";

            CustomerOperations.Insert(db, customerId, "Test company");

            CustomerOperations.Update(db, customerId, newCompanyName);

            Customer customer = CustomerOperations.FindById(db, customerId);

            CustomerOperations.Delete(db, customerId);

            Assert.AreEqual(customer.CompanyName, newCompanyName);
        }
    }
}