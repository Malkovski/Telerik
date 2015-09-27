using System;
using System.Collections.Generic;
using System.Linq;
using Computers.Components;
using Computers.Factory;
using Computers.Interfaces;

namespace Computers.Factory
{
    public class DellServer : Computer
    {
        private readonly ICpu cpu = new Cpu64(8);
        private readonly IRam ram = new Ram(64);
        private readonly IHardDrive raid = new HardDrive(2000, true, 2, new List<HardDrive> { new HardDrive(2000, true, 2), new HardDrive(2000, true, 2) });
        private readonly IVideoCard video = new MonochromeVideoCard();

        private Motherboard board;

        public DellServer()
        {
            this.board = new Motherboard(cpu, ram, raid, video);
           // this.board = base.board;
        }

        public override void Process(int data)
        {
            this.board.Process(data);
        }
    }
}
