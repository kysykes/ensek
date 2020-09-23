using EnSek.API;
using EnSek.API.Entity;
using EnSek.API.Interfaces;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace EnSek.Tests
{
    class ProcessFileTest
    {
        private Mock<IRepository> _repo;

        [SetUp]
        public void Setup()
        {
            _repo = new Mock<IRepository>(MockBehavior.Strict);
        }

        private List<Customer> Customers()
        {
            return new List<Customer>
            {
                new Customer(4, "Test", "McTest"),
                new Customer(5, "Another", "Customer")
            };
        }

        private List<MeterReading> MeterReadings()
        {
            return new List<MeterReading>
            {
                new MeterReading(4, DateTime.UtcNow, 90223),
                new MeterReading(6, DateTime.UtcNow.AddDays(-5), 11111)
            };
        }

        [Test]
        public void ProcessFile()
        {
            _repo.Setup(x => x.GetCustomers())
                .Returns(Customers())
                .Verifiable();

            //todo: Mock File reading

            var _meterService = new MeterService(_repo.Object);

            var errors = _meterService.ProcessFileAsync("filePath");

            Assert.AreEqual(1, errors.Count);
        }
    }
}