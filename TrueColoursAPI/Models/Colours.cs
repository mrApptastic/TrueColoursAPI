using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
}

