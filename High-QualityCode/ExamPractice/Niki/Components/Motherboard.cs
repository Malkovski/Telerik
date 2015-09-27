using System;
using System.Linq;
using Computers.Interfaces;

namespace Computers.Components
{
    public class Motherboard : IMotherboard
    {
        private const int MinPlayRange = 1;
        private const int MaxPlayRange = 10;

        private readonly ICpu cpu;
        private readonly IRam ram;
        private readonly IVideoCard video;
        private readonly IHardDrive raid;
        private readonly IBattery battery;

        public Motherboard(ICpu cpu, IRam ram, IHardDrive hdd, IVideoCard video)
        {
            this.cpu = cpu;
            this.ram = ram;
            this.raid = hdd;
            this.video = video;
        }

        public Motherboard(ICpu cpu, IRam ram, IHardDrive hdd, IVideoCard video, IBattery battery)
        {
            this.cpu = cpu;
            this.ram = ram;
            this.raid = hdd;
            this.video = video;
            this.battery = battery;
        }

        private void SaveToRam(int newValue)
        {
            this.ram.SaveValue(newValue);
        }

        private int LoadFromRam()
        {
            return this.ram.LoadValue();
        }

        public void Play(int guessNumber)
        {
            this.SaveToRam(this.cpu.GetRandomValue(MinPlayRange, MaxPlayRange));

            int number = this.LoadFromRam();

            if (number != guessNumber)
            {
                this.video.Draw(string.Format("You didn't guess the number {0}.", number));
            }
            else
            {
                this.video.Draw("You win!");
            }
        }

        public void Process(int data)
        {
            this.ram.SaveValue(data);
            
            this.video.Draw(this.cpu.SquareNumber(data));
        }

        public void Charge(int percent)
        {
            battery.Percentage += percent;
            
            if (battery.Percentage > 100)
            {
                battery.Percentage = 100;
                this.video.Draw(string.Format("Battery status: {0}", this.battery.Percentage));
            }
            else if (battery.Percentage < 0)
            {
                battery.Percentage = 0;
                this.video.Draw(string.Format("Battery status: {0}", this.battery.Percentage));
            }
            else
            {
                this.video.Draw(string.Format("Battery status: {0}", this.battery.Percentage));
            }
        }
    }
}