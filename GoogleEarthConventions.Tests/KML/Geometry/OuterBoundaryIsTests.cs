using GoogleEarthConversions.Core.KML.Geometry;
using GoogleEarthConversions.Core.KML.Geometry.Attributes;
using System.Collections.Generic;
using Xunit;

namespace GoogleEarthConventions.Tests.KML.Geometry
{
    public class OuterBoundaryIsTests
    {
        [Fact]
        public void OuterBoundaryIs_CanInstantiate()
        {
            var sut = new OuterBoundaryIs(CreateLinearRing());

            Assert.NotNull(sut);
        }

        [Fact]
        public void OuterBoundaryIs_AllPropertiesInitialised()
        {
            var sut = new OuterBoundaryIs(CreateLinearRing());

            foreach (var prop in sut.GetType().GetProperties())
            {
                var value = prop.GetValue(sut);
                Assert.NotNull(value);
            }
        }

        [Theory]
        [InlineData("<outerBoundaryIs><LinearRing><coordinates>144.98345,-37.81996667,0 151.2152972,-33.85678333,0 142.5314139,-10.68711389,0 " +
                    "131.0368833,-25.34442778,0 144.98345,-37.81996667,0</coordinates></LinearRing></outerBoundaryIs>")]
        public void OuterBoundaryIs_CorrectlyConvertsToKML(string expected)
        {
            var sut = new OuterBoundaryIs(CreateLinearRing());

            var result = sut.ConvertObjectToKML();

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("<outerBoundaryIs><LinearRing id=\"Test\"><coordinates>144.98345,-37.81996667,0 151.2152972,-33.85678333,0 142.5314139,-10.68711389,0 " +
                    "131.0368833,-25.34442778,0 144.98345,-37.81996667,0</coordinates></LinearRing></outerBoundaryIs>")]
        public void OuterBoundaryIs_CorrectlyConvertsToKMLWithLinearRingID(string expected)
        {
            var sut = new OuterBoundaryIs(CreateLinearRing());
            sut.LinearRing.Id = "Test";

            var result = sut.ConvertObjectToKML();

            Assert.Equal(expected, result);
        }

        private ILinearRing CreateLinearRing()
        {
            var coordinates = new List<ICoordinates>()
            {
                new Coordinates(-37.81996667, 144.98345),
                new Coordinates(-33.85678333, 151.2152972),
                new Coordinates(-10.68711389, 142.5314139),
                new Coordinates(-25.34442778, 131.0368833),
                new Coordinates(-37.81996667, 144.98345)
            };

            return new LinearRing(coordinates);
        }
    }
}
