using TrueColoursAPI.Helpers;
using TrueColoursAPI.Models;

namespace TrueColoursAPI.Tests;

public class ConvertersTests
{
    [Fact]
    public void Base64Encode_ReturnsExpectedEncoding()
    {
        var result = Converters.Base64Encode("1");
        Assert.Equal("MQ==", result);
    }

    [Fact]
    public void Base64Decode_ReturnsExpectedDecoding()
    {
        var result = Converters.Base64Decode("MQ==");
        Assert.Equal("1", result);
    }

    [Fact]
    public void Base64Encode_Decode_RoundTrip()
    {
        var original = "Hello World 123";
        var encoded = Converters.Base64Encode(original);
        var decoded = Converters.Base64Decode(encoded);
        Assert.Equal(original, decoded);
    }

    [Fact]
    public void GetHexValue_ReturnsCorrectHex_ForBlack()
    {
        var colour = new Colour { Red = 0, Green = 0, Blue = 0 };
        var result = Converters.GetHexValue(colour);
        Assert.Equal("#000000", result);
    }

    [Fact]
    public void GetHexValue_ReturnsCorrectHex_ForWhite()
    {
        var colour = new Colour { Red = 255, Green = 255, Blue = 255 };
        var result = Converters.GetHexValue(colour);
        Assert.Equal("#FFFFFF", result);
    }

    [Fact]
    public void GetHexValue_ReturnsCorrectHex_ForRed()
    {
        var colour = new Colour { Red = 255, Green = 0, Blue = 0 };
        var result = Converters.GetHexValue(colour);
        Assert.Equal("#FF0000", result);
    }

    [Fact]
    public void GetHSLValue_ReturnsHSLString()
    {
        var colour = new Colour { Red = 255, Green = 0, Blue = 0 };
        var result = Converters.GetHSLValue(colour);
        Assert.StartsWith("hsl(", result);
        Assert.EndsWith(")", result);
    }

    [Fact]
    public void GetCMYKValue_ReturnsCorrectCMYK_ForBlack()
    {
        var colour = new Colour { Red = 0, Green = 0, Blue = 0 };
        var result = Converters.GetCMYKValue(colour);
        Assert.StartsWith("CMYK(", result);
        Assert.EndsWith(")", result);
        Assert.Contains(",1", result); // K should be 1 for black
    }

    [Fact]
    public void GetCMYKValue_ReturnsCorrectCMYK_ForWhite()
    {
        var colour = new Colour { Red = 255, Green = 255, Blue = 255 };
        var result = Converters.GetCMYKValue(colour);
        Assert.Equal("CMYK(0,0,0,0)", result);
    }

    [Theory]
    [InlineData(128, 64, 32)]
    [InlineData(0, 128, 255)]
    [InlineData(255, 255, 0)]
    public void GetHexValue_AlwaysReturnsSevenCharString(int r, int g, int b)
    {
        var colour = new Colour { Red = r, Green = g, Blue = b };
        var result = Converters.GetHexValue(colour);
        Assert.Equal(7, result.Length);
        Assert.StartsWith("#", result);
    }
}
