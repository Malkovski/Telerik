namespace FurnitureManufacturer.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Interfaces;

    public class Table : Furniture, ITable
    {
        private decimal length;
        private decimal width;     

        public Table(string model, string material, decimal price, decimal heigth, decimal length, decimal width)
            : base(model, material, price, heigth)
        {
            this.Length = length;
            this.Width = width;
        }

        public decimal Length
        {
            get
            {
                return this.length;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Lenght must be positive number bigger than zero!!!");
                }

                this.length = value;
            }
        }

        public decimal Width
        {
            get
            {
                return this.width;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Width must be positive number bigger than zero!!!");
                }

                this.width = value;
            }
        }

        public decimal Area
        {
            get
            {
                return this.width * this.length;
            }
        }

        public override string ToString()
        {
            return string.Format("{0}, Length: {1}, Width: {2}, Area: {3}", base.ToString(), this.Length, this.Width, this.Area);
        }
    }
}
