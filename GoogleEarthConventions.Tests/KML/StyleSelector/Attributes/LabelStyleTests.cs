using GoogleEarthConversions.Core.KML.StyleSelector.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GoogleEarthConventions.Tests.KML.StyleSelector.Attributes
{
    public class LabelStyleTests
    {
        [Fact]
        public void LabelStyle_CanInstantiate()
        {
            var sut = new LabelStyle();

            Assert.NotNull(sut);
        }

        [Fact]
        public void LabelStyle_AllPropertiesInitialised()
        {
            var sut = new LabelStyle();

            foreach (var prop in sut.GetType().GetProperties())
            {
                var value = prop.GetValue(sut);
                Assert.NotNull(value);
            }
        }

        [Theory]
        [InlineData("", 255, 255, 255, 255, ColorModeEnum.Normal, 1, "")]
        [InlineData("ID", 255, 255, 255, 255, ColorModeEnum.Normal, 1, "")]
        [InlineData("ID", 255, 0, 0, 0, ColorModeEnum.Normal, 1, "<LabelStyle id=\"ID\"><color>ff000000</color></LabelStyle>")]
        [InlineData("ID", 255, 0, 0, 0, ColorModeEnum.Random, 1, "<LabelStyle id=\"ID\"><color>ff000000</color><colorMode>random</colorMode></LabelStyle>")]
        [InlineData("ID", 255, 255, 255, 255, ColorModeEnum.Normal, 1.5, "<LabelStyle id=\"ID\"><scale>1.5</scale></LabelStyle>")]
        public void LabelStyle_CorrectlyConvertsToKML(string id, int colorAlpha, int colorRed, int colorGreen, int colorBlue, ColorModeEnum colorMode,
                                                     double scale, string expected)
        {
            var sut = new LabelStyle() { Id = id };
            sut.Color.Value = System.Drawing.Color.FromArgb(colorAlpha, colorRed, colorGreen, colorBlue);
            sut.ColorMode.Mode = colorMode;
            sut.Scale.Value = scale;

            var result = sut.SerialiseToKML();

            Assert.Equal(expected, result);
        }
    }
}
