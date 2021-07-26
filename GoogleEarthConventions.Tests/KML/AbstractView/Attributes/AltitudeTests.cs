using GeoFunctions.Core.Coordinates.Measurement;
using GoogleEarthConversions.Core.KML.AbstractView.Attributes;
using Xunit;

namespace GoogleEarthConventions.Tests.KML.AbstractView.Attributes
{
    public class AltitudeTests
    {
        [Theory]
        [InlineData(0, DistanceMeasurement.Meters, "<altitude>0</altitude>")]
        [InlineData(90, DistanceMeasurement.Meters, "<altitude>90</altitude>")]
        [InlineData(9000, DistanceMeasurement.Centimeters, "<altitude>90</altitude>")]
        [InlineData(5280, DistanceMeasurement.Feet, "<altitude>1609.344</altitude>")]
        public void Altitude_CorrectlyConvertsToKML(double elevation, DistanceMeasurement measurement, string expected)
        {
            var sut = new Altitude(elevation, measurement);

            var result = sut.SerialiseToKML();

            Assert.Equal(expected, result);
        }
    }
}
