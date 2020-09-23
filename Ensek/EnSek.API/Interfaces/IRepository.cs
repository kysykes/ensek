using EnSek.API.Entity;
using System.Collections.Generic;

namespace EnSek.API.Interfaces
{
    public interface IRepository
    {
        List<Customer> GetCustomers();

        void AddMeterReadings();
    }
}