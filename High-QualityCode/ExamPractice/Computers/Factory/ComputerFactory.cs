namespace Computers.Factory
{
    using System;
    using System.Linq;
    using Computers.CoreModels;

    public abstract class ComputerFactory
    {
        public abstract Laptop ManufactureLaptop();

        public abstract Desktop ManufactureDesktop();

        public abstract Server ManufactureServer();
    }
}