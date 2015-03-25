namespace Bank
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class BankMainSystem
    {
        public static void Main()
        {
            var something = new CompanyCustomer("Apple", "USA", "121121121", "Kircho");
            Console.WriteLine(something.Type);
            var otherCust = new IndividualCustomer("SONY", "Japan", "3456565");

            var acc1 = new Loan(something, 139955, 10);
            var acc2 = new Mortgage(something, 10000, 20);
            var acc3 = new Deposit(otherCust, 100, 100);
            acc3.DepositMoney(1000);

            Console.WriteLine(acc2.CalculateInterestForPeriod(12));
            
        }
    }
}
