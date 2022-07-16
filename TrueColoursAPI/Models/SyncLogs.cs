using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AutoMapper;
using TrueColoursAPI.Helpers;

namespace TrueColoursAPI.Models
{
   public class SyncLog
   {  
       [Key]
       public int Id {get; set; }
       public DateTime Time { get; set; }
       public SyncType Type { get; set; }
       public ICollection<SyncLogDetail> Details { get; set; }
   }

   public class SyncLogDetail {
       [Key]
       public int Id {get; set; }
       public SyncAction Action { get; set; }
       public Colour Colour { get; set; }
   }

   public enum SyncType
   {
       Manual = 1,
       Auto = 2,
       Migration = 3
   }

   public enum SyncAction
   {
       Added = 1,
       Modified = 2,
       Removed = 3
   }
}