namespace CompanySampleDataImporter.Importer
{
    using System;
    using System.Linq;
    using CompanySampleDataImporter.Data;
    using CompanySampleDataImporter.Importer.Importers;

    public class Satrtup
    {
        private const int NumberOfDepartments = 10;//100
        private const int NumberOfEmployees = 50;//5000
        private const int NumberOfProjects = 100;//1000

        public static void Main()
        {
            var db = new CompanyEntities();
            var sampleImporter = new SampleDataImporter(db);

            sampleImporter.Import("Department", NumberOfDepartments);
            sampleImporter.Import("Employee", NumberOfEmployees);
            sampleImporter.Import("Project", NumberOfProjects);
            sampleImporter.Import("Report", 0);
        }
    }
}