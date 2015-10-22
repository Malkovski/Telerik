namespace CompanySampleDataImporter.Importer.Importers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using CompanySampleDataImporter.Data;
    using CompanySampleDataImporter.Importer.RandomGenerators;

    public class ReportImporter : IImporter
    {
        private CompanyEntities db;

        private readonly RandomGenerator generator = new RandomGenerator();

        public ReportImporter(CompanyEntities db)
        {
            this.db = db;
        }

        public CompanyEntities Import(string entryType, int count)
        {
            List<int> allEmployeesIds = db.EMPLOYEES
                                          .OrderBy(e => Guid.NewGuid())
                                          .Select(e => e.Id)
                                          .ToList();

            Console.WriteLine("Generating reports: ");

            for (int i = 0; i < allEmployeesIds.Count; i++)
            {
                int numberOfReports = this.generator.RandomNumber(25, 75);

                for (int j = 0; j < numberOfReports; j++)
                {
                    var report = new REPORT
                    {
                        employeeId = allEmployeesIds[i],
                        timeSent = this.generator.RandomDate(before: DateTime.Now)
                    };
                    
                    db.REPORTS.Add(report); 
                }

                if (i % 10 == 0)
                {
                    Console.Write("#");
                }

                if (i % 100 == 0)
                {
                    db.SaveChanges();
                    db.Dispose();
                    db = new CompanyEntities();
                    db.Configuration.AutoDetectChangesEnabled = false;
                    db.Configuration.ValidateOnSaveEnabled = false;
                }
            }

            Console.WriteLine();
            db.SaveChanges();

            return db;
        }
    }
}