namespace AcademyEcosystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Lion : Animal, ICarnivore
    {
        private const int InitialLionHealth = 6;

        public Lion(string name, Point location)
            : base(name, location, InitialLionHealth)
        {
        }

        public int TryEatAnimal(Animal animal)
        {
            int meatEaten = 0;

            if (animal != null)
            {
                if (animal.Size <= this.Size * 2)
                {
                    meatEaten = animal.GetMeatFromKillQuantity(); 
                    this.Size++;
                }
            }

            return meatEaten;
        }
    }
}
