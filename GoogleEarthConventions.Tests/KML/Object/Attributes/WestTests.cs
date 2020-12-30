using GeoFunctions.Core.Coordinates.Measurement;
using GoogleEarthConversions.Core.KML.Object.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GoogleEarthConventions.Tests.KML.Object.Attributes
{
    public class WestTests
    {
        [Theory]
        [InlineData(-179.9999999, AngleMeasurement.Degrees, "<west>-179.9999999</west>")]
        [InlineData(0.0, AngleMeasurement.Degrees, "<west>0</west>")]
        [InlineData(180.0, AngleMeasurement.Degrees, "<west>180</west>")]
        [InlineData(72.5366278, AngleMeasurement.Degrees, "<west>72.5366278</west>")]
        [InlineData(-Math.PI + 0.0000000000001, AngleMeasurement.Radians, "<west>-179.9999999999943</west>")]
        [InlineData(0.0, AngleMeasurement.Radians, "<west>0</west>")]
        [InlineData(Math.PI, AngleMeasurement.Radians, "<west>180</west>")]
        public void West_CorrectlyConvertsToKML(double angle, AngleMeasurement angleMeasurement, string expected)
        {
            var sut = new West(angle, angleMeasurement);

            var result = sut.ConvertObjectToKML();

            Assert.Equal(expected, result);
        }
    }
}
