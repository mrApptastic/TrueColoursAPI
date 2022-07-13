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

namespace TrueColoursAPI.Managers
{
	public interface IColourTypeManager {
        Task<ICollection<ColourType>> GetAll();
	}

    public class ColourTypeManager: IColourTypeManager
    {
        private readonly ILogger<ColourTypeManager> _logger;
        private readonly ApplicationDbContext _context;
        
        public ColourTypeManager(ILogger<ColourTypeManager> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<ICollection<ColourType>> GetAll()
        {
            return await _context.TrueTypes.OrderBy(x => x.Name).ToListAsync();
        }   
    }
}
