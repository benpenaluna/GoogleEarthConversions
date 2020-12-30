using GeoFunctions.Core.Coordinates.Measurement;
using GoogleEarthConversions.Core.KML.Object.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GoogleEarthConventions.Tests.KML.Object.Attributes
{
    public class SouthTests
    {
        [Theory]
        [InlineData(-90, AngleMeasurement.Degrees, "<south>-90</south>")]
        [InlineData(0.0, AngleMeasurement.Degrees, "<south>0</south>")]
        [InlineData(90.0, AngleMeasurement.Degrees, "<south>90</south>")]
        [InlineData(72.5366278, AngleMeasurement.Degrees, "<south>72.5366278</south>")]
        [InlineData(-Math.PI / 2.0, AngleMeasurement.Radians, "<south>-90</south>")]
        [InlineData(0.0, AngleMeasurement.Radians, "<south>0</south>")]
        [InlineData(Math.PI / 2.0, AngleMeasurement.Radians, "<south>90</south>")]
        public void South_CorrectlyConvertsToKML(double angle, AngleMeasurement angleMeasurement, string expected)
        {
            var sut = new South(angle, angleMeasurement);

            var result = sut.ConvertObjectToKML();

            Assert.Equal(expected, result);
        }
    }
}
