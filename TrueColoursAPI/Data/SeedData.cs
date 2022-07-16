using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TrueColoursAPI.Data;
using TrueColoursAPI.Helpers;
using TrueColoursAPI.Models;

namespace TrueColoursAPI {

    public class SeedData {

        public static void SeedDatabase(ApplicationDbContext context) {            
            if (context.Database.GetMigrations().Count() > 0
                    && context.Database.GetPendingMigrations().Count() == 0
                    && context.TrueColours.Count() == 0) {

            var syncResult = SyncHelper.SyncTypesAndColours();
            
            List<ColourType> theList = syncResult.data;

            context.TrueTypes.AddRange(theList);

            context.TrueSyncLogs.Add(syncResult.log);

            context.SaveChanges();
            }
        }
    }
}
