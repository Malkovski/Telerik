namespace AcademyEcosystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Zombie : Animal
    {
        public Zombie(string name, Point position)
            : base(name, position, 0)
        {
        }

        public override int GetMeatFromKillQuantity()
        {
            return 10;
        }
    }
}
