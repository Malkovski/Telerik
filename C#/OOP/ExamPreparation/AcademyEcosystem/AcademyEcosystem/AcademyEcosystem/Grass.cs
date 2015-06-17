namespace AcademyEcosystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Grass : Plant
    {
        private const int InitialGrassSize = 2;

        public Grass(Point position)
            : base(position, InitialGrassSize)
        {
        }

        public override void Update(int time)
        {
            if (base.IsAlive)
            {
                base.Size += time;
            }         
        }
    }
}
