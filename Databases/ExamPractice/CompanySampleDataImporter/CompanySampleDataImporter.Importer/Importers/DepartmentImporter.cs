namespace CompanySampleDataImporter.Importer.Importers
{
    using System;
    using System.Linq;
    using CompanySampleDataImporter.Data;
    using RandomGenerators;

    public class DepartmentImporter : IImporter
    {
        private const int NumberOfDepartments = 100; //100

        private readonly RandomGenerator generator = new RandomGenerator();

        public void Import()
        {
            var db = new CompanyEntities();

            Console.WriteLine("Generating departments: ");

            for (int i = 0; i < NumberOfDepartments; i++)
            {
                db.DEPARTMENTS.Add(new DEPARTMENT
                {
                    Name = this.generator.RandomString(10, 50)
                });

                if (i % 10 == 0)
                {
                    Console.Write("#");
                }

                if (i % 100 == 0)
                {
                    db.SaveChanges();
                    db.Dispose();
                    db = new CompanyEntities();
                }
            }

            Console.WriteLine();
            db.SaveChanges();
        }
    }
}