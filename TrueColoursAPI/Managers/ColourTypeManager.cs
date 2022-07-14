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
	public interface IColourTypeManager {
        Task<ICollection<ColourTypeViewModel>> GetAll();
	}

    public class ColourTypeManager: IColourTypeManager
    {
        private readonly ILogger<ColourTypeManager> _logger;
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        
        public ColourTypeManager(ILogger<ColourTypeManager> logger, IMapper mapper, ApplicationDbContext context)
        {
            _logger = logger;
            _mapper = mapper;
            _context = context;
        }

        public async Task<ICollection<ColourTypeViewModel>> GetAll()
        {
            var types = await _context.TrueTypes.OrderBy(x => x.Name).ToListAsync();
            return _mapper.Map<ICollection<ColourType>, ICollection<ColourTypeViewModel>>(types);
        }   
    }
}
