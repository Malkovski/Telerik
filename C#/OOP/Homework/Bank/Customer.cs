namespace Bank
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public abstract class Customer
    {
        public Customer(string name, string address, string info, CustomerType type)
        {
            this.HolderName = name;
            this.Address = address;
            this.Information = info;
            this.Type = type;
        }
      
        public string HolderName { get; private set; }
        public string Address { get; private set; }
        public string Information { get; private set; }
        public CustomerType Type { get; private set; }
    }
}
