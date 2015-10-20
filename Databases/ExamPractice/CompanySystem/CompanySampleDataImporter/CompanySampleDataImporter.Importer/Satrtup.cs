namespace CompanySampleDataImporter.Importer
{
    using System;
    using System.Linq;
    using CompanySampleDataImporter.Importer.Importers;

    public class Satrtup
    {
        private static readonly DepartmentImporter departments = new DepartmentImporter();
        private static readonly EmployeeImporter employees = new EmployeeImporter();
        private static readonly ProjectImporter projects = new ProjectImporter();
        private static readonly ReportsImporter reports = new ReportsImporter();

        public static void Main()
        {
            departments.Import();
            employees.Import();
            projects.Import();
            reports.Import();

        }
    }
}