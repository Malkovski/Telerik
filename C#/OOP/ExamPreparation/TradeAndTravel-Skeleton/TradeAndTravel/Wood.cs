namespace TradeAndTravel
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Wood : Item
    {
        const int GeneralWoodValue = 5;

        public Wood(string name, Location location = null)
            : base(name, Wood.GeneralWoodValue, ItemType.Wood, location)
        {
        }

        public override void UpdateWithInteraction(string interaction)
        {
            while (interaction == "drop" && this.Value > 0)
            {
                this.Value--;
            }
        }
    }
}
