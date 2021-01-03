using GoogleEarthConversions.Core.KML.StyleSelector.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GoogleEarthConventions.Tests.KML.StyleSelector.Attributes
{
    public class ColorTests
    {
        [Fact]
        public void Color_CanInstantiate()
        {
            var sut = new Color();

            Assert.NotNull(sut);
        }

        [Fact]
        public void Color_AllPropertiesInitialised()
        {
            var sut = new Color();

            foreach (var prop in sut.GetType().GetProperties())
            {
                var value = prop.GetValue(sut);
                Assert.NotNull(value);
            }
        }

        [Fact]
        public void Color_ValueDefaultsToWhite()
        {
            var expected = -1;

            var sut = new Color();

            var result = sut.Value.ToArgb();

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(256, 0, 0, 0)]
        [InlineData(0, 256, 0, 0)]
        [InlineData(0, 0, 256, 0)]
        [InlineData(0, 0, 0, 256)]
        [InlineData(-1, 0, 0, 0)]
        public void Color_ExceptionOnInvalidARGBValues(int alpha, int red, int green, int blue)
        {
            Assert.Throws<ArgumentException>(() => new Color(alpha, red, green, blue));
        }

        [Theory]
        [InlineData(255, 255, 255, 255, "ffffffff")]
        [InlineData(0, 0, 0, 0, "00000000")]
        [InlineData(255, 240, 248, 255, "fff0f8ff")]
        [InlineData(167, 178, 12, 205, "a7b20ccd")]
        public void Color_CorrectlyOutputHexValue(int alpha, int red, int green, int blue, string expected)
        {
            var sut = new Color(alpha, red, green, blue);

            var result = sut.ColorHexValue();

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(255, 255, 255, 255, "<color>ffffffff</color>")]
        [InlineData(0, 0, 0, 0, "<color>00000000</color>")]
        [InlineData(255, 240, 248, 255, "<color>fff0f8ff</color>")]
        [InlineData(167, 178, 12, 205, "<color>a7b20ccd</color>")]
        public void LatLonAltBox_CorrectlyConvertsToKML(int alpha, int red, int green, int blue, string expected)
        {
            var sut = new Color(alpha, red, green, blue);

            var result = sut.ConvertObjectToKML();

            Assert.Equal(expected, result);
        }
    }
}
