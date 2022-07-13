using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AutoMapper;
using TrueColoursAPI.Helpers;

namespace TrueColoursAPI
{
    public class Colour
    {  
        [Key]
        public int Id {get; set; }
        public string Name { get; set; }
        public int Red { get; set; }
        public int Green { get; set; }
        public int Blue { get; set; }
        public string Description { get; set; }
    }

    public class ColourViewModel
    {  
        public string Name { get; set; }
        public string Description { get; set; }
    }

        public class RGBViewModel: ColourViewModel {
            public string RGB { get; set; }
        }

        public class HexViewModel: ColourViewModel {
            public string Hex { get; set; }
        }

        public class HSLViewModel: ColourViewModel {
            public string HSL { get; set; }
        }

    public class ColourProfile: Profile {
            public ColourProfile()
            {            
                CreateMap<Colour, RGBViewModel>()
                    .ForMember(dest => dest.RGB, opts => opts.MapFrom(src => String.Format("rgb({0},{1},{2})", src.Red, src.Green, src.Blue)));

                CreateMap<RGBViewModel, Colour>()
                    .ForMember(dest => dest.Id, opts => opts.Ignore())
                    .ForMember(dest => dest.Red, opts => opts.Ignore())
                    .ForMember(dest => dest.Green, opts => opts.Ignore())
                    .ForMember(dest => dest.Blue, opts => opts.Ignore());

                CreateMap<Colour, HexViewModel>()
                    .ForMember(dest => dest.Hex, opts => opts.MapFrom(src => Converters.GetHexValue(src)));

                CreateMap<HexViewModel, Colour>()
                    .ForMember(dest => dest.Id, opts => opts.Ignore())
                    .ForMember(dest => dest.Red, opts => opts.Ignore())
                    .ForMember(dest => dest.Green, opts => opts.Ignore())
                    .ForMember(dest => dest.Blue, opts => opts.Ignore());
                
                CreateMap<Colour, HSLViewModel>()
                    .ForMember(dest => dest.HSL, opts => opts.MapFrom(src => Converters.GetHSLValue(src)));

                CreateMap<HSLViewModel, Colour>()
                    .ForMember(dest => dest.Id, opts => opts.Ignore())
                    .ForMember(dest => dest.Red, opts => opts.Ignore())
                    .ForMember(dest => dest.Green, opts => opts.Ignore())
                    .ForMember(dest => dest.Blue, opts => opts.Ignore());
            }
    }  
}

