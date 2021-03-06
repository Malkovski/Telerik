﻿namespace Computers.Factory
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Computers.Components;
    using Computers.CoreModels;
    using Computers.Interfaces;

    internal class HpComputers : ComputerFactory
    {
        private readonly IBattery battery = new Battery();

        private ICpu cpu;
        private IRam ram;
        private IHardDrive raid;
        private IVideoCard video;

        public override Laptop ManufactureLaptop()
        {
            this.cpu = new Cpu64(2);
            this.ram = new Ram(4);
            this.raid = new HardDrive(500, false, 0);
            this.video = new ColorfulVideoCard();

            var laptopBoard = new Motherboard(this.cpu, this.ram, this.raid, this.video);
            var laptop = new Laptop(laptopBoard, battery);

            return laptop;
        }

        public override Desktop ManufactureDesktop()
        {
            this.cpu = new Cpu32(2);
            this.ram = new Ram(2);
            this.raid = new HardDrive(500, false, 0);
            this.video = new ColorfulVideoCard();

            var board = new Motherboard(this.cpu, this.ram, this.raid, this.video);
            var pc = new Desktop(board);

            return pc;
        }

        public override Server ManufactureServer()
        {
            this.cpu = new Cpu32(4);
            this.ram = new Ram(32);
            this.raid = new HardDrive(1000, true, 2, new List<HardDrive> { new HardDrive(1000, true, 2), new HardDrive(1000, true, 2) });
            this.video = new MonochromeVideoCard();

            var serverBoard = new Motherboard(this.cpu, this.ram, this.raid, this.video);
            var server = new Server(serverBoard);

            return server;
        }
    }
}