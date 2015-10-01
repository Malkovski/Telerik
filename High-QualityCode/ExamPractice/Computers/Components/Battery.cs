namespace Computers.Components
{
    using Computers.Interfaces;

    internal class Battery : IBattery
    {
        private const int InitialCharge = 50;

        internal Battery()
        {
            this.Percentage = InitialCharge;
        }

        public int Percentage { get; set; }

        public void Charge(int percent)
        {
            this.Percentage += percent;

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