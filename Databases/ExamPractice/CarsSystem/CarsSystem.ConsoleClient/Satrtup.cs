namespace CarsSystem.ConsoleClient
{
    using System;
    using System.Linq;
    using CarsSystem.Data;
    using CarsSystem.Models;

    public class Satrtup
    {
        public static void Main()
        {
            JsonCarsImporer.Import();
        }
    }
}