namespace CarsSystem.ConsoleClient
{
    using System;
    using System.IO;
    using System.Linq;

    public static class JsonCarsImporer
    {
        public static void Import()
        {
            var jsonString = Directory.GetFiles(Directory.GetCurrentDirectory() + "/JsonFiles/")
                .Where(f => f.EndsWith(".json"))
                .Select(fs => File.ReadAllText(fs))
                .ToList();

            var a = 8;
        }

    }
}