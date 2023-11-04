using CsvExtractor.Models.Csv;
using CsvExtractor.Services.Interfaces;
using CsvHelper;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace CsvExtractor.Services
{
    public class LoadDataService : ILoadDataService
    {
        private readonly ILogger<LoadDataService> _logger;
        private readonly IFileService _fileService;
        private readonly IDbService _dbService;
        private readonly ICsvService _csvService;

        public LoadDataService(
            ILogger<LoadDataService> _logger,
            IFileService _fileService,
            IDbService _dbService,
            ICsvService _csvService) 
        { 
            this._logger = _logger;
            this._fileService = _fileService;
            this._dbService = _dbService;
            this._csvService = _csvService;
        }

        public void LoadData()
        {
            _logger.LogInformation("Beginning load to database.");
            var rootDir = @"C:\Users\hankh\dev\MaddenMobileCSVFiles\";
            string[] filePaths = _fileService.GetCsvFiles(rootDir + "Inbound");

            if (filePaths.Length == 0)
            {
                _logger.LogInformation("No files found.");
                return;
            }

            foreach (string file in filePaths)
            {
                try
                {
                    var players = _csvService.ReadCsvFile<Player, PlayerMap>(file);
                    _dbService.SavePlayers(players);
                    _fileService.ArchiveFile(file, rootDir + @"Archive\" + Path.GetFileName(file));

                    _logger.LogInformation($"Processed and archived file: {file}");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"Error processing file: {file}");
                }
            }

            _logger.LogInformation("LoadData process completed.");
            return;
        }
    }
}
