namespace Cosmetics.Products
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Contracts;

    public abstract class Product : IProduct
    {
        private string name;
        private string brand;
        private decimal price;
        private Common.GenderType gender;

        public Product(string name, string brand, decimal price, Common.GenderType gender)
        {
            this.Name = name;
            this.Brand = brand;
            this.Price = price;
            this.Gender = gender;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            protected set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Name cannot be null or empty!");
                }

                if (value.Length < 3 || value.Length > 10)
                {
                    throw new ArgumentException("Product name must be between 3 and 10 symbols long!");
                }

                this.name = value;
            }
        }

        public string Brand
        {
            get
            {
                return this.brand;
            }

            protected set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Brand cannot be null or empty!");
                }

                if (value.Length < 2 || value.Length > 10)
                {
                    throw new ArgumentException("Product brand must be between 2 and 10 symbols long!");
                }

                this.brand = value;
            }
        }

        public decimal Price
        {
            get
            {
                return this.price; ;
            }

            protected set
            {
                this.price = value;
            }
        }
       
        public Common.GenderType Gender
        {
            get
            { 
                return this.gender; 
            }

            set
            {
                this.gender = value;
            }
        }

        public string Print()
        {
            return string.Format("- {0} - {1}\n * Price: ${2}\n * For gender: {3}", this.Brand, this.Name, this.Price, this.Gender);
        }
    }
}
