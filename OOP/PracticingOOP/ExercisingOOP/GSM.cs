namespace ExercisingOOP
{
    using System;
    public class GSM
    {
        private string model;
        private string manufacturer;
        private int price;
        private string owner;
        private Battery battery;
        private Display display;

        public GSM()
        {      
        }

        public GSM(string model, string manufacturer)
        {
            this.Model = model;
            this.Manufacturer = manufacturer;          
        }

        public GSM(string model, string manufacturer, int price, string owner, Battery battery,  Display display) : this(model, manufacturer)
        {
            this.Owner = owner;
            this.Price = price;
            this.battery = battery;
            this.display = display;
        }

        public string Model
        {
            get
            { 
                return this.model;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentException("Data must not be null!");
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
                if (value == null)
                {
                    throw new ArgumentException("Data must not be null!");
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
                if (value == null)
                {
                    throw new ArgumentException("Data must not be null!");
                }

                this.owner = value;
            }
        }

      

        public void GetGsmInfo(GSM someGsm)
        {
            System.Console.WriteLine(someGsm.manufacturer);
            System.Console.WriteLine(someGsm.model);         
            System.Console.WriteLine(someGsm.owner);
            System.Console.WriteLine(someGsm.price);        
        }
    }
}
