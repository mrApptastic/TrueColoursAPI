using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using TrueColoursAPI.Data;

namespace TrueColoursAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ColourController : ControllerBase
    {
        private readonly ILogger<ColourController> _logger;
           private readonly ApplicationDbContext _context;

        public ColourController(ILogger<ColourController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet("{red}/{green}/{blue}")]
        public async Task<ActionResult<Colour>> Get(int red, int green, int blue)
        {
            var colourList = await _context.TrueColours.Where(x => x.Red == red && x.Green == green && x.Blue == blue).ToListAsync();

            return Ok(colourList);
        }
    }
}
