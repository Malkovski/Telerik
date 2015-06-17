namespace AcademyEcosystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Wolf : Animal, ICarnivore
    {
        private const int InitialWolfSize = 4;

        public Wolf(string name,  Point point)
            : base(name, point, InitialWolfSize)
        {
        }

        public int TryEatAnimal(Animal animal)
        {
            int meatEaten = 0;

            if (animal != null)
            {
                if (animal.State == AnimalState.Sleeping || this.Size >= animal.Size)
                {
                    meatEaten = animal.GetMeatFromKillQuantity();
                }            
            }

            return meatEaten;
        }
    }
}
