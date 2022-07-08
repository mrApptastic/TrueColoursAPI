using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Microsoft.EntityFrameworkCore;
using HtmlAgilityPack;
using System.Text;
using OfficeOpenXml;
using System.Drawing;

namespace TrueColoursAPI.Helpers
{
    public class Converters
    {     
        public static string GetHexValue(Colour colour) {

            Color rgb = Color.FromArgb(colour.Red, colour.Green, colour.Blue);
            return "#" + rgb.R.ToString("X2") + rgb.G.ToString("X2") + rgb.B.ToString("X2");
        }  


    }

}
