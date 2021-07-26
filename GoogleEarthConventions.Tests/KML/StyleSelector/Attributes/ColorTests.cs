using GoogleEarthConversions.Core.Common;
using GoogleEarthConversions.Core.KML.StyleSelector.Attributes;
using System;
using Xunit;

namespace GoogleEarthConventions.Tests.KML.StyleSelector.Attributes
{
    public class ColorTests
    {
        [Fact]
        public void Color_CanInstantiate()
        {
            var sut = new Color(string.Empty);

            Assert.NotNull(sut);
        }

        [Fact]
        public void Color_AllPropertiesInitialised()
        {
            var sut = new Color(string.Empty);

            foreach (var prop in sut.GetType().GetProperties())
            {
                var value = prop.GetValue(sut);
                Assert.NotNull(value);
            }
        }

        [Theory]
        [InlineData(256, 0, 0, 0)]
        [InlineData(0, 256, 0, 0)]
        [InlineData(0, 0, 256, 0)]
        [InlineData(0, 0, 0, 256)]
        [InlineData(-1, 0, 0, 0)]
        public void Color_ExceptionOnInvalidARGBValues(int alpha, int red, int green, int blue)
        {
            Assert.Throws<ArgumentException>(() => new Color(string.Empty) { Value = System.Drawing.Color.FromArgb(alpha, red, green, blue) });
        }

        [Theory]
        [InlineData(255, 255, 255, 255, "ffffffff")]
        [InlineData(0, 0, 0, 0, "00000000")]
        [InlineData(255, 240, 248, 255, "fff0f8ff")]
        [InlineData(167, 178, 12, 205, "a7b20ccd")]
        public void Color_CorrectlyOutputHexValue(int alpha, int red, int green, int blue, string expected)
        {
            var sut = new Color(string.Empty) { Value = System.Drawing.Color.FromArgb(alpha, red, green, blue) };

            var result = sut.Value.ColorHexValue();

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(255, 255, 255, 255, 255, 255, 255, 255, "color", "")]
        [InlineData(0, 0, 0, 0, 0, 0, 0, 0, "color", "")]
        [InlineData(0, 0, 0, 0, 255, 255, 255, 255, "", "<color>00000000</color>")]
        [InlineData(255, 240, 248, 255, 255, 255, 255, 255, "color", "<color>fff0f8ff</color>")]
        [InlineData(167, 178, 12, 205, 255, 255, 255, 255, "bgColor", "<bgColor>a7b20ccd</bgColor>")]
        public void Color_CorrectlyConvertsToKML(int valueAlpha, int valueRed, int valueGreen, int valueBlue,
                                                 int defaultAlpha, int defaultRed, int defaultGreen, int defaultBlue,
                                                 string kmlTag, string expected)
        {
            var value = System.Drawing.Color.FromArgb(valueAlpha, valueRed, valueGreen, valueBlue);
            var def = System.Drawing.Color.FromArgb(defaultAlpha, defaultRed, defaultGreen, defaultBlue);
            var sut = new Color(kmlTag) { Value = value, DefaultColor = def };

            var result = sut.SerialiseToKML();

            Assert.Equal(expected, result);
        }
    }
}
