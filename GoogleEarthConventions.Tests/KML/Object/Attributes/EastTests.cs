using GeoFunctions.Core.Coordinates.Measurement;
using GoogleEarthConversions.Core.KML.Object.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GoogleEarthConventions.Tests.KML.Object.Attributes
{
    public class EastTests
    {
        [Theory]
        [InlineData(-179.9999999, AngleMeasurement.Degrees, "<east>-179.9999999</east>")]
        [InlineData(0.0, AngleMeasurement.Degrees, "<east>0</east>")]
        [InlineData(180.0, AngleMeasurement.Degrees, "<east>180</east>")]
        [InlineData(72.5366278, AngleMeasurement.Degrees, "<east>72.5366278</east>")]
        [InlineData(-Math.PI + 0.0000000000001, AngleMeasurement.Radians, "<east>-179.9999999999943</east>")]
        [InlineData(0.0, AngleMeasurement.Radians, "<east>0</east>")]
        [InlineData(Math.PI, AngleMeasurement.Radians, "<east>180</east>")]
        public void East_CorrectlyConvertsToKML(double angle, AngleMeasurement angleMeasurement, string expected)
        {
            var sut = new East(angle, angleMeasurement);

            var result = sut.ConvertObjectToKML();

            Assert.Equal(expected, result);
        }
    }
}
