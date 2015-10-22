namespace CompanySampleDataImporter.Importer.Importers
{
    using CompanySampleDataImporter.Data;

    public interface IImporter
    {
        CompanyEntities Import(string entryType, int count);
    }
}