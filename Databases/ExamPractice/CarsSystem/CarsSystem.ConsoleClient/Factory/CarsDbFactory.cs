namespace CarsSystem.ConsoleClient.Factory
{
    using System;
    using System.Linq;
    using CarsSystem.Data;

    public class CarsDbFactory 
    {
        public CarsDbContext Create()
        {
            return new CarsDbContext();
        }
    }
}