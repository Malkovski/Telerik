namespace FurnitureManufacturer.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Interfaces;

    public class ConvertibleChair : Chair, IConvertibleChair
    {
        private const decimal ConvertedStateHeigth = 0.10M;      

        private bool isConverted;
        private decimal initialHeigth;

        public ConvertibleChair(string model, string material, decimal price, decimal heigth, int numberOfLegs)
            : base(model, material, price, heigth, numberOfLegs)
        {
            this.InitialHeigth = heigth;
        }

        public decimal InitialHeigth
        {
            get
            {
                return this.initialHeigth;
            }

            protected set
            {
                this.initialHeigth = value;
            }
        }


        public bool IsConverted
        {
            get
            {
                return this.isConverted;
            }

            protected set
            {
                this.isConverted = value;
            }
        }

        public void Convert()
        {
            if (!isConverted)
            {
                this.Height = ConvertedStateHeigth;
            }
            else
            {
                this.Height = initialHeigth;
            }

            isConverted = !isConverted;
        }

        public override string ToString()
        {
            return string.Format("{0}, State: {1}", base.ToString(), this.IsConverted ? "Converted" : "Normal");
        }
    }
}
