using GeoFunctions.Core.Coordinates.Measurement;
using GoogleEarthConversions.Core.KML.AbstractView.Attributes;
using System;
using Xunit;

namespace GoogleEarthConventions.Tests.KML.AbstractView.Attributes
{
    public class HeadingTests
    {
        [Theory]
        [InlineData(0, AngleMeasurement.Degrees, "<heading>0</heading>")]
        [InlineData(72.999438826, AngleMeasurement.Degrees, "<heading>72.999438826</heading>")]
        [InlineData(360, AngleMeasurement.Degrees, "<heading>0</heading>")]
        [InlineData(450, AngleMeasurement.Degrees, "<heading>90</heading>")]
        [InlineData(Math.PI, AngleMeasurement.Radians, "<heading>180</heading>")]
        [InlineData(5.0*Math.PI/2.0, AngleMeasurement.Radians, "<heading>90</heading>")]
        public void Heading_CorrectlyConvertsToKML(double heading, AngleMeasurement measurement, string expected)
        {
            var sut = new Heading(heading, measurement);

            var result = sut.ConvertObjectToKML();

            Assert.Equal(expected, result);
        }
    }
}
