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
        public static List<ColourType> SyncTypesAndColours()
        {
            List<ColourType> theList = new List<ColourType>();

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

            return theList;
        }   

    }

}
