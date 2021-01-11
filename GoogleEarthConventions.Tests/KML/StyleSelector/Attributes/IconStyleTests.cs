using GoogleEarthConversions.Core.KML.StyleSelector.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GoogleEarthConventions.Tests.KML.StyleSelector.Attributes
{
    public class IconStyleTests
    {
        [Fact]
        public void IconStyle_CanInstantiate()
        {
            var sut = new IconStyle();

            Assert.NotNull(sut);
        }

        [Fact]
        public void IconStyle_AllPropertiesInitialised()
        {
            var sut = new IconStyle();

            foreach (var prop in sut.GetType().GetProperties())
            {
                var value = prop.GetValue(sut);
                Assert.NotNull(value);
            }
        }

        [Theory]
        [InlineData("", 255, 255, 255, 255, ColorModeEnum.Normal, 1, 0, "", 0.5, 0.5, UnitsEnum.Fraction, UnitsEnum.Fraction, "")]
        [InlineData("ID", 255, 255, 255, 255, ColorModeEnum.Normal, 1, 0, "", 0.5, 0.5, UnitsEnum.Fraction, UnitsEnum.Fraction, "")]
        [InlineData("ID", 255, 0, 0, 0, ColorModeEnum.Normal, 1, 0, "", 0.5, 0.5, UnitsEnum.Fraction, UnitsEnum.Fraction, "<IconStyle id=\"ID\"><color>ff000000</color></IconStyle>")]
        [InlineData("ID", 255, 0, 0, 0, ColorModeEnum.Random, 1, 0, "", 0.5, 0.5, UnitsEnum.Fraction, UnitsEnum.Fraction, "<IconStyle id=\"ID\"><color>ff000000</color><colorMode>random</colorMode></IconStyle>")]
        [InlineData("ID", 255, 255, 255, 255, ColorModeEnum.Normal, 2, 0, "", 0.5, 0.5, UnitsEnum.Fraction, UnitsEnum.Fraction, "<IconStyle id=\"ID\"><scale>2</scale></IconStyle>")]
        [InlineData("ID", 255, 255, 255, 255, ColorModeEnum.Normal, 2, 110, "", 0.5, 0.5, UnitsEnum.Fraction, UnitsEnum.Fraction, "<IconStyle id=\"ID\"><scale>2</scale><heading>110</heading></IconStyle>")]
        [InlineData("ID", 255, 255, 255, 255, ColorModeEnum.Normal, 2, 361, "", 0.5, 0.5, UnitsEnum.Fraction, UnitsEnum.Fraction, "<IconStyle id=\"ID\"><scale>2</scale><heading>1</heading></IconStyle>")]
        [InlineData("ID", 255, 255, 255, 255, ColorModeEnum.Normal, 1, 0, "http://www.harrypotter.com", 0.5, 0.5, UnitsEnum.Fraction, UnitsEnum.Fraction, "<IconStyle id=\"ID\"><Icon><href>http://www.harrypotter.com</href></Icon></IconStyle>")]
        [InlineData("ID", 255, 0, 0, 0, ColorModeEnum.Normal, 1, 0, "", 0.4, 0.5, UnitsEnum.Fraction, UnitsEnum.Fraction, "<IconStyle id=\"ID\"><color>ff000000</color><hotSpot x=\"0.4\" y=\"0.5\" xunits=\"fraction\" yunits=\"fraction\"/></IconStyle>")]
        public void IconStyle_CorrectlyConvertsToKML(string id, int colorAlpha, int colorRed, int colorGreen, int colorBlue, ColorModeEnum colorMode,
                                                     double scale, double heading, string uri, 
                                                     double x, double y, UnitsEnum xunits, UnitsEnum yunits, string expected)
        {
            var sut = new IconStyle() { Id = id };
            sut.Color.Value = System.Drawing.Color.FromArgb(colorAlpha, colorRed, colorGreen, colorBlue);
            sut.ColorMode.Mode = colorMode;
            sut.Scale.Value = scale;
            sut.Heading.Value = heading;
            sut.Icon.Href = uri;
            sut.HotSpot.X = x;
            sut.HotSpot.Y = y;
            sut.HotSpot.Xunits = xunits;
            sut.HotSpot.Yunits = yunits;

            var result = sut.ConvertObjectToKML();

            Assert.Equal(expected, result);
        }
    }
}
