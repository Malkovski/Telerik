namespace Computers.Factory
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Computers.Components;
    using Computers.CoreModels;
    using Computers.Interfaces;

    internal class LenovoComputers : ComputerFactory
    {
        private readonly Battery battery = new Battery();

        private ICpu cpu;
        private IRam ram;
        private IHardDrive raid;
        private IVideoCard video;

        public override Laptop ManufactureLaptop()
        {
            this.cpu = new Cpu64(2);
            this.ram = new Ram(16);
            this.raid = new HardDrive(1000, false, 0);
            this.video = new ColorfulVideoCard();

            var laptopBoard = new Motherboard(this.cpu, this.ram, this.raid, this.video, this.battery);
            var laptop = new Laptop(laptopBoard);

            return laptop;
        }

        public override PC ManufacturePC()
        {
            this.cpu = new Cpu64(2);
            this.ram = new Ram(4);
            this.raid = new HardDrive(2000, false, 0);
            this.video = new MonochromeVideoCard();

            var board = new Motherboard(this.cpu, this.ram, this.raid, this.video);
            var pc = new PC(board);

            return pc;
        }

        public override Server ManufactureServer()
        {
            this.cpu = new Cpu128(2);
            this.ram = new Ram(8);
            this.raid = new HardDrive(500, true, 2, new List<HardDrive> { new HardDrive(500, true, 2), new HardDrive(500, true, 2) });
            this.video = new MonochromeVideoCard();

            var serverBoard = new Motherboard(this.cpu, this.ram, this.raid, this.video);
            var server = new Server(serverBoard);

            return server;
        }
    }
}