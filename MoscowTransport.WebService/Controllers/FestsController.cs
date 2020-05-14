using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using placesFestFlowerJam.DomainObjects;

namespace placesFestFlowerJam.WebService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FestsController : ControllerBase
    {
        private readonly ILogger<FestsController> _logger;

        public FestsController(ILogger<FestsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Fest> GetFest()
        {
            return new List<Fest>() 
            { 
                new Fest() 
                { 
                    Id = 1,
                    Address = "vl.19",
                    PeriodOf = "22.08.2019-08.09.2019",
                    NumberTP = "25",
                    WorkWeekdays = "11-21",
                    WorkWeekend = "10-22",
                    Fests = new Fest()
                    {
                        Id = 1,
                        Name = "Цветочный Джем",
                        WebSite = "http://mos.ru"
                    }
                } 
            };
        }
    }
}
