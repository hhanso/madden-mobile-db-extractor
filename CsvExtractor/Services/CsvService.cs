using CsvExtractor.Services.Interfaces;
using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvExtractor.Services
{
    public class CsvService : ICsvService
    {
        public IEnumerable<T> ReadCsvFile<T, TMap>(string filepath) where TMap : ClassMap
        {
            using (var reader = new StreamReader(filepath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Context.RegisterClassMap<TMap>();
                return csv.GetRecords<T>().ToList();
            }
        }
    }
}
