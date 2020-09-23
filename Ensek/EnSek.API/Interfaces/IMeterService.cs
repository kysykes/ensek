using EnSek.API.Entity;
using System.Collections.Generic;

namespace EnSek.API.Interfaces
{
    public interface IMeterService
    {
        List<MeterReading> ProcessFileAsync(string fileName);
    }
}
