namespace CompanySampleDataImporter.Importer.Importers
{
    using System;
    using System.Linq;
    using CompanySampleDataImporter.Data;
    using RandomGenerators;

    public class DepartmentImporter : IImporter
    {
        private readonly RandomGenerator generator = new RandomGenerator();

        private CompanyEntities db;

        public DepartmentImporter(CompanyEntities db)
        {
            this.db = db;
        }

        public CompanyEntities Import(string name, int count)
        {
            Console.WriteLine("Generating departments: ");

            for (int i = 0; i < count; i++)
            {
                this.db.DEPARTMENTS.Add(new DEPARTMENT
                {
                    Name = this.generator.RandomString(10, 50)
                });

                if (i % 10 == 0)
                {
                    Console.Write("#");
                }

                if (i % 100 == 0)
                {
                    this.db.SaveChanges();
                    this.db.Dispose();
                    this.db = new CompanyEntities();
                    db.Configuration.AutoDetectChangesEnabled = false;
                    db.Configuration.ValidateOnSaveEnabled = false;
                }
            }

            Console.WriteLine();
            this.db.SaveChanges();

            return db;
        }
    }
}