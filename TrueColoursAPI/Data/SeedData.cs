using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TrueColoursAPI.Data;
using TrueColoursAPI.Helpers;
using TrueColoursAPI.Models;

namespace TrueColoursAPI {

    public class SeedData {

        public static void SeedDatabase(ApplicationDbContext context) {            
            context.Database.EnsureCreated();

            if (context.TrueColours.Any()) {
                return;
            }

            var syncResult = SyncHelper.SyncTypesAndColours();
            
            List<ColourType> theList = syncResult.data;

            context.TrueTypes.AddRange(theList);

            context.TrueSyncLogs.Add(syncResult.log);

            context.SaveChanges();
        }
    }
}
