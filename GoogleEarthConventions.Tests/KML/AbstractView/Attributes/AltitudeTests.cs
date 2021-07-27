using GeoFunctions.Core.Coordinates.Measurement;
using GoogleEarthConversions.Core.KML.AbstractView.Attributes;
using System.Xml;
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
        public void Altitude_CorrectlySerialisedToKML(double elevation, DistanceMeasurement measurement, string expected)
        {
            var sut = new Altitude(elevation, measurement);

            var result = sut.SerialiseToKML();

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(-1.0E+10, DistanceMeasurement.Meters, "<altitude>-10000000000</altitude>")]
        [InlineData(-90.0, DistanceMeasurement.Meters, "<altitude>-90</altitude>")]
        [InlineData(90.0, DistanceMeasurement.Meters, "<altitude>90</altitude>")]
        [InlineData(1.0E+10, DistanceMeasurement.Meters, "<altitude>10000000000</altitude>")]
        public void Altitude_CorrectlyDeserialisesFromKML(double elevation, DistanceMeasurement measurement, string kml)
        {
            var expected = new Altitude(elevation, measurement);

            var sut = Altitude.DeserialiseFromKML(kml);

            Assert.Equal(expected, sut);
        }

        [Theory]
        [InlineData("<altitude>invalid</altitude>")]
        [InlineData("<altitude></altitude>")]
        [InlineData("<element>10000000000</element>")]
        public void Altitude_DeserialiseFromKMLThrowException(string kml)
        {
            Assert.Throws<XmlException>(() => Altitude.DeserialiseFromKML(kml));
        }
    }
}
