using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using TrueColoursAPI.Data;

namespace TrueColoursAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ColourController : ControllerBase
    {
        private readonly ILogger<ColourController> _logger;
   		private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;

        public ColourController(ILogger<ColourController> logger, IMapper mapper, ApplicationDbContext context)
        {
            _logger = logger;
            _mapper = mapper;
            _context = context;
        }

        [HttpGet("{red}/{green}/{blue}")]
        public async Task<ActionResult<ICollection<ColourViewModel>>> Get(int red, int green, int blue, [FromQuery]int page = 1, [FromQuery]int take = 50)
        {
            // var colourList = await _context.TrueColours.Where(x => x.Red == red && x.Green == green && x.Blue == blue).ToListAsync();
            // https://stackoverflow.com/questions/27374550/how-to-compare-color-object-and-get-closest-color-in-an-color
            // var colourList = await _context.TrueColours.OrderBy(n => Math.Abs(n.Red - red)).ThenBy(n => Math.Abs(n.Green - green)).ThenBy(n => Math.Abs(n.Blue - blue)).Take(10).ToListAsync();
            // https://stackoverflow.com/questions/4793729/rgb-to-hsl-and-back-calculation-problems
            var colourList = await _context.TrueColours.OrderBy(n => (Math.Abs(n.Red - red) + Math.Abs(n.Green - green) + Math.Abs(n.Blue - blue))).Skip(page -1).Take(take).ToListAsync();

            return Ok(_mapper.Map<ICollection<Colour>, ICollection<ColourViewModel>>(colourList));
        }
    }
}
