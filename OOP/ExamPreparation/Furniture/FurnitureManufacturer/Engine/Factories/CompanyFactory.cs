namespace FurnitureManufacturer.Engine.Factories
{
    using Interfaces;
    using Interfaces.Engine;
    using Models;
    using System;
    using System.Collections.Generic;

    public class CompanyFactory : ICompanyFactory
    {
        private IList<string> companyNames = new List<string>();

        public ICompany CreateCompany(string name, string registrationNumber)
        {
            if (!companyNames.Contains(name))
            {
                var company = new Company(name, registrationNumber);
                companyNames.Add(name);
                return company;
            }
            else
            {
                throw new ArgumentException("Company with this name already exists!!!");
            }
        }
    }
}
