using GeoFunctions.Core.Coordinates.Measurement;
using GoogleEarthConversions.Core.KML.Object.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GoogleEarthConventions.Tests.KML.Object.Attributes
{
    public class MaxAltitudeTests
    {
        [Theory]
        [InlineData(0, DistanceMeasurement.Meters, "<maxAltitude>0</maxAltitude>")]
        [InlineData(90, DistanceMeasurement.Meters, "<maxAltitude>90</maxAltitude>")]
        [InlineData(9000, DistanceMeasurement.Centimeters, "<maxAltitude>90</maxAltitude>")]
        [InlineData(5280, DistanceMeasurement.Feet, "<maxAltitude>1609.344</maxAltitude>")]
        public void MaxAltitude_CorrectlyConvertsToKML(double elevation, DistanceMeasurement measurement, string expected)
        {
            var sut = new MaxAltitude(elevation, measurement);

            var result = sut.ConvertObjectToKML();

            Assert.Equal(expected, result);
        }
    }
}
