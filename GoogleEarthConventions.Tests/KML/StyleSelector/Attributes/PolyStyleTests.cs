using GoogleEarthConversions.Core.KML.StyleSelector.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GoogleEarthConventions.Tests.KML.StyleSelector.Attributes
{
    public class PolyStyleTests
    {
        [Fact]
        public void PolyStyle_CanInstantiate()
        {
            var sut = new PolyStyle();

            Assert.NotNull(sut);
        }

        [Fact]
        public void PolyStyle_AllPropertiesInitialised()
        {
            var sut = new PolyStyle();

            foreach (var prop in sut.GetType().GetProperties())
            {
                var value = prop.GetValue(sut);
                Assert.NotNull(value);
            }
        }

        [Theory]
        [InlineData("", 255, 255, 255, 255, ColorModeEnum.Normal, false, false, "<PolyStyle></PolyStyle>")]
        [InlineData("ID", 255, 255, 255, 255, ColorModeEnum.Normal, false, false, "<PolyStyle id=\"ID\"></PolyStyle>")]
        [InlineData("ID", 255, 0, 0, 0, ColorModeEnum.Normal, false, false, "<PolyStyle id=\"ID\"><color>ff000000</color></PolyStyle>")]
        [InlineData("ID", 255, 0, 0, 0, ColorModeEnum.Random, false, false, "<PolyStyle id=\"ID\"><color>ff000000</color><colorMode>random</colorMode></PolyStyle>")]
        [InlineData("ID", 255, 0, 0, 0, ColorModeEnum.Random, true, false, "<PolyStyle id=\"ID\"><color>ff000000</color><colorMode>random</colorMode><fill>1</fill></PolyStyle>")]
        [InlineData("ID", 255, 0, 0, 0, ColorModeEnum.Random, true, true, "<PolyStyle id=\"ID\"><color>ff000000</color><colorMode>random</colorMode><fill>1</fill><outline>1</outline></PolyStyle>")]
        public void PolyStyle_CorrectlyConvertsToKML(string id, int colorAlpha, int colorRed, int colorGreen, int colorBlue, ColorModeEnum colorMode,
                                                     bool fill, bool outline, string expected)
        {
            var sut = new PolyStyle() { Id = id };
            sut.Color.Value = System.Drawing.Color.FromArgb(colorAlpha, colorRed, colorGreen, colorBlue);
            sut.ColorMode.Mode = colorMode;
            sut.Fill.Value = fill;
            sut.Outline.Value = outline;
            

            var result = sut.ConvertObjectToKML();

            Assert.Equal(expected, result);
        }
    }
}
