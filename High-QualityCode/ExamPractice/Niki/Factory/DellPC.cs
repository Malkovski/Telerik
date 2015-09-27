
using Computers.Components;
using Computers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Computers.Factory
{
    public class DellPC : Computer
    {
        private readonly ICpu cpu = new Cpu64(4);
        private readonly IRam ram = new Ram(8);
        private readonly IHardDrive raid = new HardDrive(1000, false, 0);
        private readonly IVideoCard video = new ColorfulVideoCard();

        private Motherboard board;

        public DellPC() 
            
        {
            this.board = new Motherboard(cpu, ram, raid, video);
           // this.board = base.board;
        }

        public override void Play(int guessNumber)
        {
            this.board.Play(guessNumber);
        }
    }
}
