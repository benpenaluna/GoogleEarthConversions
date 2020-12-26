using GoogleEarthConversions.Core.Common;
using GoogleEarthConversions.Core.KML.Geometry;
using System;
using System.Collections.Generic;
using Xunit;
namespace GoogleEarthConventions.Tests.KML
{
    public class LinearRingTests
    {
        [Theory]
        [InlineData("Test")]
        public void LinearRing_CanInstantiate(string id)
        {
            ICollection<ICoordinates> coordinates = CreateCoordinatesList();

            var sut = new LinearRing(id, coordinates);

            Assert.NotNull(sut);
        }

        [Theory]
        [InlineData("Test")]
        public void LinearRing_InstantiatationFailsIfCoordinatesNull(string id)
        {
            ICollection<ICoordinates> coordinates = null;

            Assert.Throws<NullReferenceException>(() => new LinearRing(id, coordinates));
        }

        [Theory]
        [InlineData("Test")]
        public void LinearRing_InstantiatationFailsIfFirstAndLastCoordsDifferent(string id)
        {
            ICollection<ICoordinates> coordinates = CreateFailingCoordinatesList();
            
            Assert.Throws<InvalidOperationException>(() => new LinearRing(id, coordinates));
        }

        [Theory]
        [InlineData("Test", -37.81996667, 144.98345)]
        public void LinearRing_InstantiatationFailsIfLessThan4CoordinatesProvided(string id, double latA, double lonA)
        {
            ICollection<ICoordinates> coordinates = new List<ICoordinates>()
            {
                new Coordinates(latA, lonA),
                new Coordinates(latA, lonA)
            };

            Assert.Throws<InvalidOperationException>(() => new LinearRing(id, coordinates));
        }

        [Theory]
        [InlineData("Test")]
        public void LinearRing_CorrectlyInitialisesProperties(string id)
        {
            ICollection<ICoordinates> coordinates = CreateCoordinatesList();

            var expected = new LinearRing(id, coordinates)
            {
                AltitudeOffset = new AltitudeOffset(),
                Extrude = new Extrude(),
                Tessellate = new Tessellate(),
                AltitudeMode = new AltitudeMode()
            };

            var result = new LinearRing(id, coordinates);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("Test", 0.0, false, false, AltMode.ClampToGround, "<LinearRing id=\"Test\"><coordinates>144.983450000000,-37.8199666700000,0 151.215297200000,-33.8567833300000,0 142.531413900000,-10.6871138900000,0 131.036883300000,-25.3444277800000,0 144.983450000000,-37.8199666700000,0</coordinates></LinearRing>")]
        [InlineData("Test", 0.0, true, true, AltMode.RelativeToSeaFloor, "<LinearRing id=\"Test\"><extrude>1</extrude><tessellate>1</tessellate><gx:altitudeMode>relativeToSeaFloor</gx:altitudeMode><coordinates>144.983450000000,-37.8199666700000,0 151.215297200000,-33.8567833300000,0 142.531413900000,-10.6871138900000,0 131.036883300000,-25.3444277800000,0 144.983450000000,-37.8199666700000,0</coordinates></LinearRing>")]
        [InlineData("Test", 200.0, true, true, AltMode.ClampToGround, "<LinearRing id=\"Test\"><gx:altitudeOffset>200</gx:altitudeOffset><extrude>1</extrude><tessellate>1</tessellate><coordinates>144.983450000000,-37.8199666700000,0 151.215297200000,-33.8567833300000,0 142.531413900000,-10.6871138900000,0 131.036883300000,-25.3444277800000,0 144.983450000000,-37.8199666700000,0</coordinates></LinearRing>")]
        [InlineData("Test", 0, false, false, AltMode.ClampToGround, "<LinearRing id=\"Test\"><coordinates>144.983450000000,-37.8199666700000,0 151.215297200000,-33.8567833300000,0 142.531413900000,-10.6871138900000,0 131.036883300000,-25.3444277800000,0 144.983450000000,-37.8199666700000,0</coordinates></LinearRing>")]
        public void LinearRing_CorrectlyConvertsToKML(string id, double altitudeOffset, bool extrude, bool tesselate, AltMode altitudeMode, string expected)
        {
            var coordinates = CreateCoordinatesList();

            var sut = new LinearRing(id, coordinates)
            {
                AltitudeOffset = new AltitudeOffset(altitudeOffset),
                Extrude = new Extrude(extrude),
                Tessellate = new Tessellate(tesselate),
                AltitudeMode = new AltitudeMode(altitudeMode)
            };

            var result = sut.ConvertObjectToKML();

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
