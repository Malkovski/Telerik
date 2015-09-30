namespace Computers.CoreModels
{
    using System;
    using System.Linq;

    public abstract class Computer
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