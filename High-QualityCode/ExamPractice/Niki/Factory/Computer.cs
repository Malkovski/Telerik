using System;
using System.Linq;
using Computers.Components;
using Computers.Interfaces;

namespace Computers.Factory
{
    public abstract class Computer
    {
        //public Motherboard board;

        //public Computer(ICpu cpu, IRam ram, IHardDrive raid, IVideoCard video)
        //{
        //    this.board = new Motherboard(cpu, ram, raid, video);
        //}

        public virtual void Play(int num)
        {
        }

        public virtual void Process(int data)
        {
        }

        public virtual void Charge(int ca)
        {
        }
    }
}
