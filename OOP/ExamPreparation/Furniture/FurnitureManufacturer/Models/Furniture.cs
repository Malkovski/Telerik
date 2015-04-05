namespace FurnitureManufacturer.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Interfaces;

    public abstract class Furniture : IFurniture
    {
        private string model;
        private string material;
        private decimal price;
        private decimal height;

        public Furniture(string model, string material, decimal price, decimal heigth)
        {
            this.Model = model;
            this.Material = material;
            this.Price = price;
            this.Height = heigth;
        }

        public string Model
        {
            get
            {
                return this.model;
            }

            protected set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Model cannot be null or empty! Please enter valid model!");
                }

                if (value.Length < 3)
                {
                    throw new ArgumentException("Model must be more than or equal to 3 letters!!!");
                }

                this.model = value;
            }
        }

        public string Material
        {
            get
            {
                return this.material;
            }

            protected set
            {
                switch (material)
                {
                    case "wooden": this.material = "Wooden";
                        break;
                    case "leather": this.material = "Leather";
                        break;
                    case "plastic": this.material = "Plastic";
                        break;
                    default:
                        this.material = value;
                        break;
                }
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Price must be positive number bigger than zero!!!");
                }

                this.price = value;
            }
        }

        public decimal Height
        {
            get
            {
                return this.height;
            }

            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Height must be positive number bigger than zero!!!");
                }

                this.height = value;
            }
        }

        public override string ToString()
        {
            return string.Format("Type: {0}, Model: {1}, Material: {2}, Price: {3}, Height: {4}", this.GetType().Name, this.Model, this.Material, this.Price, this.Height);
        }
    }
}
