using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

}
