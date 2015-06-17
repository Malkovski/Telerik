namespace Cosmetics.Products
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Contracts;

    public class Category : ICategory
    {
        private string name;
        private ICollection<IProduct> products;

        public Category(string name)
        {
            this.Name = name;
            this.products = new List<IProduct>();
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

                if (value.Length < 2 || value.Length > 15)
                {
                    throw new ArgumentException("Category name must be between 2 and 15 symbols long!");
                }

                this.name = value;
            }
        }

        public void AddCosmetics(IProduct cosmetics)
        {
            this.products.Add(cosmetics);
        }

        public void RemoveCosmetics(IProduct cosmetics)
        {
            //validate with message
            this.products.Remove(cosmetics);
        }

        public string Print()
        {
            StringBuilder info = new StringBuilder();
            string firstLineToPrint = string.Empty;

            firstLineToPrint =  string.Format("{0} category - ", this.Name);

            if (products.Count != 1)
            {
               firstLineToPrint += string.Format("{0} products in total", this.products.Count);
            }
            else
            {
                 firstLineToPrint += "1 product in total";
            }

            info.Append(firstLineToPrint);

            var sortedProducts = this.products.OrderBy(x => x.Brand).ThenByDescending(x => x.Price);
            foreach (var pr in sortedProducts)
            {
                info.AppendLine();
                info.Append(pr.ToString());
            }

            info.ToString().TrimEnd();
            return info.ToString();
        }
    }
}
