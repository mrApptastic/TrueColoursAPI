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
    public class ColourTypeController : ControllerBase
    {
        private readonly ILogger<ColourTypeController> _logger;
        private readonly IColourTypeManager _manager;

        public ColourTypeController(ILogger<ColourTypeController> logger, IColourTypeManager manager)
        {
            _logger = logger;
            _manager = manager;
        }

        /// <summary>
        /// Get all colour types.
        /// </summary>
        /// <response code="200">Returns all colour types.</response>
        /// <response code="500">The request has failed.</response>
        [HttpGet]
        public async Task<ActionResult<ICollection<ColourTypeViewModel>>> GetAll()
        {
            var typeList = await _manager.GetAll();

            return Ok(typeList);
        }
    }
}
