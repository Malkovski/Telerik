namespace Computers.Interfaces
{
    using System;
    using System.Linq;

    public interface ILaptop
    {
        IBattery Battery { get; set; }

        void Charge(int p);
    }
}