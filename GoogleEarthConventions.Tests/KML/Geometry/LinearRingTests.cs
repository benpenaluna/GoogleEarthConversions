using GoogleEarthConversions.Core.KML.Geometry;
using GoogleEarthConversions.Core.KML.Geometry.Attributes;
using System;
using System.Collections.Generic;
using Xunit;

namespace GoogleEarthConventions.Tests.KML.Geometry
{
    public class LinearRingTests
    {
        [Fact]
        public void LinearRing_CanInstantiate()
        {
            ICollection<ICoordinates> coordinates = CreateCoordinatesList();

            var sut = new LinearRing(coordinates);

            Assert.NotNull(sut);
        }

        [Fact]
        public void LinearRing_InstantiatationFailsIfCoordinatesNull()
        {
            ICollection<ICoordinates> coordinates = null;

            Assert.Throws<NullReferenceException>(() => new LinearRing(coordinates));
        }

        [Fact]
        public void LinearRing_InstantiatationFailsIfFirstAndLastCoordsDifferent()
        {
            ICollection<ICoordinates> coordinates = CreateFailingCoordinatesList();

            Assert.Throws<InvalidOperationException>(() => new LinearRing(coordinates));
        }

        [Theory]
        [InlineData(-37.81996667, 144.98345)]
        public void LinearRing_InstantiatationFailsIfLessThan4CoordinatesProvided(double latA, double lonA)
        {
            ICollection<ICoordinates> coordinates = new List<ICoordinates>()
            {
                new Coordinates(latA, lonA),
                new Coordinates(latA, lonA)
            };

            Assert.Throws<InvalidOperationException>(() => new LinearRing(coordinates));
        }

        [Fact]
        public void LinearRing_CorrectlyInitialisesProperties()
        {
            ICollection<ICoordinates> coordinates = CreateCoordinatesList();

            var expected = new LinearRing(coordinates)
            {
                AltitudeOffset = new AltitudeOffset(),
                Extrude = new Extrude(),
                Tessellate = new Tessellate(),
                AltitudeMode = new AltitudeMode()
            };

            var result = new LinearRing(coordinates);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(0.0, false, false, AltMode.ClampToGround, "<LinearRing><coordinates>144.98345,-37.81996667,0 151.2152972,-33.85678333,0 142.5314139,-10.68711389,0 131.0368833,-25.34442778,0 144.98345,-37.81996667,0</coordinates></LinearRing>")]
        [InlineData(0.0, true, true, AltMode.RelativeToSeaFloor, "<LinearRing><extrude>1</extrude><tessellate>1</tessellate><gx:altitudeMode>relativeToSeaFloor</gx:altitudeMode><coordinates>144.98345,-37.81996667,0 151.2152972,-33.85678333,0 142.5314139,-10.68711389,0 131.0368833,-25.34442778,0 144.98345,-37.81996667,0</coordinates></LinearRing>")]
        [InlineData(200.0, true, true, AltMode.ClampToGround, "<LinearRing><gx:altitudeOffset>200</gx:altitudeOffset><extrude>1</extrude><tessellate>1</tessellate><coordinates>144.98345,-37.81996667,0 151.2152972,-33.85678333,0 142.5314139,-10.68711389,0 131.0368833,-25.34442778,0 144.98345,-37.81996667,0</coordinates></LinearRing>")]
        [InlineData(0, false, false, AltMode.ClampToGround, "<LinearRing><coordinates>144.98345,-37.81996667,0 151.2152972,-33.85678333,0 142.5314139,-10.68711389,0 131.0368833,-25.34442778,0 144.98345,-37.81996667,0</coordinates></LinearRing>")]
        public void LinearRing_CorrectlyConvertsToKML(double altitudeOffset, bool extrude, bool tesselate, AltMode altitudeMode, string expected)
        {
            var coordinates = CreateCoordinatesList();

            var sut = new LinearRing(coordinates)
            {
                AltitudeOffset = new AltitudeOffset(altitudeOffset),
                Extrude = new Extrude(extrude),
                Tessellate = new Tessellate(tesselate),
                AltitudeMode = new AltitudeMode(altitudeMode)
            };

            var result = sut.SerialiseToKML();

            Assert.Equal(expected, result);
        }

        private ICollection<ICoordinates> CreateCoordinatesList()
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

        private ICollection<ICoordinates> CreateFailingCoordinatesList()
        {
            return new List<ICoordinates>()
            {
                new Coordinates(-37.81996667, 144.98345),
                new Coordinates(-33.85678333, 151.2152972),
                new Coordinates(-10.68711389, 142.5314139),
                new Coordinates(-25.34442778, 131.0368833),
            };
        }
    }
}
