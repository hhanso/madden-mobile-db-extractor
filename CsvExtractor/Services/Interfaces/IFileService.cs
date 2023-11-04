namespace CsvExtractor.Services.Interfaces
{
    public interface IFileService
    {
        void ArchiveFile(string sourcePath, string destinationPath);
        string[] GetCsvFiles(string path);
    }
}