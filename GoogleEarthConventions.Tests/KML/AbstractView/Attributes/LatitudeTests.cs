using GeoFunctions.Core.Coordinates.Measurement;
using GoogleEarthConversions.Core.KML.AbstractView.Attributes;
using System;
using Xunit;

namespace GoogleEarthConventions.Tests.KML.AbstractView.Attributes
{
    public class LatitudeTests
    {
        [Theory]
        [InlineData(-90, AngleMeasurement.Degrees, "<latitude>-90</latitude>")]
        [InlineData(0.0, AngleMeasurement.Degrees, "<latitude>0</latitude>")]
        [InlineData(90.0, AngleMeasurement.Degrees, "<latitude>90</latitude>")]
        [InlineData(72.5366278, AngleMeasurement.Degrees, "<latitude>72.5366278</latitude>")]
        [InlineData(-Math.PI / 2.0, AngleMeasurement.Radians, "<latitude>-90</latitude>")]
        [InlineData(0.0, AngleMeasurement.Radians, "<latitude>0</latitude>")]
        [InlineData(Math.PI / 2.0, AngleMeasurement.Radians, "<latitude>90</latitude>")]
        public void Latitude_CorrectlyConvertsToKML(double angle, AngleMeasurement angleMeasurement, string expected)
        {
            var sut = new Latitude(angle, angleMeasurement);

            var result = sut.ConvertObjectToKML();

            Assert.Equal(expected, result);
        }
    }
}
