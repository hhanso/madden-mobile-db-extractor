using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvExtractor.Services.Interfaces;

namespace CsvExtractor.Services
{
    public class FileService : IFileService
    {
        public string[] GetCsvFiles(string path)
        {
            return Directory.GetFiles(path, "*.csv");
        }

        public void ArchiveFile(string sourcePath, string destinationPath)
        {
            File.Move(sourcePath, destinationPath);
        }
    }
}
