namespace Cosmetics.Products
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Contracts;

    public class ShoppingCart : IShoppingCart
    {
        private ICollection<IProduct> productList;

        public ShoppingCart()
        {
            this.productList = new List<IProduct>();
        }

        public void AddProduct(IProduct product)
        {
            this.productList.Add(product);
        }

        public void RemoveProduct(IProduct product)
        {
            this.productList.Remove(product);
        }

        public bool ContainsProduct(IProduct product)
        {
            foreach (var pr in productList)
            {
                if (pr == product)
                {
                    return true;
                }
            }

            return false;
        }

        public decimal TotalPrice()
        {
            decimal currentTotalPrice = 0;

            foreach (var pr in productList)
            {
                currentTotalPrice += pr.Price;
            }

            return currentTotalPrice;
        }
    }
}
