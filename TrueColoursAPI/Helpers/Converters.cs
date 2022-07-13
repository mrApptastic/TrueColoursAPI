using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Microsoft.EntityFrameworkCore;
using HtmlAgilityPack;
using System.Text;
using OfficeOpenXml;
using System.Drawing;
using TrueColoursAPI.Models;

namespace TrueColoursAPI.Helpers
{
    public class Converters
    {     
        public static string GetHexValue(Colour colour) {

            Color rgb = Color.FromArgb(colour.Red, colour.Green, colour.Blue);
            return "#" + rgb.R.ToString("X2") + rgb.G.ToString("X2") + rgb.B.ToString("X2");
        }

        public static string GetHSLValue(Colour colour) {
            float _R = colour.Red;
            float _G = colour.Green;
            float _B = colour.Blue;

            float _Min = Math.Min(Math.Min(_R, _G), _B);
            float _Max = Math.Max(Math.Max(_R, _G), _B);
            float _Delta = _Max - _Min;

            float H = 0;
            float S = 0;
            float L = (float)((_Max + _Min) / 2.0f);

            if (_Delta != 0)
            {
                if (L < 0.5f)
                {
                    S = (float)(_Delta / (_Max + _Min));
                }
                else
                {
                    S = (float)(_Delta / (2.0f - _Max - _Min));
                }


                if (_R == _Max)
                {
                    H = (_G - _B) / _Delta;
                }
                else if (_G == _Max)
                {
                    H = 2f + (_B - _R) / _Delta;
                }
                else if (_B == _Max)
                {
                    H = 4f + (_R - _G) / _Delta;
                }
            }

            return "hsl(" + H + "%, " + S + "%, " + L + "%)";
        }


    }

}
