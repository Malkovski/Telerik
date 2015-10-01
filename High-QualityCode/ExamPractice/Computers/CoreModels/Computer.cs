namespace Computers.CoreModels
{
    using Computers.Interfaces;
    using System;
    using System.Linq;

    public abstract class Computer : ILaptop, IDesktop, IServer
    {
        public virtual void Play(int number)
        {
        }

        public virtual void Process(int data)
        {
        }

        public virtual void Charge(int percent)
        {
        }
    }
}