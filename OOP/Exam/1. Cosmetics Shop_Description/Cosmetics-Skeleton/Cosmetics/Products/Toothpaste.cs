namespace Cosmetics.Products
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Contracts;

    public class Toothpaste : Product, IToothpaste
    {
        private string ingredients;
        private IList<string> ingredientList;

        public Toothpaste(string name, string brand, decimal price, Common.GenderType gender, IList<string> ingredients)
            : base(name, brand, price, gender)
        {
            this.ingredientList = ingredients;
            this.Ingredients = this.AddIngredient(ingredientList);
        }

        public string Ingredients
        {
            get 
            {
                return this.ingredients; 
            }

            set
            {
                this.ingredients = value;
            }
        }

        private string AddIngredient(IList<string> ingredient)
        {
            var currentIngredient = string.Empty;

            for (int i = 0; i < ingredient.Count; i++)
            {
                if (ingredient[i].Length < 4 || ingredient[i].Length > 12)
                {
                    throw new ArgumentException("Each ingredient must be between 4 and 12 symbols long!");
                }

                currentIngredient += ingredient[i];
                

                if (i < ingredient.Count - 1 && ingredient.Count != 1)
                {
                    currentIngredient +=  ", ";
                }             
            }

            return currentIngredient;
        }

        public override string ToString()
        {
            return string.Format("{0}\n * Ingredients: {1}", base.Print(), this.Ingredients);
            //StringBuilder info = new StringBuilder();

            //info.Append(base.Print());
            //info.AppendLine();
            //info.Append(string.Format(" * Ingredients: {0}", this.Ingredients));

            //return info.ToString();
        }
    }
}
