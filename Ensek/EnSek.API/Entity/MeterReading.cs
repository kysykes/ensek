using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnSek.API.Entity
{
    public class MeterReading
    {
        public int AccountId { get; private set; }

        public DateTime MeterReadingDateTime { get; private set; }

        public int MeterReadingValue { get; private set; }

        public MeterReading(int accountId, DateTime meterReadingDateTime, int meterReadingValue)
        {
            AccountId = accountId;
            MeterReadingDateTime = meterReadingDateTime;
            MeterReadingValue = meterReadingValue;

            //Todo: ValidateData();
        }
    }
}
