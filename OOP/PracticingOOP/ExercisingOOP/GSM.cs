namespace MobilePhones
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class GSM
    {
        public static GSM iPhoneS4;
        private static Battery iBattery;
        private static Display iDisplay;

        private string model;
        private string manufacturer;
        private int price;
        private string owner;
        private Battery battery;
        private Display display;
        private List<Call> callHistory;

        static GSM()
        {
            iBattery = new Battery("IphoneBattery", 1000, 1000, BatteryType.Nuclear);
            iDisplay = new Display("100 inches", 99000000);
            iPhoneS4 = new GSM("IPhoneS6", "Apple", 2000, "SomeGazar");
        }

        public GSM(string model, string manufacturer)
        {
            this.CallHistory = new List<Call>();
            this.Model = model;
            this.Manufacturer = manufacturer;          
        }

        public GSM(string model, string manufacturer, int price, string owner) : this(model, manufacturer)
        {
            this.Owner = owner;
            this.Price = price;
        }

        public GSM(string model, string manufacturer, int price, string owner, Battery battery,  Display display) : this(model, manufacturer, price, owner)
        {   
            this.battery = battery;
            this.display = display;
        }

        public static GSM IPhoneS4
        {
            get
            {
                return iPhoneS4;
            }
        }

        public string Model
        {
            get
            { 
                return this.model;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Enter model!!!");
                }

                this.model = value;
            }
        }

        public string Manufacturer
        {
            get
            { 
                return this.manufacturer;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Enter manufacturer!!!");
                }

                this.manufacturer = value;
            }
        }

        public int Price
        {
            get
            {
                return this.price;
            }

            set
            {
                int temp = 0;

                if (!int.TryParse(value.ToString(), out temp))
                {
                    throw new ArgumentException("Use only symbols from 0...9!");
                }
                else if (int.Parse(value.ToString()) < 0)
                {
                    throw new ArgumentException("Data must be positive number!!!");
                }

                this.price = value;
            }
        }

        public string Owner
        {
            get
            { 
                return this.owner;
            }

            set 
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Enter owner!!!");
                }

                this.owner = value;
            }
        }

        public List<Call> CallHistory
        {
            get
            { 
                return this.callHistory;
            }

            set 
            { 
                this.callHistory = value;
            }
        }

        public void AddCall(Call newCall)
        {
            this.CallHistory.Add(newCall);
        }

        public void DelCall(Call someCall)
        {
            this.CallHistory.Remove(someCall);
        }

        public void DeleteHistory()
        {
            this.CallHistory.Clear();
        }

        public decimal CostCalculation(decimal pricePerMin)
        {
            decimal totalCost = 0m;
            decimal totalDuration = 0m;

            for (int i = 0; i < this.callHistory.Count; i++)
            {
                totalDuration += this.callHistory[i].Duration;
            }

            totalCost = (totalDuration / 60) * pricePerMin;

            return totalCost;
        }

        public override string ToString()
        {
            StringBuilder info = new StringBuilder();
            info.AppendLine(string.Format("Manufacturer: {0}", this.Manufacturer));
            info.AppendLine(string.Format("Model: {0}", this.Model));
            info.AppendLine(string.Format("Owner: {0}", this.Owner));
            info.AppendLine(string.Format("Price: {0}", this.Price));
            info.AppendLine(string.Format("Display {0}", this.display));
            info.AppendLine(string.Format("Battery {0}", this.battery));

            return info.ToString();
        }   
    }
}
