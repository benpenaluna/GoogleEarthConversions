using GeoFunctions.Core.Coordinates;
using GeoFunctions.Core.Coordinates.Measurement;
using GoogleEarthConversions.Core.Common;
using Xunit;

namespace GoogleEarthConventions.Tests.Common
{
    public class CoordinatesTests
    {
        [Fact]
        public void Coordinates_CanInstantiate1()
        {
            var sut = new Coordinates();

            Assert.NotNull(sut);
        }
        
        [Theory]
        [InlineData(40.68925, -74.0445)]
        public void Coordinates_CanInstantiate2(double lat, double lon)
        {
            ISphericalCoordinate latitude = new Latitude(lat);
            ISphericalCoordinate longitude = new Longitude(lon);
                        
            var sut = new Coordinates(latitude, longitude);

            Assert.NotNull(sut);
        }

        [Theory]
        [InlineData(40.68925, -74.0445, 200.4)]
        public void Coordinates_CanInstantiate3(double lat, double lon, double elev)
        {
            var sut = new Coordinates(lat, lon, elev);

            Assert.NotNull(sut);
        }

        [Theory]
        [InlineData(40.68925, -74.0445, 200.4)]
        public void Coordinates_CanInstantiate4(double lat, double lon, double elev)
        {
            ISphericalCoordinate latitude = new Latitude(lat);
            ISphericalCoordinate longitude = new Longitude(lon);
            IDistance elevation = new Distance(elev);

            var sut = new Coordinates(latitude, longitude, elevation);

            Assert.NotNull(sut);
        }

        [Fact]
        public void Coordinates_AllPropertiesInitialised()
        {
            var sut = new Coordinates();

            foreach (var prop in sut.GetType().GetProperties())
            {
                var value = prop.GetValue(sut);
                Assert.NotNull(value);
            }
        }

        [Theory]
        [InlineData(40.68925, -74.0445, 200.4, "<coordinates>-074.044500000000,40.6892500000000,200</coordinates>")]
        public void Coordinates_CorrectlyConvertsToKML(double lat, double lon, double elev, string expected)
        {
            ISphericalCoordinate latitude = new Latitude(lat);
            ISphericalCoordinate longitude = new Longitude(lon);
            IDistance elevation = new Distance(elev, DistanceMeasurement.Meters);

            var sut = new Coordinates(latitude, longitude, elevation);

            var result = sut.ConvertObjectToKML();

            Assert.Equal(expected, result);
        }
    }
}
