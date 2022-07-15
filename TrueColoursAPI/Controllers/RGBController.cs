using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using TrueColoursAPI.Data;
using TrueColoursAPI.Models;
using TrueColoursAPI.Managers;

namespace TrueColoursAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RGBController : ControllerBase
    {
        private readonly ILogger<RGBController> _logger;
        private readonly IColourManager _manager;

        public RGBController(ILogger<RGBController> logger, IColourManager manager)
        {
            _logger = logger;
            _manager = manager;
        }

        /// <summary>
        /// Get closest colours in RGB format from RGB input.
        /// </summary>
        /// <remarks>Default number of results is 10 and can be changed by altering the 'take' query parameter.</remarks>
        /// <response code="200">Returns closest colours from RGB input.</response>
        /// <response code="500">The request has failed.</response>
        [HttpGet("{red}/{green}/{blue}")]
        public async Task<ActionResult<ICollection<RGBViewModel>>> Get(int red, int green, int blue, [FromQuery]int take = 10, [FromQuery]string[] category = null)
        {
            var colourList = await _manager.GetNearestRGB(red, green, blue, take, category);

            return Ok(colourList);
        }

        /// <summary>
        /// Search colours with RGB formatted output.
        /// </summary>
        /// <remarks>Default number of results is 50 and can be changed by altering the 'take' query parameter. Parameter 'page' can be used for pagination.</remarks>
        /// <response code="200">Returns a result set of RGB formatted output.</response>
        /// <response code="500">The request has failed.</response>
        [HttpPost("Search")]

        public async Task<ActionResult<ICollection<RGBViewModel>>> SearchRGBColours([FromBody]ColourSearchModel searchDto, [FromQuery]int page = 1, [FromQuery]int take = 50)
        {
            var searchResult = await _manager.SearchRGBColours(searchDto, page, take);

            Response.Headers.Add("X-Count", searchResult.count.ToString());

            return Ok(searchResult.results); 
        }
    }
}
