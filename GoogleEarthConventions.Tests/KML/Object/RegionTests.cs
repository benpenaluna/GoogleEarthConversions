using GeoFunctions.Core.Coordinates;
using GeoFunctions.Core.Coordinates.Measurement;
using GoogleEarthConversions.Core.KML.Geometry.Attributes;
using GoogleEarthConversions.Core.KML.Object;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GoogleEarthConventions.Tests.KML.Object
{
    public class RegionTests
    {
        [Fact]
        public void Region_CanInstantiate()
        {
            var sut = new Region();

            Assert.NotNull(sut);
        }

        [Fact]
        public void Region_AllPropertiesInitialised()
        {
            var sut = new Region();

            foreach (var prop in sut.GetType().GetProperties())
            {
                var value = prop.GetValue(sut);
                Assert.NotNull(value);
            }
        }

        [Fact]
        public void Region_CorrectlyConvertsToKMLDefault()
        {
            var expected = string.Empty;

            var sut = new Region();

            var result = sut.SerialiseToKML();

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(43.374, 42.983, -0.335, -1.423, 0, 0, AltMode.ClampToGround, 256.0, 0.0, 0.0, 0.0, 
            "<Region>" + 
                "<LatLonAltBox><north>43.374</north><south>42.983</south><east>-0.335</east><west>-1.423</west><minAltitude>0</minAltitude><maxAltitude>0</maxAltitude></LatLonAltBox>" +
                "<Lod><minLodPixels>256</minLodPixels></Lod>"+
            "</Region>")]
        [InlineData(43.374, 42.983, -0.335, -1.423, 0, 300.0, AltMode.ClampToGround, 128.0, 1024, 128, 128,
            "<Region>" +
                "<LatLonAltBox><north>43.374</north><south>42.983</south><east>-0.335</east><west>-1.423</west><minAltitude>0</minAltitude><maxAltitude>300</maxAltitude></LatLonAltBox>" +
                "<Lod><minLodPixels>128</minLodPixels><maxLodPixels>1024</maxLodPixels><minFadeExtent>128</minFadeExtent><maxFadeExtent>128</maxFadeExtent></Lod>" +
            "</Region>")]
        public void Region_CorrectlyConvertsToKML(double north, double south, double east, double west, double minAlt, double maxAlt, AltMode altMode, 
                                                  double minLodPixels, double maxLodPixels, double minFadeExtent, double maxFadeExtent, string expected)
        {
            var sut = new Region()
            {
                LatLonAltBox = new LatLonAltBox() { AltitudeMode = new AltitudeMode(altMode) },
                Lod = new Lod(minLodPixels, maxLodPixels, minFadeExtent, maxFadeExtent)
            };
            
            sut.LatLonAltBox.UpdateNorthAngle(new Angle(north));
            sut.LatLonAltBox.UpdateSouthAngle(new Angle(south));
            sut.LatLonAltBox.UpdateEastAngle(new Angle(east));
            sut.LatLonAltBox.UpdateWestAngle(new Angle(west));
            sut.LatLonAltBox.UpdateMinAltitude(minAlt, DistanceMeasurement.Meters);
            sut.LatLonAltBox.UpdateMaxAltitude(maxAlt, DistanceMeasurement.Meters);

            var result = sut.SerialiseToKML();

            Assert.Equal(expected, result);
        }
    }
}
