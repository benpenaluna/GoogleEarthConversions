using GoogleEarthConversions.Core.Common;
using GoogleEarthConversions.Core.KML.StyleSelector.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GoogleEarthConventions.Tests.KML.StyleSelector.Attributes
{
    public class LineStyleTests
    {
        [Fact]
        public void LineStyle_CanInstantiate()
        {
            var sut = new LineStyle();

            Assert.NotNull(sut);
        }

        [Fact]
        public void LineStyle_AllPropertiesInitialised()
        {
            var sut = new LineStyle();

            foreach (var prop in sut.GetType().GetProperties())
            {
                var value = prop.GetValue(sut);
                Assert.NotNull(value);
            }
        }

        [Fact]
        public void LineStyle_ColorDefaultsToOpaqueWhite()
        {
            var expected = "ffffffff";

            var sut = new LineStyle();
            var result = sut.Color.Value.ColorHexValue();

            Assert.Equal(expected, result);
        }
        
        [Theory]
        [InlineData("", 255, 255, 255, 255, ColorModeEnum.Normal, 1, 255, 255, 255, 255, 0, 0, false, "")]
        [InlineData("ID", 255, 0, 0, 0, ColorModeEnum.Normal, 1, 255, 255, 255, 255, 0, 0, false, "<LineStyle id=\"ID\"><color>ff000000</color></LineStyle>")]
        [InlineData("ID", 255, 0, 0, 0, ColorModeEnum.Normal, 12, 255, 255, 255, 255, 0, 0, false, "<LineStyle id=\"ID\"><color>ff000000</color><width>12</width></LineStyle>")]
        [InlineData("ID", 255, 0, 0, 0, ColorModeEnum.Random, 1, 255, 255, 255, 255, 0, 0, false, "<LineStyle id=\"ID\"><color>ff000000</color><colorMode>random</colorMode></LineStyle>")]
        [InlineData("ID", 255, 0, 0, 0, ColorModeEnum.Random, 1, 255, 0, 0, 0, 0, 0, false, "<LineStyle id=\"ID\"><color>ff000000</color><colorMode>random</colorMode><gx:outerColor>ff000000</gx:outerColor></LineStyle>")]
        [InlineData("ID", 255, 0, 0, 0, ColorModeEnum.Random, 1, 255, 0, 0, 0, 1, 1.2, false, "<LineStyle id=\"ID\"><color>ff000000</color><colorMode>random</colorMode><gx:outerColor>ff000000</gx:outerColor><gx:outerWidth>1</gx:outerWidth><gx:physicalWidth>1.2</gx:physicalWidth></LineStyle>")]
        [InlineData("ID", 255, 0, 0, 0, ColorModeEnum.Random, 1, 255, 0, 0, 0, 1, 1.2, true, "<LineStyle id=\"ID\"><color>ff000000</color><colorMode>random</colorMode><gx:outerColor>ff000000</gx:outerColor><gx:outerWidth>1</gx:outerWidth><gx:physicalWidth>1.2</gx:physicalWidth><gx:labelVisibility>1</gx:labelVisibility></LineStyle>")]
        public void LineStyle_CorrectlyConvertsToKML(string id, int colorAlpha, int colorRed, int colorGreen, int colorBlue, ColorModeEnum colorMode,
                                                     double width, int outerColorAlpha, int outerColorRed, int outerColorGreen, int outerColorBlue, 
                                                     double outerWidth, double physicalWidth, bool labelVisibility, string expected)
        {
            var sut = new LineStyle() { Id = id };
            sut.Color.Value = System.Drawing.Color.FromArgb(colorAlpha, colorRed, colorGreen, colorBlue);
            sut.ColorMode.Mode = colorMode;
            sut.Width.Value = width;
            sut.OuterColor.Value = System.Drawing.Color.FromArgb(outerColorAlpha, outerColorRed, outerColorGreen, outerColorBlue);
            sut.OuterWidth.Value = outerWidth;
            sut.PhysicalWidth.Value = physicalWidth;
            sut.LabelVisibility.Value = labelVisibility;

            var result = sut.SerialiseToKML();

            Assert.Equal(expected, result);
        }
    }
}
