using System;
using System.Linq;
using Computers.Components;
using Computers.Interfaces;

namespace Computers.Factory
{
    public class DellLaptop : Computer
    {
        private readonly ICpu cpu = new Cpu32(4);
        private readonly IRam ram = new Ram(8);
        private readonly IHardDrive raid = new HardDrive(1000, false, 0);
        private readonly IVideoCard video = new ColorfulVideoCard();
        private readonly IBattery battery = new Battery();

        private Motherboard board;
        
        public DellLaptop()         
        {
            this.board = new Motherboard(cpu, ram, raid, video, battery);
            //this.board = base.board;
        }

        public override void Charge(int percent)
        {
            this.board.Charge(percent);
            
        }
    }
}