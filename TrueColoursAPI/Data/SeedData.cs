using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TrueColoursAPI.Data;
using TrueColoursAPI.Helpers;

namespace TrueColoursAPI {

    public class SeedData {

        public static void SeedDatabase(ApplicationDbContext context) {            
            if (context.Database.GetMigrations().Count() > 0
                    && context.Database.GetPendingMigrations().Count() == 0
                    && context.TrueColours.Count() == 0) {

                List<Colour> html = HtmlColourHelper.ScapeHtmlColours();

                var htmlCategory = new Type() {
                    Id = 0,
                    Name = "Html",
                    Description = "Standard Html Colour Names",
                    Colours = html
                };

                context.TrueTypes.Add(htmlCategory);

                List<Colour> wiki = WikipediaColourHelper.ScapeWikipediaColours();

                var wikiCategory = new Type() {
                    Id = 0,
                    Name = "Wikipedia",
                    Description = "Standard Wikipedia Colour Names",
                    Colours = wiki
                };

                context.TrueTypes.Add(wikiCategory);

                // context.SaveChanges();
            }
        }
    }
}
