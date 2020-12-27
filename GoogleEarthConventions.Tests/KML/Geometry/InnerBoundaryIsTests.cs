using GoogleEarthConversions.Core.Common;
using GoogleEarthConversions.Core.KML.Geometry;
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
        [InlineData("<innerBoundaryIs><LinearRing><coordinates>144.983450000000,-37.8199666700000,0 151.215297200000,-33.8567833300000,0 142.531413900000,-10.6871138900000,0 131.036883300000,-25.3444277800000,0 144.983450000000,-37.8199666700000,0</coordinates></LinearRing>" +
                    "<LinearRing><coordinates>-074.044500000000,40.6892500000000,0 002.294480556000,48.8583694400000,0 -000.119552778000,51.5032972200000,0 -074.044500000000,40.6892500000000,0</coordinates></LinearRing></innerBoundaryIs>")]
        public void InnerBoundaryIs_CorrectlyConvertsToKML(string expected)
        {
            var sut = new InnerBoundaryIs(CreateLinearRingCollection());

            var result = sut.ConvertObjectToKML();

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
