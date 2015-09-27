using Computers.Interfaces;

namespace Computers.Components
{
    internal class Battery : IBattery
    {
        private readonly int initialCharge = 50;

        internal Battery()
        {
            this.Percentage = this.initialCharge;
        }

        public int Percentage { get; set; }

        public void Charge(int p)
        {
            this.Percentage += p;
            if (this.Percentage > 100)
            {
                this.Percentage = 100;
            }
            if (this.Percentage < 0)
            {
                this.Percentage = 0;
            }
        }
    }
}