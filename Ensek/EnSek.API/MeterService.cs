using CsvHelper;
using EnSek.API.Entity;
using EnSek.API.Interfaces;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace EnSek.API
{
    public class MeterService: IMeterService
    {
        private readonly IRepository _repo;

        public MeterService(IRepository repo)
        {
            _repo = repo;
        }

        public List<MeterReading> ProcessFileAsync(string fileName)
        {
            var customers = _repo.GetCustomers();

            var meterReadings = ReadCsvFile(fileName);

            var meterErrors = new List<MeterReading>();

            foreach (var reading in meterReadings)
            {
                var customerRecord = customers.Where(x => x.Id == reading.AccountId).FirstOrDefault();
                
                if(customerRecord == null)
                {
                    meterErrors.Add(reading);
                }
            }

            return meterErrors;
        }

        private static List<MeterReading> ReadCsvFile(string filename)
        {
            TextReader textReader = File.OpenText(filename);

            var csv = new CsvReader((IParser)textReader);

            var meterReadings = csv.GetRecords<EnSek.API.Entity.MeterReading>().ToList();

            textReader.Close();

            return meterReadings?? new List<MeterReading>();
        }
    }
}