namespace CompanySampleDataImporter.Importer.Importers
{
    using System;
    using System.Linq;
    using CompanySampleDataImporter.Data;
    using CompanySampleDataImporter.Importer.RandomGenerators;
    using System.Collections.Generic;

    public class EmployeeImporter : IImporter
    {
        private const int NumberOfEmployees = 5000;//5000

        private readonly RandomGenerator generator = new RandomGenerator();

        public void Import()
        {
            var db = new CompanyEntities();

            var allDepartmentsIds = db.DEPARTMENTS
                .OrderBy(d => Guid.NewGuid())
                .Select(d => d.Id)
                .ToList();

            Console.Write("Generating employees: ");

            for (int i = 0; i < NumberOfEmployees; i++)
            {
                var randomDepartmentIndex = generator.RandomNumber(0, allDepartmentsIds.Count - 1);

                var randomDepartmentId = allDepartmentsIds[randomDepartmentIndex];

                db.EMPLOYEES.Add(new EMPLOYEE
                {
                    firstName = this.generator.RandomString(5, 20),
                    lastName = this.generator.RandomString(5, 20),
                    yearSalary = this.generator.RandomNumber(50000, 200000),
                    departmentId = randomDepartmentId
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

            db.SaveChanges();

            Console.WriteLine();
            Console.Write("Generating managers: ");

            var allEmployeesIds = db.EMPLOYEES
                .OrderBy(d => Guid.NewGuid())
                .Select(d => d.Id)
                .ToList();

            var levels = new int[] { 5, 5, 5, 10, 10, 10, 10, 15, 30};

            var currentPercentage = 0;
            List<int> previousManagers = null;

            foreach (var level in levels)
            {
                var skip = (int)((currentPercentage * allEmployeesIds.Count) / 100.0);
                var take = (int)((level * allEmployeesIds.Count) / 100.0);

                var currentEmployeesIds = allEmployeesIds
                    .Skip(skip)
                    .Take(take)
                    .ToList();

                var employees = db.EMPLOYEES
                    .Where(e => currentEmployeesIds.Contains(e.Id))
                    .ToList();

                for (int i = 0; i < employees.Count; i++)
                {
                    var employee = employees[i];

                    employee.managerId =
                        previousManagers == null
                        ? null
                        : (int?)previousManagers[generator.RandomNumber(0, previousManagers.Count - 1)];

                    if (i % 10 == 0)
                    {
                        Console.Write("#");
                    }
                }

                previousManagers = currentEmployeesIds;
                currentPercentage += level;

                db.SaveChanges();
                db.Dispose();
                db = new CompanyEntities();
            }

            Console.WriteLine();
            db.SaveChanges();
        }
    }
}