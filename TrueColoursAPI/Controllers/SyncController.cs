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
    public class SyncController : ControllerBase
    {
        private readonly ILogger<SyncController> _logger;
        private readonly ISyncManager _manager;

        public SyncController(ILogger<SyncController> logger, ISyncManager manager)
        {
            _logger = logger;
            _manager = manager;
        }

        /// <summary>
        /// Sync Local Colours with Source Colours.
        /// </summary>
        /// <response code="200">Sync was completed succesfully.</response>
        /// <response code="500">The request has failed.</response>
        [HttpPost]
        public async Task<ActionResult> SyncAll()
        {
            await _manager.SyncAll();

            return Ok();
        }
    }
}
