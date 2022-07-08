using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace TrueColoursAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ColourController : ControllerBase
    {
        private readonly ILogger<ColourController> _logger;

        public ColourController(ILogger<ColourController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ICollection<Colour> Get()
        {
            return new List<Colour>();
        }
    }
}
