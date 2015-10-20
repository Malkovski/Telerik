namespace CarsSystem.ConsoleClient
{
    using System;
    using System.Linq;

    public class Satrtup
    {
        public static void Main()
        {
            JsonCarsImporer.Import();
        }
    }
}