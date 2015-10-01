namespace Computers.Components
{
    using System;
    using System.Linq;
    using Computers.Interfaces;

    public class Motherboard : IExtendedMotherboard
    {
        private readonly ICpu cpu;
        private readonly IRam ram;
        private readonly IVideoCard video;
        private readonly IHardDrive raid;

        public Motherboard(ICpu cpu, IRam ram, IHardDrive hdd, IVideoCard video)
        {
            this.cpu = cpu;
            this.ram = ram;
            this.raid = hdd;
            this.video = video;
        }

        public void DisplayMessage(string message)
        {
            this.video.Draw(message);
        }

        public void SaveToRam(int newValue)
        {
            this.ram.SaveValue(newValue);
        }

        public int LoadFromRam()
        {
            return this.ram.LoadValue();
        }

        public string SquareNumber(int data)
        {
            var result = this.cpu.SquareNumber(data);

            return result;
        }

        public int GetRandomValue(int a, int b)
        {
            var result = this.cpu.GetRandomValue(a, b);

            return result;
        }
    }
}