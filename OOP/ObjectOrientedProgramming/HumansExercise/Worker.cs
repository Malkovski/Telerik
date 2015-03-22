namespace OOPPrinciplesPartOne.Humans
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Worker : Human
    {
        private const int WorkDays = 5;

        private double weekSalary;
        private int workHourPerDay;

        public Worker(string firsName, string lastName, double weekSalary, int workHourPerDay) : base(firsName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.WorkHourPerDay = workHourPerDay;
        }

        public double WeekSalary 
        {
            get
            {
                return this.weekSalary;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Cannot enter negative number!!!");
                }

                this.weekSalary = value;
            }
        }

        public int WorkHourPerDay 
        {
            get
            {
                return this.workHourPerDay;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Cannot enter negative number!!!");
                }

                if (value > 12)
                {
                     throw new ArgumentOutOfRangeException("Its not legal!!!");
                }

                this.workHourPerDay = value;
            }
        }

        public double MoneyPerHour()
        {
            double result = 0;

            result = this.weekSalary / (this.workHourPerDay * WorkDays);

            return result;
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2:0.00}", this.FirstName, this.LastName, this.MoneyPerHour());
        }
    }
}
