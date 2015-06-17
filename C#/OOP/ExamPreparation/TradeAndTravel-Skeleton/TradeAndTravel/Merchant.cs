namespace TradeAndTravel
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Merchant : Shopkeeper, ITraveller
    {
       public Merchant(string name, Location location)
            : base(name, location)
        {
        }

        public override int CalculateSellingPrice(Item item)
        {
            return base.CalculateSellingPrice(item);
        }

        public override int CalculateBuyingPrice(Item item)
        {
            return base.CalculateBuyingPrice(item);
        }

        public void TravelTo(Location location)
        {
            this.Location = location;
        }
    }
}
