namespace CarsSystem.ConsoleClient
{
    using System;
    using System.Linq;
    using CarsSystem.ConsoleClient.Factory;
    using SetupContext;
    using CarsSystem.Data;

    public class Satrtup
    {
        private const string ContentFolderName = "JsonFiles";

        private static readonly CarsDbFactory contextFactory = new CarsDbFactory();
        private static readonly ContextConfigurator configurator = new ContextConfigurator();

        public static void Main()
        {
            var db = contextFactory.Create();
            configurator.Setup(db, false, false);

            //Console.WriteLine(db.Configuration.ValidateOnSaveEnabled.ToString());
            //Console.WriteLine(db.Configuration.AutoDetectChangesEnabled.ToString());

            JsonCarsImporer.Import(db, ContentFolderName);

            configurator.Setup(db, true, true);
        }
    }
}