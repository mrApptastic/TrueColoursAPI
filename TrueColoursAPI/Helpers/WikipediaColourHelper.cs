using System.Runtime.InteropServices.ComTypes;
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
    public class WikipediaColourHelper
    {       
        public static List<ColourType> ScapeWikipediaColours() {
            HtmlWeb web = new HtmlWeb();
            web.AutoDetectEncoding = true;
            web.OverrideEncoding = Encoding.UTF8;

            var theList = new List<ColourType>();

            var site = web.Load("https://en.wikipedia.org/wiki/List_of_colors_(compact)");

            HtmlNodeCollection rows = site.DocumentNode.SelectNodes("//div");

            foreach (HtmlNode row in rows) {
                foreach (HtmlAttribute attr in row.Attributes) {
                    if (attr?.Name == "style") {
                        if (attr?.Value == "float:left;display:inline;font-size:90%;margin:1px 5px 1px 5px;width:11em; height:6em;text-align:center;padding:auto;") {
                            var ib = row?.InnerHtml.ToString();
                            var start = ib.IndexOf("background-color:rgb(");
                            var ibi = ib.Substring(start + 21);
                            var end = ibi.IndexOf("); ");
                            int catStart = ibi.IndexOf("\" title=\"");                            
                            string prop = ibi.Substring(catStart + 9);
                            int catEnd = prop.IndexOf("\">");

                            var rgb = ibi.Substring(0, end);
                            string name = row?.InnerText.Replace(@"\n","").Replace(" ","").Trim();
                            string category = prop.Substring(0, catEnd).Split(" (page does not exist)")[0].Replace("&#39;", "'");

                            if (category.Contains("border:solid")) {
                                category = "Uncategorized (Wikipedia)";
                            }

                            ColourType cat = theList.Find(x => x.Name == category);

                            Colour newColour = new Colour() {
                                Id = 0,
                                Name = name,
                                Red = int.Parse(rgb.Split(",")[0]),
                                Green = int.Parse(rgb.Split(",")[1]),
                                Blue = int.Parse(rgb.Split(",")[2]),
                                Description = "Colour Name " + name + " from the Category " + category + " from Wikipedia"
                            };

                            if (cat != null) {                                
                                cat.Colours.Add(newColour);
                            } else {

                                ColourType newCat = new ColourType() {
                                    Id = 0,
                                    Name = category,
                                    Description = category + " from Wikipedia",
                                    Colours = new List<Colour>() { newColour }
                                };

                                theList.Add(newCat);
                            }
                        }
                    }
                }
            }

            return theList;
        }

    }

}
