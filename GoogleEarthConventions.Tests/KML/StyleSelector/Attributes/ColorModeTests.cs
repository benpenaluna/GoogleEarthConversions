using GoogleEarthConversions.Core.KML.StyleSelector.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GoogleEarthConventions.Tests.KML.StyleSelector.Attributes
{
    public class ColorModeTests
    {
        [Fact]
        public void ColorMode_CanInstantiate()
        {
            var sut = new ColorMode();

            Assert.NotNull(sut);
        }

        [Fact]
        public void ColorMode_AllPropertiesInitialised()
        {
            var sut = new ColorMode();

            foreach (var prop in sut.GetType().GetProperties())
            {
                var value = prop.GetValue(sut);
                Assert.NotNull(value);
            }
        }

        [Theory]
        [InlineData(ColorModeEnum.Normal, "")]
        [InlineData(ColorModeEnum.Random, "<colorMode>random</colorMode>")]
        public void LatLonAltBox_CorrectlyConvertsToKML(ColorModeEnum mode, string expected)
        {
            var sut = new ColorMode(mode);

            var result = sut.SerialiseToKML();

            Assert.Equal(expected, result);
        }
    }
}
