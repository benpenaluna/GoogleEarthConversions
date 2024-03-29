﻿using GoogleEarthConversions.Core.KML.StyleSelector.Attributes;
using Xunit;

namespace GoogleEarthConventions.Tests.KML.StyleSelector.Attributes
{
    public class DisplayModeTests
    {
        [Fact]
        public void DisplayMode_CanInstantiate()
        {
            var sut = new DisplayMode();

            Assert.NotNull(sut);
        }

        [Fact]
        public void DisplayMode_AllPropertiesInitialised()
        {
            var sut = new DisplayMode();

            foreach (var prop in sut.GetType().GetProperties())
            {
                var value = prop.GetValue(sut);
                Assert.NotNull(value);
            }
        }

        [Theory]
        [InlineData(DisplayModeEnum.Default, "")]
        [InlineData(DisplayModeEnum.Hide, "<displayMode>hide</displayMode>")]
        public void LatLonAltBox_CorrectlyConvertsToKML(DisplayModeEnum mode, string expected)
        {
            var sut = new DisplayMode(mode);

            var result = sut.SerialiseToKML();

            Assert.Equal(expected, result);
        }
    }
}
