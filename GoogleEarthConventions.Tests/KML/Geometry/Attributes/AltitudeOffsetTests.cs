using GeoFunctions.Core.Coordinates;
using GeoFunctions.Core.Coordinates.Measurement;
using GoogleEarthConversions.Core.KML.Geometry.Attributes;
using Xunit;

namespace GoogleEarthConventions.Tests.KML.Geometry.Attributes
{
    public class AltitudeOffsetTests
    {
        [Fact]
        public void AltitudeOffset_CanInstantiate()
        {
            var sut = new AltitudeOffset();

            Assert.NotNull(sut);
        }

        [Fact]
        public void AltitudeOffset_AllPropertiesInitialised()
        {
            var sut = new AltitudeOffset();

            foreach (var prop in sut.GetType().GetProperties())
            {
                var value = prop.GetValue(sut);
                Assert.NotNull(value);
            }
        }

        [Theory]
        [InlineData(0, "")]
        [InlineData(200.417, "<gx:altitudeOffset>200.417</gx:altitudeOffset>")]
        public void AltitudeOffset_CorrectlyConvertsToKML(double value, string expected)
        {
            var sut = new AltitudeOffset(value);

            var result = sut.ConvertObjectToKML();

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(328.084, "<gx:altitudeOffset>100.00000320000001</gx:altitudeOffset>")]
        public void AltitudeOffset_CorrectlyDisplaysMetersInKMLConversion(double value, string expected)
        {
            IDistance distance = new Distance(value, DistanceMeasurement.Feet);
            var sut = new AltitudeOffset(distance);

            var result = sut.ConvertObjectToKML();

            Assert.Equal(expected, result);
        }
    }
}
