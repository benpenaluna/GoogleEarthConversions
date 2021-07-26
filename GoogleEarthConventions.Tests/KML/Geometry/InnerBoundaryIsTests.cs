using GoogleEarthConversions.Core.KML.Geometry;
using GoogleEarthConversions.Core.KML.Geometry.Attributes;
using System.Collections.Generic;
using Xunit;

namespace GoogleEarthConventions.Tests.KML.Geometry
{
    public class InnerBoundaryIsTests
    {
        [Fact]
        public void InnerBoundaryIs_CanInstantiate()
        {
            var sut = new InnerBoundaryIs(CreateLinearRingCollection());

            Assert.NotNull(sut);
        }

        [Fact]
        public void InnerBoundaryIs_AllPropertiesInitialised()
        {
            var sut = new InnerBoundaryIs(CreateLinearRingCollection());

            foreach (var prop in sut.GetType().GetProperties())
            {
                var value = prop.GetValue(sut);
                Assert.NotNull(value);
            }
        }

        [Theory]
        [InlineData("<innerBoundaryIs><LinearRing><coordinates>144.98345,-37.81996667,0 151.2152972,-33.85678333,0 142.5314139,-10.68711389,0 131.0368833,-25.34442778,0 144.98345,-37.81996667,0</coordinates></LinearRing>" +
                    "<LinearRing><coordinates>-74.0445,40.68925,0 2.294480556,48.85836944,0 -0.119552778,51.50329722,0 -74.0445,40.68925,0</coordinates></LinearRing></innerBoundaryIs>")]
        public void InnerBoundaryIs_CorrectlyConvertsToKML(string expected)
        {
            var sut = new InnerBoundaryIs(CreateLinearRingCollection());

            var result = sut.SerialiseToKML();

            Assert.Equal(expected, result);
        }

        private ICollection<ILinearRing> CreateLinearRingCollection()
        {
            return new List<ILinearRing>()
            {
                new LinearRing(CoordinatesSet1()),
                new LinearRing(CoordinatesSet2())
            };
        }

        private static List<ICoordinates> CoordinatesSet1()
        {
            return new List<ICoordinates>()
            {
                new Coordinates(-37.81996667, 144.98345),
                new Coordinates(-33.85678333, 151.2152972),
                new Coordinates(-10.68711389, 142.5314139),
                new Coordinates(-25.34442778, 131.0368833),
                new Coordinates(-37.81996667, 144.98345)
            };
        }

        private static List<ICoordinates> CoordinatesSet2()
        {
            return new List<ICoordinates>()
            {
                new Coordinates(40.68925, -74.0445),
                new Coordinates(48.85836944, 2.294480556),
                new Coordinates(51.50329722, -0.119552778),
                new Coordinates(40.68925, -74.0445)
            };
        }
    }
}
