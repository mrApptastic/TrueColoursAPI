using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Microsoft.EntityFrameworkCore;
using HtmlAgilityPack;
using System.Text;
using OfficeOpenXml;
using TrueColoursAPI.Models;

namespace TrueColoursAPI.Helpers
{
    public class SyncHelper
    {       
        public static (List<ColourType> data, SyncLog log) SyncTypesAndColours(List<ColourType> currentList = null)
        {
            List<ColourType> theList = new List<ColourType>();

            SyncLog theLog = new SyncLog() {
                Id = 0,
                Time = DateTime.Now,
                Type = currentList != null ? SyncType.Auto : SyncType.Migration,
                Details = new List<SyncLogDetail>()
            };

            List<Colour> werners = WernersHelper.GetWernersColours();

            var wernersCategory = new ColourType() {
                Id = 0,
                Name = "Werner's",
                Description = "Colour from Werner's Nomenclature of Colours. First published in 1814, this small volume comprises a collection of 110 swatches displaying nature's colour palette together with their poetical descriptions. In the 18th Century, German geologist Abraham Gottlob Werner set out to establish a standard reference guide to colour for use in the general sciences. Scottish flower painter Patrick Syme later enhanced and extended Werner's work to include all of the most common colours or tints that appear in nature, with each colour swatch accompanied by examples from the Animal, Vegetable and Mineral Kingdoms.",
                Colours = werners
            };

            theList.Add(wernersCategory);

            List<Colour> html = HtmlColourHelper.ScapeHtmlColours();

            var htmlCategory = new ColourType() {
                Id = 0,
                Name = "Html",
                Description = "Standard Html Colour Names",
                Colours = html
            };

            theList.Add(htmlCategory);

            List<ColourType> wiki = WikipediaColourHelper.ScapeWikipediaColours();

            theList.AddRange(wiki);

            if (currentList != null) {
                foreach (ColourType typ in currentList) {
                    ColourType refTyp = theList.Find(x => x.Name == typ.Name);

                    foreach (Colour clr in typ.Colours) {
                        Colour refClr = refTyp.Colours.Where(x => x.Name == clr.Name).FirstOrDefault();

                        if (refClr != null) {
                            refTyp.Colours.Remove(refClr);
                        }
                    }

                    if (refTyp.Colours.Count() == 0) {
                        theList.Remove(refTyp);
                    }
                }
            }

            foreach(ColourType cat in theList) {
                foreach (Colour col in cat.Colours) {
                    theLog.Details.Add(new SyncLogDetail() {
                        Id = 0,
                        Action = SyncAction.Added,
                        Colour = col.Name,
                        ColourType = cat.Name
                    });
                }
            }

            return (theList, theLog);
        }   

    }

}
