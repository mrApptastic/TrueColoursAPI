using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using TrueColoursAPI.Data;
using TrueColoursAPI.Models;
using TrueColoursAPI.Helpers;
using System.Collections;
using AutoMapper;

namespace TrueColoursAPI.Managers
{
	public interface ISyncManager {
        Task SyncAll();
	}

    public class SyncManager: ISyncManager
    {
        private readonly ILogger<SyncManager> _logger;
        private readonly ApplicationDbContext _context;
        
        public SyncManager(ILogger<SyncManager> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task SyncAll()
        {
            List<ColourType> theList = SyncHelper.SyncTypesAndColours();

            _context.TrueTypes.AddRange(theList);

            await _context.SaveChangesAsync();
        }   
    }
}
