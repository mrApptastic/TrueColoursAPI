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
	public interface IColourManager {
        Task<ICollection<Colour>> GetNearest(int red, int green, int blue, int take = 10);
        Task<ICollection<HexViewModel>> GetNearestHex(int red, int green, int blue, int take = 10);
        Task<ICollection<HSLViewModel>> GetNearestHSL(int red, int green, int blue, int take = 10);
        Task<ICollection<RGBViewModel>> GetNearestRGB(int red, int green, int blue, int take = 10);
	}

    public class ColourManager: IColourManager
    {
        private readonly ILogger<ColourManager> _logger;
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        
        public ColourManager(ILogger<ColourManager> logger, IMapper mapper, ApplicationDbContext context)
        {
            _logger = logger;
            _mapper = mapper;
            _context = context;
        }

        public async Task<ICollection<Colour>> GetNearest(int red, int green, int blue, int take = 10)
        {
            return await _context.TrueColours.Include(x => x.ColourType).OrderBy(n => (Math.Abs(n.Red - red) + Math.Abs(n.Green - green) + Math.Abs(n.Blue - blue))).Take(take).ToListAsync();
        }

        public async Task<ICollection<HexViewModel>> GetNearestHex(int red, int green, int blue, int take = 10)
        {
            var colourList = await GetNearest(red, green, blue, take);
            return _mapper.Map<ICollection<Colour>, ICollection<HexViewModel>>(colourList);
        }

        public async Task<ICollection<HSLViewModel>> GetNearestHSL(int red, int green, int blue, int take = 10)
        {
            var colourList = await GetNearest(red, green, blue, take);
            return _mapper.Map<ICollection<Colour>, ICollection<HSLViewModel>>(colourList);
        }

        public async Task<ICollection<RGBViewModel>> GetNearestRGB(int red, int green, int blue, int take = 10)
        {
            var colourList = await GetNearest(red, green, blue, take);
            return _mapper.Map<ICollection<Colour>, ICollection<RGBViewModel>>(colourList);
        }
    }
}
