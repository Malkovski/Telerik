namespace Computers.Factory
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Computers.Components;
    using Computers.CoreModels;
    using Computers.Interfaces;

    public class DellComputers : ComputerFactory
    {
        private readonly Battery battery = new Battery();

        private ICpu cpu;
        private IRam ram;
        private IHardDrive raid;
        private IVideoCard video;

        public override Laptop ManufactureLaptop()
        {
            this.cpu = new Cpu32(4);
            this.ram = new Ram(8);
            this.raid = new HardDrive(1000, false, 0);
            this.video = new ColorfulVideoCard();
       
            var dellLaptopBoard = new Motherboard(this.cpu, this.ram, this.raid, this.video, this.battery);
            var laptop = new Laptop(dellLaptopBoard);

            return laptop;
        }

        public override PC ManufacturePC()
        {
            this.cpu = new Cpu64(4);
            this.ram = new Ram(8);
            this.raid = new HardDrive(1000, false, 0);
            this.video = new ColorfulVideoCard();

            var dellPCBoard = new Motherboard(this.cpu, this.ram, this.raid, this.video);
            var pc = new PC(dellPCBoard);

            return pc;
        }

        public override Server ManufactureServer()
        {
            this.cpu = new Cpu64(8);
            this.ram = new Ram(64);
            this.raid = new HardDrive(2000, true, 2, new List<HardDrive> { new HardDrive(2000, true, 2), new HardDrive(2000, true, 2) });
            this.video = new MonochromeVideoCard();

            var dellServerBoard = new Motherboard(this.cpu, this.ram, this.raid, this.video);
            var server = new Server(dellServerBoard);

            return server;
        }
    }
}