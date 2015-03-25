using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class Mortgage : Account, IDepositable
    {
        public Mortgage(Customer customer, decimal balance, decimal rate)
            : base(customer, balance, rate)
        {
        }

        public override decimal CalculateInterestForPeriod(uint numberOfMonths)
        {
            if (this.Customer.Type == CustomerType.Company)
            {
                if (numberOfMonths > 12)
                {
                    return base.CalculateInterestForPeriod(6) + base.CalculateInterestForPeriod(numberOfMonths - 12); 
                }
                else
                {
                    return base.CalculateInterestForPeriod(numberOfMonths) / 2;
                }
               
            }
            else
            {
                if (numberOfMonths > 6)
                {
                    return base.CalculateInterestForPeriod(numberOfMonths - 6);
                }
                else
                {
                    return base.CalculateInterestForPeriod(0);
                }           
            }
        }

        public void DepositMoney(decimal amount)
        {
            if (amount < 0)
            {
                throw new ArgumentNullException("Deposit ammount cannot be negative!!!");
            }

            this.Balance += amount;
        }
    }
}
