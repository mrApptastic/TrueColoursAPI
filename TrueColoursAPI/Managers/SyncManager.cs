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
            var lastLog = await _context.TrueSyncLogs.OrderBy(x => x.Time).LastOrDefaultAsync();

            if (lastLog != null) 
            {
                double lastSync = DateTime.Now.Subtract(lastLog.Time).TotalMinutes;

                if (lastSync < 15) {
                    string msg = String.Format("It has only been {0} minutes since the last time the data was synced. Try again in {1} minutes.", (int)lastSync, (int)(15 - lastSync));
                    throw new Exception(msg);
                }                //  
            }

            var syncResult = SyncHelper.SyncTypesAndColours(await _context.TrueTypes.Include(x => x.Colours).ToListAsync());
            
            List<ColourType> theList = syncResult.data;

            _context.TrueTypes.AddRange(theList);

            _context.TrueSyncLogs.Add(syncResult.log);

            await _context.SaveChangesAsync();
        }   
    }
}
