using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Microsoft.EntityFrameworkCore;
using HtmlAgilityPack;
using System.Text;
using OfficeOpenXml;

namespace TrueColoursAPI.Helpers
{
    public class WikipediaColourHelper
    {       
        public static List<Colour> ScapeWikipediaColours() {
            HtmlWeb web = new HtmlWeb();
            web.AutoDetectEncoding = false;
            web.OverrideEncoding = Encoding.GetEncoding("iso-8859-1");

            var theList = new List<Colour>();

            var site = web.Load("https://en.wikipedia.org/wiki/List_of_colors:_A%E2%80%93F");

            HtmlNodeCollection rows = site.DocumentNode.SelectNodes("//tr");

            foreach (HtmlNode row in rows) {
                if (row.FirstChild.Name.ToString().ToLower() == "td") {
                    string name = row.FirstChild.InnerText.Trim();
                    string code = row.LastChild.InnerText.Trim();

                    theList.Add(new Colour() {
                        Id = 0,
                        Name = name,
                        Red = int.Parse(code.Split(",")[0]),
                        Green = int.Parse(code.Split(",")[1]),
                        Blue = int.Parse(code.Split(",")[2]),
                        Description = "HTML Colour Name " + name
                    });
                }
            }

            return theList;
        }

    }

}
