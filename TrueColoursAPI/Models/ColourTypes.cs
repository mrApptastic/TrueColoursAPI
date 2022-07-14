using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AutoMapper;
using TrueColoursAPI.Helpers;

namespace TrueColoursAPI.Models
{
   public class ColourType
   {  
       [Key]
       public int Id {get; set; }
       public string Name { get; set; }
       public string Description { get; set; }
       public ICollection<Colour> Colours { get; set; }
   }

    public class ColourTypeViewModel
    {  
        public string PublicId {get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class ColourTypeProfile: Profile {
        public ColourTypeProfile()
        {            
            CreateMap<ColourType, ColourTypeViewModel>()
                .ForMember(dest => dest.PublicId, opts => opts.MapFrom(src => Converters.Base64Encode(src.Id.ToString())));

            CreateMap<ColourTypeViewModel, ColourType>()
                .ForMember(dest => dest.Id, opts => opts.Ignore())
                .ForMember(dest => dest.Colours, opts => opts.Ignore());
        }
    }  
}
