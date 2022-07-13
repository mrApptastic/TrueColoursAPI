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
    public class HexController : ControllerBase
    {
        private readonly ILogger<HexController> _logger;
   		private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;

        public HexController(ILogger<HexController> logger, IMapper mapper, ApplicationDbContext context)
        {
            _logger = logger;
            _mapper = mapper;
            _context = context;
        }

        /// <summary>
        /// Get closest colours in Hex format from RGB input.
        /// </summary>
        /// <remarks>Default number of results is 10 and can be changed by altering the 'take' query parameter.</remarks>
        /// <response code="200">Returns closest colours from RGB input.</response>
        /// <response code="500">The request has failed.</response>
        [HttpGet("{red}/{green}/{blue}")]
        public async Task<ActionResult<ICollection<HexViewModel>>> Get(int red, int green, int blue, [FromQuery]int take = 10)
        {
            var colourList = await _context.TrueColours.OrderBy(n => (Math.Abs(n.Red - red) + Math.Abs(n.Green - green) + Math.Abs(n.Blue - blue))).Take(take).ToListAsync();

            return Ok(_mapper.Map<ICollection<Colour>, ICollection<HexViewModel>>(colourList));
        }
    }
}
