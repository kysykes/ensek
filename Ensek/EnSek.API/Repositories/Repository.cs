using Dapper;
using EnSek.API.Entity;
using EnSek.API.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EnSek.API.Repositories
{
    public class Repository: IRepository
    {
        private IDbConnection DbConnection { get; }

        private IConfiguration Configuration { get; }

        public Repository(IConfiguration configuration)
        {
            Configuration = configuration;
            DbConnection = new SqlConnection(Configuration.GetConnectionString("ensekDb"));
        }

        public List<Customer> GetCustomers()
        {
            string sqlGetCustomers = "SELECT id, firstName, surname FROM OrderDetails;";
            var customers = DbConnection.Query<Customer>(sqlGetCustomers).ToList();
            return customers;
        }

        public void AddMeterReadings()
        {
            //todo: Update record where id = customerId
        }
    }
}
