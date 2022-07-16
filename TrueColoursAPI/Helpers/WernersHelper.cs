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
    public class WernersHelper
    {       
        public static List<Colour> GetWernersColours() {
            var theList = new List<Colour>();

            theList.AddRange(new List<Colour>() {
                new Colour() { Id = 0, Name = "AppleGreen", Red = 82, Green = 19, Blue = 65, Description = "Colour from Werner's Nomenclature of Colours" },
                new Colour() { Id = 0, Name = "ArterialBloodRed", Red = 358, Green = 100, Blue = 23, Description = "Colour from Werner's Nomenclature of Colours" },
                new Colour() { Id = 0, Name = "AshGrey", Red = 137, Green = 8, Blue = 83, Description = "Colour from Werner's Nomenclature of Colours" },
                new Colour() { Id = 0, Name = "AsparagusGreen", Red = 77, Green = 30, Blue = 79, Description = "Colour from Werner's Nomenclature of Colours" },
                new Colour() { Id = 0, Name = "AuriculaPurple", Red = 267, Green = 47, Blue = 22, Description = "Colour from Werner's Nomenclature of Colours" },
                new Colour() { Id = 0, Name = "AuroraRed", Red = 7, Green = 63, Blue = 56, Description = "Colour from Werner's Nomenclature of Colours" },
                new Colour() { Id = 0, Name = "AzureBlue", Red = 227, Green = 33, Blue = 49, Description = "Colour from Werner's Nomenclature of Colours" },
                new Colour() { Id = 0, Name = "BerlinBlue", Red = 221, Green = 58, Blue = 67, Description = "Colour from Werner's Nomenclature of Colours" },
                new Colour() { Id = 0, Name = "BlackishBrown", Red = 49, Green = 44, Blue = 14, Description = "Colour from Werner's Nomenclature of Colours" },
                new Colour() { Id = 0, Name = "BlackishGreen", Red = 219, Green = 9, Blue = 32, Description = "Colour from Werner's Nomenclature of Colours" },
                new Colour() { Id = 0, Name = "BlackishGrey", Red = 228, Green = 17, Blue = 35, Description = "Colour from Werner's Nomenclature of Colours" },
                new Colour() { Id = 0, Name = "BluishBlack", Red = 233, Green = 17, Blue = 21, Description = "Colour from Werner's Nomenclature of Colours" },
                new Colour() { Id = 0, Name = "BluishGreen", Red = 128, Green = 9, Blue = 67, Description = "Colour from Werner's Nomenclature of Colours" },
                new Colour() { Id = 0, Name = "BluishGrey", Red = 221, Green = 17, Blue = 66, Description = "Colour from Werner's Nomenclature of Colours" },
                new Colour() { Id = 0, Name = "BluishLilacPurple", Red = 211, Green = 95, Blue = 92, Description = "Colour from Werner's Nomenclature of Colours" },
                new Colour() { Id = 0, Name = "BluishPurple", Red = 226, Green = 43, Blue = 64, Description = "Colour from Werner's Nomenclature of Colours" },
                new Colour() { Id = 0, Name = "BroccoliBrown", Red = 44, Green = 21, Blue = 48, Description = "Colour from Werner's Nomenclature of Colours" },
                new Colour() { Id = 0, Name = "BrownishOrange", Red = 13, Green = 100, Blue = 33, Description = "Colour from Werner's Nomenclature of Colours" },
                new Colour() { Id = 0, Name = "BrownishPurpleRed", Red = 356, Green = 52, Blue = 49, Description = "Colour from Werner's Nomenclature of Colours" },
                new Colour() { Id = 0, Name = "BrownishRed", Red = 359, Green = 95, Blue = 31, Description = "Colour from Werner's Nomenclature of Colours" },
                new Colour() { Id = 0, Name = "BuffOrange", Red = 21, Green = 99, Blue = 55, Description = "Colour from Werner's Nomenclature of Colours" },
                new Colour() { Id = 0, Name = "CampanulaPurple", Red = 235, Green = 31, Blue = 51, Description = "Colour from Werner's Nomenclature of Colours" },
                new Colour() { Id = 0, Name = "CarmineRed", Red = 349, Green = 85, Blue = 50, Description = "Colour from Werner's Nomenclature of Colours" },
                new Colour() { Id = 0, Name = "CelandineGreen", Red = 88, Green = 10, Blue = 71, Description = "Colour from Werner's Nomenclature of Colours" },
                new Colour() { Id = 0, Name = "ChesnutBrown", Red = 28, Green = 57, Blue = 26, Description = "Colour from Werner's Nomenclature of Colours" },
                new Colour() { Id = 0, Name = "ChinaBlue", Red = 237, Green = 48, Blue = 28, Description = "Colour from Werner's Nomenclature of Colours" },
                new Colour() { Id = 0, Name = "ChocolateRed", Red = 356, Green = 97, Blue = 23, Description = "Colour from Werner's Nomenclature of Colours" },
                new Colour() { Id = 0, Name = "CochinealRed", Red = 356, Green = 87, Blue = 35, Description = "Colour from Werner's Nomenclature of Colours" },
                new Colour() { Id = 0, Name = "CreamYellow", Red = 52, Green = 100, Blue = 86, Description = "Colour from Werner's Nomenclature of Colours" },
                new Colour() { Id = 0, Name = "CrimsonRed", Red = 351, Green = 72, Blue = 56, Description = "Colour from Werner's Nomenclature of Colours" },
                new Colour() { Id = 0, Name = "DeepOrangeColouredBrown", Red = 24, Green = 68, Blue = 27, Description = "Colour from Werner's Nomenclature of Colours" },
                new Colour() { Id = 0, Name = "DeepReddishBrown", Red = 21, Green = 54, Blue = 20, Description = "Colour from Werner's Nomenclature of Colours" },
                new Colour() { Id = 0, Name = "DeepReddishOrange", Red = 21, Green = 100, Blue = 40, Description = "Colour from Werner's Nomenclature of Colours" },
                new Colour() { Id = 0, Name = "DuckGreen", Red = 98, Green = 25, Blue = 21, Description = "Colour from Werner's Nomenclature of Colours" },
                new Colour() { Id = 0, Name = "DutchOrange", Red = 43, Green = 100, Blue = 48, Description = "Colour from Werner's Nomenclature of Colours" },
                new Colour() { Id = 0, Name = "EmeraldGreen", Red = 90, Green = 29, Blue = 59, Description = "Colour from Werner's Nomenclature of Colours" },
                new Colour() { Id = 0, Name = "Flax-FlowerBlue", Red = 223, Green = 53, Blue = 63, Description = "Colour from Werner's Nomenclature of Colours" },
                new Colour() { Id = 0, Name = "FleshRed", Red = 29, Green = 98, Blue = 82, Description = "Colour from Werner's Nomenclature of Colours" },
                new Colour() { Id = 0, Name = "FrenchGrey", Red = 217, Green = 23, Blue = 80, Description = "Colour from Werner's Nomenclature of Colours" },
                new Colour() { Id = 0, Name = "GallstoneYellow", Red = 37, Green = 100, Blue = 32, Description = "Colour from Werner's Nomenclature of Colours" },
                new Colour() { Id = 0, Name = "GambogeYellow", Red = 56, Green = 96, Blue = 65, Description = "Colour from Werner's Nomenclature of Colours" },
                new Colour() { Id = 0, Name = "GrassGreen", Red = 86, Green = 18, Blue = 51, Description = "Colour from Werner's Nomenclature of Colours" },
                new Colour() { Id = 0, Name = "GreenishBlack", Red = 223, Green = 13, Blue = 22, Description = "Colour from Werner's Nomenclature of Colours" },
                new Colour() { Id = 0, Name = "GreenishBlue", Red = 205, Green = 36, Blue = 61, Description = "Colour from Werner's Nomenclature of Colours" },
                new Colour() { Id = 0, Name = "GreenishGrey", Red = 207, Green = 9, Blue = 55, Description = "Colour from Werner's Nomenclature of Colours" },
                new Colour() { Id = 0, Name = "GreenishWhite", Red = 84, Green = 56, Blue = 98, Description = "Colour from Werner's Nomenclature of Colours" },
                new Colour() { Id = 0, Name = "GreyishBlack", Red = 232, Green = 10, Blue = 29, Description = "Colour from Werner's Nomenclature of Colours" },
                new Colour() { Id = 0, Name = "GreyishBlue", Red = 211, Green = 33, Blue = 66, Description = "Colour from Werner's Nomenclature of Colours" },
                new Colour() { Id = 0, Name = "GreyishWhite", Red = 202, Green = 20, Blue = 92, Description = "Colour from Werner's Nomenclature of Colours" },
                new Colour() { Id = 0, Name = "HairBrown", Red = 49, Green = 29, Blue = 40, Description = "Colour from Werner's Nomenclature of Colours" },
                new Colour() { Id = 0, Name = "HoneyYellow", Red = 45, Green = 95, Blue = 35, Description = "Colour from Werner's Nomenclature of Colours" },
                new Colour() { Id = 0, Name = "HyacinthRed", Red = 10, Green = 67, Blue = 41, Description = "Colour from Werner's Nomenclature of Colours" },
                new Colour() { Id = 0, Name = "ImperialPurple", Red = 245, Green = 39, Blue = 37, Description = "Colour from Werner's Nomenclature of Colours" },
                new Colour() { Id = 0, Name = "IndigoBlue", Red = 225, Green = 39, Blue = 45, Description = "Colour from Werner's Nomenclature of Colours" },
                new Colour() { Id = 0, Name = "InkBlack", Red = 240, Green = 27, Blue = 6, Description = "Colour from Werner's Nomenclature of Colours" },
                new Colour() { Id = 0, Name = "KingsYellow", Red = 57, Green = 100, Blue = 69, Description = "Colour from Werner's Nomenclature of Colours" },
                new Colour() { Id = 0, Name = "LakeRed", Red = 344, Green = 89, Blue = 45, Description = "Colour from Werner's Nomenclature of Colours" },
                new Colour() { Id = 0, Name = "LavendarPurple", Red = 234, Green = 15, Blue = 48, Description = "Colour from Werner's Nomenclature of Colours" },
                new Colour() { Id = 0, Name = "LeekGreen", Red = 180, Green = 2, Blue = 58, Description = "Colour from Werner's Nomenclature of Colours" },
                new Colour() { Id = 0, Name = "LemonYellow", Red = 52, Green = 83, Blue = 65, Description = "Colour from Werner's Nomenclature of Colours" },
                new Colour() { Id = 0, Name = "LiverBrown", Red = 40, Green = 52, Blue = 16, Description = "Colour from Werner's Nomenclature of Colours" },
                new Colour() { Id = 0, Name = "MountainGreen", Red = 67, Green = 14, Blue = 64, Description = "Colour from Werner's Nomenclature of Colours" },
                new Colour() { Id = 0, Name = "OchreYellow", Red = 50, Green = 94, Blue = 72, Description = "Colour from Werner's Nomenclature of Colours" },
                new Colour() { Id = 0, Name = "OilGreen", Red = 49, Green = 32, Blue = 53, Description = "Colour from Werner's Nomenclature of Colours" },
                new Colour() { Id = 0, Name = "OliveBrown", Red = 40, Green = 27, Blue = 33, Description = "Colour from Werner's Nomenclature of Colours" },
                new Colour() { Id = 0, Name = "OliveGreen", Red = 147, Green = 8, Blue = 46, Description = "Colour from Werner's Nomenclature of Colours" },
                new Colour() { Id = 0, Name = "OrangeWhite", Red = 43, Green = 54, Blue = 97, Description = "Colour from Werner's Nomenclature of Colours" },
                new Colour() { Id = 0, Name = "OrpimentOrange", Red = 30, Green = 100, Blue = 44, Description = "Colour from Werner's Nomenclature of Colours" },
                new Colour() { Id = 0, Name = "PaleBluishPurple", Red = 239, Green = 31, Blue = 28, Description = "Colour from Werner's Nomenclature of Colours" },
                new Colour() { Id = 0, Name = "PansyPurple", Red = 244, Green = 45, Blue = 19, Description = "Colour from Werner's Nomenclature of Colours" },
                new Colour() { Id = 0, Name = "PeachBlossomRed", Red = 16, Green = 100, Blue = 92, Description = "Colour from Werner's Nomenclature of Colours" },
                new Colour() { Id = 0, Name = "PearlGrey", Red = 218, Green = 18, Blue = 76, Description = "Colour from Werner's Nomenclature of Colours" },
                new Colour() { Id = 0, Name = "PistachioGreen", Red = 73, Green = 29, Blue = 52, Description = "Colour from Werner's Nomenclature of Colours" },
                new Colour() { Id = 0, Name = "PitchOrBrownishBlack", Red = 274, Green = 8, Blue = 17, Description = "Colour from Werner's Nomenclature of Colours" },
                new Colour() { Id = 0, Name = "PlumPurple", Red = 249, Green = 48, Blue = 24, Description = "Colour from Werner's Nomenclature of Colours" },
                new Colour() { Id = 0, Name = "PrimroseYellow", Red = 59, Green = 100, Blue = 85, Description = "Colour from Werner's Nomenclature of Colours" },
                new Colour() { Id = 0, Name = "PrussianBlue", Red = 239, Green = 83, Blue = 14, Description = "Colour from Werner's Nomenclature of Colours" },
                new Colour() { Id = 0, Name = "PurplishRed", Red = 352, Green = 100, Blue = 27, Description = "Colour from Werner's Nomenclature of Colours" },
                new Colour() { Id = 0, Name = "PurplishWhite", Red = 223, Green = 47, Blue = 97, Description = "Colour from Werner's Nomenclature of Colours" },
                new Colour() { Id = 0, Name = "ReddishBlack", Red = 309, Green = 9, Blue = 15, Description = "Colour from Werner's Nomenclature of Colours" },
                new Colour() { Id = 0, Name = "ReddishOrange", Red = 28, Green = 100, Blue = 41, Description = "Colour from Werner's Nomenclature of Colours" },
                new Colour() { Id = 0, Name = "ReddishWhite", Red = 300, Green = 9, Blue = 98, Description = "Colour from Werner's Nomenclature of Colours" },
                new Colour() { Id = 0, Name = "RedLilacPurple", Red = 228, Green = 46, Blue = 83, Description = "Colour from Werner's Nomenclature of Colours" },
                new Colour() { Id = 0, Name = "RoseRed", Red = 38, Green = 100, Blue = 93, Description = "Colour from Werner's Nomenclature of Colours" },
                new Colour() { Id = 0, Name = "SaffronYellow", Red = 44, Green = 82, Blue = 48, Description = "Colour from Werner's Nomenclature of Colours" },
                new Colour() { Id = 0, Name = "SapGreen", Red = 73, Green = 33, Blue = 43, Description = "Colour from Werner's Nomenclature of Colours" },
                new Colour() { Id = 0, Name = "ScarletRed", Red = 359, Green = 71, Blue = 43, Description = "Colour from Werner's Nomenclature of Colours" },
                new Colour() { Id = 0, Name = "ScotchBlue", Red = 246, Green = 59, Blue = 12, Description = "Colour from Werner's Nomenclature of Colours" },
                new Colour() { Id = 0, Name = "SiennaYellow", Red = 52, Green = 97, Blue = 76, Description = "Colour from Werner's Nomenclature of Colours" },
                new Colour() { Id = 0, Name = "SiskinGreen", Red = 67, Green = 56, Blue = 72, Description = "Colour from Werner's Nomenclature of Colours" },
                new Colour() { Id = 0, Name = "SkimmedMilkWhite", Red = 204, Green = 16, Blue = 94, Description = "Colour from Werner's Nomenclature of Colours" },
                new Colour() { Id = 0, Name = "SmokeGrey", Red = 218, Green = 18, Blue = 79, Description = "Colour from Werner's Nomenclature of Colours" },
                new Colour() { Id = 0, Name = "SnowWhite", Red = 90, Green = 17, Blue = 98, Description = "Colour from Werner's Nomenclature of Colours" },
                new Colour() { Id = 0, Name = "StrawYellow", Red = 52, Green = 96, Blue = 79, Description = "Colour from Werner's Nomenclature of Colours" },
                new Colour() { Id = 0, Name = "SulphurYellow", Red = 45, Green = 112, Blue = 65, Description = "Colour from Werner's Nomenclature of Colours" },
                new Colour() { Id = 0, Name = "TileRed", Red = 8, Green = 60, Blue = 54, Description = "Colour from Werner's Nomenclature of Colours" },
                new Colour() { Id = 0, Name = "UltramarineBlue", Red = 229, Green = 69, Blue = 63, Description = "Colour from Werner's Nomenclature of Colours" },
                new Colour() { Id = 0, Name = "UmberBrown", Red = 35, Green = 51, Blue = 18, Description = "Colour from Werner's Nomenclature of Colours" },
                new Colour() { Id = 0, Name = "VeinousBloodRed", Red = 356, Green = 98, Blue = 20, Description = "Colour from Werner's Nomenclature of Colours" },
                new Colour() { Id = 0, Name = "VelvetBlack", Red = 240, Green = 20, Blue = 5, Description = "Colour from Werner's Nomenclature of Colours" },
                new Colour() { Id = 0, Name = "VerdigrisGreen", Red = 145, Green = 25, Blue = 55, Description = "Colour from Werner's Nomenclature of Colours" },
                new Colour() { Id = 0, Name = "VerditterBlue", Red = 195, Green = 51, Blue = 67, Description = "Colour from Werner's Nomenclature of Colours" },
                new Colour() { Id = 0, Name = "VermillionRed", Red = 2, Green = 66, Blue = 45, Description = "Colour from Werner's Nomenclature of Colours" },
                new Colour() { Id = 0, Name = "VioletPurple", Red = 247, Green = 57, Blue = 21, Description = "Colour from Werner's Nomenclature of Colours" },
                new Colour() { Id = 0, Name = "WaxYellow", Red = 47, Green = 58, Blue = 47, Description = "Colour from Werner's Nomenclature of Colours" },
                new Colour() { Id = 0, Name = "WineYellow", Red = 55, Green = 68, Blue = 68, Description = "Colour from Werner's Nomenclature of Colours" },
                new Colour() { Id = 0, Name = "WoodBrown", Red = 43, Green = 42, Blue = 58, Description = "Colour from Werner's Nomenclature of Colours" },
                new Colour() { Id = 0, Name = "YellowishBrown", Red = 39, Green = 53, Blue = 35, Description = "Colour from Werner's Nomenclature of Colours" },
                new Colour() { Id = 0, Name = "YellowishGrey", Red = 67, Green = 12, Blue = 70, Description = "Colour from Werner's Nomenclature of Colours" },
                new Colour() { Id = 0, Name = "YellowishWhite", Red = 60, Green = 38, Blue = 97, Description = "Colour from Werner's Nomenclature of Colours" }
            });

            return theList;
        }

    }

}
