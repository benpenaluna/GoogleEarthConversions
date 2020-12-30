using GeoFunctions.Core.Coordinates.Measurement;
using GoogleEarthConversions.Core.KML.Object.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GoogleEarthConventions.Tests.KML.Object.Attributes
{
    public class NorthTests
    {
        [Theory]
        [InlineData(-90, AngleMeasurement.Degrees, "<north>-90</north>")]
        [InlineData(0.0, AngleMeasurement.Degrees, "<north>0</north>")]
        [InlineData(90.0, AngleMeasurement.Degrees, "<north>90</north>")]
        [InlineData(72.5366278, AngleMeasurement.Degrees, "<north>72.5366278</north>")]
        [InlineData(-Math.PI / 2.0, AngleMeasurement.Radians, "<north>-90</north>")]
        [InlineData(0.0, AngleMeasurement.Radians, "<north>0</north>")]
        [InlineData(Math.PI / 2.0, AngleMeasurement.Radians, "<north>90</north>")]
        public void North_CorrectlyConvertsToKML(double angle, AngleMeasurement angleMeasurement, string expected)
        {
            var sut = new North(angle, angleMeasurement);

            var result = sut.ConvertObjectToKML();

            Assert.Equal(expected, result);
        }
    }
}
