using GeoFunctions.Core.Coordinates.Measurement;
using GoogleEarthConversions.Core.Geographical;
using GoogleEarthConversions.Core.KML.AbstractView.Attributes;
using System;
using Xunit;

namespace GoogleEarthConventions.Tests.KML.AbstractView.Attributes
{
    public class LongitudeTests
    {
        [Theory]
        [InlineData(-179.9999999, AngleMeasurement.Degrees, "<longitude>-179.9999999</longitude>")]
        [InlineData(0.0, AngleMeasurement.Degrees, "<longitude>0</longitude>")]
        [InlineData(180.0, AngleMeasurement.Degrees, "<longitude>180</longitude>")]
        [InlineData(72.5366278, AngleMeasurement.Degrees, "<longitude>72.5366278</longitude>")]
        [InlineData(-Math.PI + 0.0000000000001, AngleMeasurement.Radians, "<longitude>-179.9999999999943</longitude>")]
        [InlineData(0.0, AngleMeasurement.Radians, "<longitude>0</longitude>")]
        [InlineData(Math.PI, AngleMeasurement.Radians, "<longitude>180</longitude>")]
        public void Longitude_CorrectlyConvertsToKML(double angle, AngleMeasurement angleMeasurement, string expected)
        {
            var sut = new Longitude(angle, angleMeasurement);

            var result = sut.ConvertObjectToKML();

            Assert.Equal(expected, result);
        }
    }
}
