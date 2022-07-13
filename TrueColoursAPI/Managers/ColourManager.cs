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
	public interface IColourManager {
        Task<ICollection<Colour>> GetAll(int red, int green, int blue, int take = 10);
	}

    public class ColourManager: IColourManager
    {
        private readonly ILogger<ColourManager> _logger;
        private readonly ApplicationDbContext _context;
        
        public ColourManager(ILogger<ColourManager> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<ICollection<Colour>> GetAll(int red, int green, int blue, int take = 10)
        {
            return await _context.TrueColours.OrderBy(n => (Math.Abs(n.Red - red) + Math.Abs(n.Green - green) + Math.Abs(n.Blue - blue))).Take(take).ToListAsync();
        }   
    }
}
