namespace Bank
{
    public class Loan : Account, IDepositable
    {
        public Loan(Customer customer, decimal balance, decimal rate)
            : base(customer, balance, rate)
        {
        }

        public override decimal CalculateInterestForPeriod(uint numberOfMonths)
        {
            if (this.Customer.Type == CustomerType.Company)
            {
                numberOfMonths -= 2;
            }
            else
            {
                numberOfMonths -= 3;
            }

            return base.CalculateInterestForPeriod(numberOfMonths);
        }

        public void DepositMoney(decimal amount)
        {
            this.Balance += amount;
        }
    }
}
