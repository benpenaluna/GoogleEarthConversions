using GoogleEarthConversions.Core.KML.Object;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GoogleEarthConventions.Tests.KML.Object
{
    public class LodTests
    {
        [Fact]
        public void Lod_CanInstantiate()
        {
            var sut = new Lod();

            Assert.NotNull(sut);
        }

        [Fact]
        public void Lod_AllPropertiesInitialised()
        {
            var sut = new Lod();

            foreach (var prop in sut.GetType().GetProperties())
            {
                var value = prop.GetValue(sut);
                Assert.NotNull(value);
            }
        }

        [Fact]
        public void LatLonAltBox_CorrectlyConvertsToKMLDefault()
        {
            var expected = "<Lod><minLodPixels>256</minLodPixels><maxLodPixels>-1</maxLodPixels></Lod>";

            var sut = new Lod();

            var result = sut.SerialiseToKML();

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(256.0, 0.0, 0.0, 0.0, "<Lod><minLodPixels>256</minLodPixels></Lod>")]
        [InlineData(128.0, 1024, 128, 128, "<Lod><minLodPixels>128</minLodPixels><maxLodPixels>1024</maxLodPixels><minFadeExtent>128</minFadeExtent><maxFadeExtent>128</maxFadeExtent></Lod>")]
        public void LatLonAltBox_CorrectlyConvertsToKML(double minLodPixels, double maxLodPixels, double minFadeExtent, double maxFadeExtent, string expected)
        {
            var sut = new Lod(minLodPixels, maxLodPixels, minFadeExtent, maxFadeExtent);

            var result = sut.SerialiseToKML();

            Assert.Equal(expected, result);
        }
    }
}
