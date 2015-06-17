namespace ArmyOfCreatures.Extended.Creatures
{
    using Logic.Creatures;
    using Logic.Specialties;

    public class AncientBehemoth : Creature
    {
        public AncientBehemoth()
            :base(19, 19, 300, 40)
        {
            this.AddSpecialty(new ReduceEnemyDefenseByPercentage(80M));
            this.AddSpecialty(new DoubleDefenseWhenDefending(5));
        }
    }
}
