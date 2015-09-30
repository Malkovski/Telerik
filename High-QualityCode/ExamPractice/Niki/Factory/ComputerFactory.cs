namespace Computers.Factory
{
    using System;
    using System.Linq;
    using Computers.CoreModels;

    public abstract class ComputerFactory
    {
        public abstract Laptop ManufactureLaptop();

        public abstract PC ManufacturePC();

        public abstract Server ManufactureServer();
    }
}