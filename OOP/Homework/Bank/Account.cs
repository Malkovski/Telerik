namespace Bank
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public abstract class Account
    {
        private Customer customer;
        private decimal balance;
        private decimal rate;

        public Account(Customer customer, decimal balance, decimal rate)
        {
            this.Customer = customer;
            this.Balance = balance;
            this.Rate = rate;
        }

        public Customer Customer
        {
            get
            {
                return this.customer;
            }

            set
            {
                this.customer = value;
            }
        }

        public decimal Balance 
        {
            get
            {
                return this.balance;
            }

            set
            {
                this.balance = value;
            }
        }

        public decimal Rate
        {
            get
            {
                return this.rate;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentNullException("Monthly rate cannot be negative number!!!");
                }

                this.rate = value;
            }
        }

        public virtual decimal CalculateInterestForPeriod(uint numberOfMonths)
        {
            return this.Rate * numberOfMonths;
        }
    }
}
