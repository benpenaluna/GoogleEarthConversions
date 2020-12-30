using GeoFunctions.Core.Coordinates.Measurement;
using GoogleEarthConversions.Core.KML.Object.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GoogleEarthConventions.Tests.KML.Object.Attributes
{
    public class MinAltitudeTests
    {
        [Theory]
        [InlineData(0, DistanceMeasurement.Meters, "<minAltitude>0</minAltitude>")]
        [InlineData(90, DistanceMeasurement.Meters, "<minAltitude>90</minAltitude>")]
        [InlineData(9000, DistanceMeasurement.Centimeters, "<minAltitude>90</minAltitude>")]
        [InlineData(5280, DistanceMeasurement.Feet, "<minAltitude>1609.344</minAltitude>")]
        public void MinAltitude_CorrectlyConvertsToKML(double elevation, DistanceMeasurement measurement, string expected)
        {
            var sut = new MinAltitude(elevation, measurement);

            var result = sut.ConvertObjectToKML();

            Assert.Equal(expected, result);
        }
    }
}
