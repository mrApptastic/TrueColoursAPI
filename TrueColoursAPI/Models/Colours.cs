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
       public string Hex { get; set; }
       public string Description { get; set; }
   }

   public class ColourProfile: Profile {
        public ColourProfile()
        {            
            CreateMap<Colour, ColourViewModel>()
                .ForMember(dest => dest.Hex, opts => opts.MapFrom(src => Converters.GetHexValue(src)));

            CreateMap<ColourViewModel, Colour>()
                .ForMember(dest => dest.Id, opts => opts.Ignore())
                .ForMember(dest => dest.Red, opts => opts.Ignore())
                .ForMember(dest => dest.Green, opts => opts.Ignore())
                .ForMember(dest => dest.Blue, opts => opts.Ignore());
                // 			.ForMember(dest => dest.Date, opts => opts.MapFrom(src => src.Date ?? new DateTime(2001, 1, 1)))
				// .ForMember(dest => dest.Deleted, opts => opts.MapFrom(src => src.Deleted == 1))
                // .ForMember(dest =>
                //     dest.FName,
                //     opt => opt.MapFrom(src => src.FirstName))
                // .ForMember(dest =>
                //     dest.LName,
                //     opt => opt.MapFrom(src => src.LastName))
        }
   }  
}

