using EnSek.API.Entity;
using EnSek.API.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace EnSek.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MeterReadingController : ControllerBase
    {
        private readonly ILogger<MeterReadingController> _logger;

        private readonly IRepository _repo;

        private readonly IMeterService _meterService;


        public MeterReadingController(ILogger<MeterReadingController> logger, IRepository repository, IMeterService meterService)
        {
            _logger = logger;
            _repo = repository;
            _meterService = meterService;
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public List<MeterReading> AddMeterReadingsFromFile(string filelocation)
        {
            return _meterService.ProcessFileAsync(filelocation);
        }


    }
}
