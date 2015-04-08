namespace Cosmetics.Products
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Contracts;

    public class Shampoo : Product, IShampoo
    {
        private uint milliliters;
        private Common.UsageType usage;

        public Shampoo(string name, string brand, decimal price, Common.GenderType gender, uint milliliters, Common.UsageType usage)
            : base(name, brand, price * milliliters, gender)
        {
            this.Milliliters = milliliters;
            this.Usage = usage;
        }

        public uint Milliliters
        {
            get
            {
                return this.milliliters; ; 
            }

            protected set
            {
                this.milliliters = value;
            }
        }

        public Common.UsageType Usage
        {
            get
            {
                return this.usage;
            }

            protected set
            {
                this.usage = value;
            }
        }

        public override string ToString()
        {
            return string.Format("{0}\n * Quantity: {1} ml\n * Usage: {2}", base.Print(), this.Milliliters, this.Usage);
            //StringBuilder info = new StringBuilder();

            //info.Append(base.Print());
            //info.AppendLine();
            ////info.Append(Environment.NewLine);
            //info.Append(string.Format(" * Quantity: {0}", this.Milliliters));
            //info.AppendLine();
            //info.Append(string.Format(" * Usage: {0}", this.Usage));
            ////info.AppendLine();

            //return info.ToString();
        }
    }
}
