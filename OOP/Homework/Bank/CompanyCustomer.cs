namespace Bank
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class CompanyCustomer : Customer
    {
         public CompanyCustomer(string companyName, string address, string bulstat, string mol, CustomerType type = CustomerType.Company)
            : base(companyName, address, bulstat, type)
        {
            this.MOL = mol;
        }

        public string MOL { get; private set; }
    }
}
