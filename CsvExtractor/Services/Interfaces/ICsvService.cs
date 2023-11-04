using CsvHelper.Configuration;

namespace CsvExtractor.Services.Interfaces
{
    public interface ICsvService
    {
        IEnumerable<T> ReadCsvFile<T, TMap>(string filepath) where TMap : ClassMap;
    }
}