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
        Task<ICollection<HexViewModel>> GetNearestHex(int red, int green, int blue, int take = 10, string[] categoryList = null);
        Task<ICollection<HSLViewModel>> GetNearestHSL(int red, int green, int blue, int take = 10, string[] categoryList = null);
        Task<ICollection<RGBViewModel>> GetNearestRGB(int red, int green, int blue, int take = 10, string[] categoryList = null);
        Task<ICollection<CMYKViewModel>> GetNearestCMYK(int red, int green, int blue, int take = 10, string[] categoryList = null);
        Task<(ICollection<HexViewModel> results, int count)> SearchHexColours(ColourSearchModel searchDto, int page = 1, int take = 50);
        Task<(ICollection<HSLViewModel> results, int count)> SearchHSLColours(ColourSearchModel searchDto, int page = 1, int take = 50);
        Task<(ICollection<RGBViewModel> results, int count)> SearchRGBColours(ColourSearchModel searchDto, int page = 1, int take = 50);
        Task<(ICollection<CMYKViewModel> results, int count)> SearchCMYKColours(ColourSearchModel searchDto, int page = 1, int take = 50);
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

        private async Task<ICollection<Colour>> GetNearest(int red, int green, int blue, int take = 10, string[] categoryList = null)
        {
            var query = _context.TrueColours.Include(x => x.ColourType).AsQueryable();

            List<int> types = new List<int>();

            if (categoryList != null) {
                foreach (string category in categoryList) {
                    string baseValue = "";
                    
                    try {
                        baseValue = Converters.Base64Decode(category);
                    } catch {}
                    
                    int.TryParse(baseValue, out int typeId);

                    if (typeId > 0) {
                        types.Add(typeId);
                    }
                }
                
                if (types.Count() > 0) {
                    query = query.Where(x => types.Contains(x.ColourType.Id));
                }
                
            }

            return await query.OrderBy(n => (Math.Abs(n.Red - red) + Math.Abs(n.Green - green) + Math.Abs(n.Blue - blue))).Take(take).ToListAsync();
        }

        private async Task<(ICollection<Colour> results, int count)> Search(ColourSearchModel searchDto, int page = 1, int take = 50)
        {
            var query = _context.TrueColours.Include(x => x.ColourType).AsQueryable();

            List<int> types = new List<int>();

            if (searchDto.Types != null) {
                foreach (string category in searchDto.Types) {
                    string baseValue = "";
                    
                    try {
                        baseValue = Converters.Base64Decode(category);
                    } catch {}
                    
                    int.TryParse(baseValue, out int typeId);

                    if (typeId > 0) {
                        types.Add(typeId);
                    }
                }
                
                if (types.Count() > 0) {
                    query = query.Where(x => types.Contains(x.ColourType.Id));
                }
            }

            if (searchDto.Name != null) {
                query = query.Where(x => x.Name.ToLower().Contains(searchDto.Name.ToLower()));
            }

            int count = await query.CountAsync();

            var results = await query.OrderBy(x => x.Name).Skip((page -1) * 50).Take(take).ToListAsync();

            return (results, count);     
        }

        public async Task<ICollection<HexViewModel>> GetNearestHex(int red, int green, int blue, int take = 10, string[] categoryList = null)
        {
            var colourList = await GetNearest(red, green, blue, take, categoryList);
            return _mapper.Map<ICollection<Colour>, ICollection<HexViewModel>>(colourList);
        }

        public async Task<ICollection<HSLViewModel>> GetNearestHSL(int red, int green, int blue, int take = 10, string[] categoryList = null)
        {
            var colourList = await GetNearest(red, green, blue, take, categoryList);
            return _mapper.Map<ICollection<Colour>, ICollection<HSLViewModel>>(colourList);
        }

        public async Task<ICollection<RGBViewModel>> GetNearestRGB(int red, int green, int blue, int take = 10, string[] categoryList = null)
        {
            var colourList = await GetNearest(red, green, blue, take, categoryList);
            return _mapper.Map<ICollection<Colour>, ICollection<RGBViewModel>>(colourList);
        }

        public async Task<ICollection<CMYKViewModel>> GetNearestCMYK(int red, int green, int blue, int take = 10, string[] categoryList = null)
        {
            var colourList = await GetNearest(red, green, blue, take, categoryList);
            return _mapper.Map<ICollection<Colour>, ICollection<CMYKViewModel>>(colourList);
        }

        public async Task<(ICollection<HexViewModel> results, int count)> SearchHexColours(ColourSearchModel searchDto, int page = 1, int take = 50)
        {
            var searchResult = await Search(searchDto, page, take);

            return (_mapper.Map<ICollection<Colour>, ICollection<HexViewModel>>(searchResult.results), searchResult.count); 
        }

        public async Task<(ICollection<HSLViewModel> results, int count)> SearchHSLColours(ColourSearchModel searchDto, int page = 1, int take = 50)
        {
            var searchResult = await Search(searchDto, page, take);

            return (_mapper.Map<ICollection<Colour>, ICollection<HSLViewModel>>(searchResult.results), searchResult.count); 
        }

        public async Task<(ICollection<RGBViewModel> results, int count)> SearchRGBColours(ColourSearchModel searchDto, int page = 1, int take = 50)
        {
            var searchResult = await Search(searchDto, page, take);

            return (_mapper.Map<ICollection<Colour>, ICollection<RGBViewModel>>(searchResult.results), searchResult.count); 
        }

        public async Task<(ICollection<CMYKViewModel> results, int count)> SearchCMYKColours(ColourSearchModel searchDto, int page = 1, int take = 50)
        {
            var searchResult = await Search(searchDto, page, take);

            return (_mapper.Map<ICollection<Colour>, ICollection<CMYKViewModel>>(searchResult.results), searchResult.count); 
        }
    }
}
