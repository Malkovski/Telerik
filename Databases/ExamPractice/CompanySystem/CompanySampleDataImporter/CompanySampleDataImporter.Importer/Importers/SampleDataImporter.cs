namespace CompanySampleDataImporter.Importer.Importers
{
    using System;
    using System.Linq;
    using CompanySampleDataImporter.Data;

    public class SampleDataImporter 
    {
        private CompanyEntities db;
        private IImporter importer;

        public SampleDataImporter(CompanyEntities db)
        {
            this.db = db;
        }

        public void Import(string entryType, int count)
        {
            this.db.Configuration.AutoDetectChangesEnabled = false;
            this.db.Configuration.ValidateOnSaveEnabled = false;

            if (entryType == "Department")
            {
                this.importer = new DepartmentImporter(this.db);
                this.db = this.importer.Import(entryType, count);
            }
            else if (entryType == "Employee")
            {
                this.importer = new EmployeeImporter(this.db);
                this.db = this.importer.Import(entryType, count);
            }
            else if (entryType == "Project")
            {
                this.importer = new ProjectImporter(this.db);
                this.db = this.importer.Import(entryType, count);
            }
            else if (entryType == "Report")
            {
                this.importer = new ReportImporter(this.db);
                this.db = this.importer.Import(entryType, count);
            }
        }
    }
}