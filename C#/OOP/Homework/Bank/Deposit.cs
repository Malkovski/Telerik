namespace Bank
{
    using System;

    public class Deposit : Account, IDepositable, IWithdrawable
    {
        private const decimal MinimalBalanceForInterestCalculating = 1000;
        public Deposit(Customer customer, decimal balance, decimal rate)
            : base(customer, balance, rate)
        {
        }

        public override decimal CalculateInterestForPeriod(uint numberOfMonths)
        {
            if (this.Balance > 0 && this.Balance <= MinimalBalanceForInterestCalculating)
            {
                return base.CalculateInterestForPeriod(0);
            }
            else
            {
                return base.CalculateInterestForPeriod(numberOfMonths);
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

        public void WithdrawMoney(decimal amount)
        {
            if (amount > this.Balance)
            {
                throw new ArgumentException(string.Format("Not enough money to withdraw!!! Your balance is {0}", this.Balance));
            }
            else
            {
                this.Balance -= amount;
            }
        }
    }
}
