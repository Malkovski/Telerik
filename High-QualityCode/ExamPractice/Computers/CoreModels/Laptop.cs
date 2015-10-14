namespace Computers.CoreModels
{
    using System;
    using System.Linq;
    using Computers.Interfaces;

    public class Laptop : ILaptop
    {
        private const string BatteryStatus = "Battery status: {0}%";
        private readonly IExtendedMotherboard board;
        private readonly IBattery battery;

        public Laptop(IExtendedMotherboard board, IBattery battery)         
        {
            this.board = board;
            this.battery = battery;
        }

        public IBattery Battery
        {
            get
            {
                return this.battery;
            }
            set
            {
                this.Battery = value;
            }
        }

        public void Charge(int percent)
        {
            this.battery.Charge(percent);
            this.board.DisplayMessage(string.Format(BatteryStatus, this.battery.Percentage));
        }
    }
}