using GoogleEarthConversions.Core.Common;
using GoogleEarthConversions.Core.KML.Geometry;
using GoogleEarthConversions.Core.KML.Geometry.Attributes;
using System;
using System.Collections.Generic;
using Xunit;

namespace GoogleEarthConventions.Tests.KML.Geometry
{
    public class LineStringTests
    {
        [Fact]
        public void LineString_CanInstantiate()
        {
            ICollection<ICoordinates> coordinates = CreateCoordinatesList();

            var sut = new LineString(coordinates);

            Assert.NotNull(sut);
        }

        [Fact]
        public void LineString_InstantiatationFailsIfCoordinatesNull()
        {
            ICollection<ICoordinates> coordinates = null;

            Assert.Throws<NullReferenceException>(() => new LineString(coordinates));
        }

        [Theory]
        [InlineData(-37.81996667, 144.98345)]
        public void LineString_InstantiatationFailsIfLessThan2CoordinatesProvided(double latA, double lonA)
        {
            ICollection<ICoordinates> coordinates = new List<ICoordinates>()
            {
                new Coordinates(latA, lonA)
            };

            Assert.Throws<InvalidOperationException>(() => new LineString(coordinates));
        }

        [Fact]
        public void LineString_CorrectlyInitialisesProperties()
        {
            ICollection<ICoordinates> coordinates = CreateCoordinatesList();

            var expected = new LineString(coordinates)
            {
                Id = string.Empty,
                AltitudeOffset = new AltitudeOffset(),
                Extrude = new Extrude(),
                Tessellate = new Tessellate(),
                AltitudeMode = new AltitudeMode(),
                DrawOrder = new DrawOrder()
            };

            var result = new LineString(coordinates);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("Test", 0.0, false, false, AltMode.ClampToGround, 0, "<LineString id=\"Test\"><coordinates>144.98345,-37.81996667,0 151.2152972,-33.85678333,0</coordinates></LineString>")]
        [InlineData("Test", 0.0, true, true, AltMode.RelativeToSeaFloor, 0, "<LineString id=\"Test\"><extrude>1</extrude><tessellate>1</tessellate><gx:altitudeMode>relativeToSeaFloor</gx:altitudeMode><coordinates>144.98345,-37.81996667,0 151.2152972,-33.85678333,0</coordinates></LineString>")]
        [InlineData("Test", 200.0, true, true, AltMode.ClampToGround, 0, "<LineString id=\"Test\"><gx:altitudeOffset>200</gx:altitudeOffset><extrude>1</extrude><tessellate>1</tessellate><coordinates>144.98345,-37.81996667,0 151.2152972,-33.85678333,0</coordinates></LineString>")]
        [InlineData("Test", 0, false, false, AltMode.ClampToGround, 1, "<LineString id=\"Test\"><gx:drawOrder>1</gx:drawOrder><coordinates>144.98345,-37.81996667,0 151.2152972,-33.85678333,0</coordinates></LineString>")]
        public void LineString_CorrectlyConvertsToKML(string id, double altitudeOffset, bool extrude, bool tesselate, AltMode altitudeMode, int drawOrder, string expected)
        {
            var coordinates = CreateCoordinatesList();

            var sut = new LineString(coordinates)
            {
                Id = id,
                AltitudeOffset = new AltitudeOffset(altitudeOffset),
                Extrude = new Extrude(extrude),
                Tessellate = new Tessellate(tesselate),
                AltitudeMode = new AltitudeMode(altitudeMode),
                DrawOrder = new DrawOrder(drawOrder)
            };

            var result = sut.ConvertObjectToKML();

            Assert.Equal(expected, result);
        }

        private ICollection<ICoordinates> CreateCoordinatesList()
        {
            return new List<ICoordinates>()
            {
                new Coordinates(-37.81996667, 144.98345),
                new Coordinates(-33.85678333, 151.2152972)
            };
        }
    }
}
