namespace NorthwindDbContext
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ExtendedEmployee : Employee
    {
        public DbSet<Territory> Teritory { get; set; }
    }
}