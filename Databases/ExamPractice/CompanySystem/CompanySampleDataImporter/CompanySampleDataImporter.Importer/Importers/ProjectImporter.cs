namespace CompanySampleDataImporter.Importer.Importers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using CompanySampleDataImporter.Data;
    using CompanySampleDataImporter.Importer.RandomGenerators;

    public class ProjectImporter : IImporter
    {
        private CompanyEntities db;

        private readonly RandomGenerator generator = new RandomGenerator();

        public ProjectImporter(CompanyEntities db)
        {
            this.db = db;
        }

        public CompanyEntities Import(string entryType, int count)
        {
            List<int> allEmployeesIds = db.EMPLOYEES
                                          .OrderBy(e => Guid.NewGuid())
                                          .Select(e => e.Id)
                                          .ToList();

            int currentEmployeeIndex = 0;

            Console.WriteLine("Generating projects: ");

            for (int i = 0; i < count; i++)
            {
                var currentProject = new PROJECT
                {
                    Name = this.generator.RandomString(5, 50)
                };

                int numberOfEmployeesPerProject = this.generator.RandomNumber(2, 8);

                for (int j = 0; j < numberOfEmployeesPerProject; j++)
                {
                    if (j + currentEmployeeIndex >= allEmployeesIds.Count)
                    {
                        break;
                    }

                    int currentEmployeeId = allEmployeesIds[currentEmployeeIndex];
                    DateTime startDate = this.generator.RandomDate(before: DateTime.Now.AddDays(-100));

                    currentProject.PROJECTS_EMPLOYEES.Add(new PROJECTS_EMPLOYEES
                    {
                        EmployeeId = currentEmployeeId,
                        startDate = startDate,
                        endDate = this.generator.RandomDate(after: startDate)
                    });

                    currentEmployeeIndex++;
                }

                db.PROJECTS.Add(currentProject);

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