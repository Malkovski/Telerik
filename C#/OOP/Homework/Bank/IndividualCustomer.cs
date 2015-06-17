namespace Bank
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class IndividualCustomer : Customer
    {
          public IndividualCustomer(string holderName, string address, string egn, CustomerType type = CustomerType.Individual)
              : base(holderName, address, egn, type)
        {           
        }
    }
}
