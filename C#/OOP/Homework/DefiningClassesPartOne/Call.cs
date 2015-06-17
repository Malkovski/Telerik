namespace MobilePhones
{
    using System;
    using System.Text;

    public class Call
    {
        private DateTime date;
        private DateTime time;
        private string number;
        private int duration;

        public Call(DateTime date, DateTime time, string number, int duration)
        {
            this.Date = date;
            this.Time = time;
            this.Number = number;
            this.Duration = duration;
        }

        public DateTime Date
        {
            get
            {
                return this.date;
            }

            set 
            {
                this.date = value;
            }
        }

        public DateTime Time
        {
            get
            {
                return this.time;
            }

            set
            {
                this.time = value;
            }
        }

        public string Number
        {
            get 
            {
                return this.number;
            }

            set
            {
                for (int i = 0; i < value.Length; i++)
                {
                    if (!char.IsDigit(value[i]))
                    {
                        throw new ArgumentException("Wrong number!!!");
                    }
                }              

                this.number = value;
            }
        }

        public int Duration
        {
            get
            {
                return this.duration;
            }

            set
            {
                int temp = 0;

                if (!int.TryParse(value.ToString(), out temp) || int.Parse(value.ToString()) < 0)
                {
                    throw new ArgumentException("Duration must be positive number in seconds!");
                }          

                this.duration = value;
            }
        }

        public override string ToString()
        {
            StringBuilder info = new StringBuilder();
            info.AppendLine("Date: " + this.Date);
            info.AppendLine("Time: " + this.Time);
            info.AppendLine("Number: " + this.Number);
            info.AppendLine("Duration: " + this.Duration);

            return info.ToString();
        }
    }
}
