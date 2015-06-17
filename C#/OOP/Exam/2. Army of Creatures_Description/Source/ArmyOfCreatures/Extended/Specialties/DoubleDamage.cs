namespace ArmyOfCreatures.Extended.Specialties
{
    using System;
    using Logic.Specialties;
    using System.Globalization;

    class DoubleDamage : Specialty
    {
        private int rounds;
        public DoubleDamage(int rounds)
        {
            if (rounds < 1 || rounds > 10)
            {
                throw new ArgumentOutOfRangeException("defenseToAdd", "defenseToAdd should be between 1 and 20, inclusive");
            }

            this.rounds = rounds;
        }

        public override decimal ChangeDamageWhenAttacking(Logic.Battles.ICreaturesInBattle attackerWithSpecialty, Logic.Battles.ICreaturesInBattle defender, decimal currentDamage)
        {
            var momentumDamage = currentDamage;
            if (this.rounds > 0)
            {
                momentumDamage *= 2;
                this.rounds--;
                return momentumDamage;
            }

            return momentumDamage;
        }

        public override string ToString()
        {
            return string.Format(
                CultureInfo.InvariantCulture,
                "{0}({1})",
                base.ToString(),
                this.rounds);
        }
    }
}
