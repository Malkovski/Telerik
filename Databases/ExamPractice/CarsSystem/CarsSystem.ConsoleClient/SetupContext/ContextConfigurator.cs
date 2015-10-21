namespace CarsSystem.ConsoleClient.SetupContext
{
    using System;
    using System.Linq;
    using CarsSystem.Data;

    public class ContextConfigurator
    {
        public void Setup(CarsDbContext context, bool autoDetectChanges, bool validateOnSaving)
        {
            context.Configuration.AutoDetectChangesEnabled = autoDetectChanges;
            context.Configuration.ValidateOnSaveEnabled = validateOnSaving;
        }
    }
}