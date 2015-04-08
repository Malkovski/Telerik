namespace ArmyOfCreatures.Extended.Creatures
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Logic.Specialties;
    using Logic.Creatures;
    using Specialties;

    class CyclopsKing : Creature
    {
        public CyclopsKing()
            : base(17, 13, 70, 18)
        {
            this.AddSpecialty(new AddAttackWhenSkip(3));
            this.AddSpecialty(new DoubleAttackWhenAttacking(4));
            this.AddSpecialty(new DoubleDamage(1));
        }
    }
}
