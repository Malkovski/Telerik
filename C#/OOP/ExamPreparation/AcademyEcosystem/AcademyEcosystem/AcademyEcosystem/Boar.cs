namespace AcademyEcosystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Boar : Animal, ICarnivore, IHerbivore
    {
        private const int InitialBoarSize = 4;
        private const int InitialBiteSize = 2;

        private int biteSize;

        public Boar(string name, Point position)
            : base(name, position, InitialBoarSize)
        {
            this.biteSize = InitialBiteSize;
        }

        public int TryEatAnimal(Animal animal)
        {
            int meatEaten = 0;

            if (animal != null)
            {
                if (base.Size >= animal.Size)
                {
                    meatEaten = animal.GetMeatFromKillQuantity();
                }
            }

            return meatEaten;
        }
         
        public int EatPlant(Plant plant)
        {
            int plantEaten = 0;

            if (plant != null)
            {
                plantEaten = plant.GetEatenQuantity(this.biteSize);
                this.Size++;
            }

            return plantEaten;
        }
    }
}
