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
using TrueColoursAPI.Models;
using TrueColoursAPI.Managers;

namespace TrueColoursAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HexController : ControllerBase
    {
        private readonly ILogger<HexController> _logger;
   		private readonly IMapper _mapper;
        private readonly IColourManager _manager;

        public HexController(ILogger<HexController> logger, IMapper mapper, IColourManager manager)
        {
            _logger = logger;
            _mapper = mapper;
            _manager = manager;
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
            var colourList = await _manager.GetAll(red, green, blue, take);

            return Ok(_mapper.Map<ICollection<Colour>, ICollection<HexViewModel>>(colourList));
        }
    }
}
