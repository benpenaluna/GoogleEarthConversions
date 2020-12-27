using GoogleEarthConversions.Core.Common;
using GoogleEarthConversions.Core.KML.Geometry;
using System;
using System.Collections.Generic;
using Xunit;

namespace GoogleEarthConventions.Tests.KML.Geometry
{
    public class PolygonTests
    {
        [Fact]
        public void Polygon_CanInstantiate()
        {
            var linearRingList = new LinearRing(CoordinatesSet1());
            var outerBoundaryIs = new OuterBoundaryIs(linearRingList);

            var sut = new Polygon(outerBoundaryIs);

            Assert.NotNull(sut);
        }

        [Fact]
        public void Polygon_InstantiatationFailsIfCoordinatesNull()
        {
            IOuterBoundaryIs outerBoundaryIs = null;

            Assert.Throws<NullReferenceException>(() => new Polygon(outerBoundaryIs));
        }

        [Fact]
        public void LineString_CorrectlyInitialisesProperties()
        {
            var linearRingList = new LinearRing(CoordinatesSet2());
            var outerBoundaryIs = new OuterBoundaryIs(linearRingList);
            var innerBoundaryIs = new InnerBoundaryIs(CreateLinearRingCollection());

            var expected = new Polygon(outerBoundaryIs, innerBoundaryIs)
            {
                Id = string.Empty,
                Extrude = new Extrude(),
                Tessellate = new Tessellate(),
                AltitudeMode = new AltitudeMode(),
            };

            var result = new Polygon(outerBoundaryIs, innerBoundaryIs);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("", true, true, AltMode.RelativeToGround, "<Polygon><extrude>1</extrude><tessellate>1</tessellate><altitudeMode>relativeToGround</altitudeMode>" +
                                                              "<outerBoundaryIs><LinearRing><coordinates>-074.044500000000,40.6892500000000,0 002.294480556000,48.8583694400000,0 -000.119552778000,51.5032972200000,0 -074.044500000000,40.6892500000000,0</coordinates></LinearRing></outerBoundaryIs>" +
                                                              "<innerBoundaryIs><LinearRing><coordinates>144.983450000000,-37.8199666700000,0 151.215297200000,-33.8567833300000,0 142.531413900000,-10.6871138900000,0 131.036883300000,-25.3444277800000,0 144.983450000000,-37.8199666700000,0</coordinates></LinearRing><LinearRing><coordinates>-074.044500000000,40.6892500000000,0 002.294480556000,48.8583694400000,0 -000.119552778000,51.5032972200000,0 -074.044500000000,40.6892500000000,0</coordinates></LinearRing></innerBoundaryIs></Polygon>")]
        [InlineData("Test", false, false, AltMode.ClampToSeaFloor, "<Polygon id=\"Test\"><gx:altitudeMode>clampToSeaFloor</gx:altitudeMode>" +
                                                                   "<outerBoundaryIs><LinearRing><coordinates>-074.044500000000,40.6892500000000,0 002.294480556000,48.8583694400000,0 -000.119552778000,51.5032972200000,0 -074.044500000000,40.6892500000000,0</coordinates></LinearRing></outerBoundaryIs>" +
                                                                   "<innerBoundaryIs><LinearRing><coordinates>144.983450000000,-37.8199666700000,0 151.215297200000,-33.8567833300000,0 142.531413900000,-10.6871138900000,0 131.036883300000,-25.3444277800000,0 144.983450000000,-37.8199666700000,0</coordinates></LinearRing><LinearRing><coordinates>-074.044500000000,40.6892500000000,0 002.294480556000,48.8583694400000,0 -000.119552778000,51.5032972200000,0 -074.044500000000,40.6892500000000,0</coordinates></LinearRing></innerBoundaryIs></Polygon>")]
        public void LineString_CorrectlyConvertsToKML(string id, bool extrude, bool tesselate, AltMode altitudeMode, string expected)
        {
            var linearRingList = new LinearRing(CoordinatesSet2());
            var outerBoundaryIs = new OuterBoundaryIs(linearRingList);
            var innerBoundaryIs = new InnerBoundaryIs(CreateLinearRingCollection());

            var sut = new Polygon(outerBoundaryIs, innerBoundaryIs)
            {
                Id = id,
                Extrude = new Extrude(extrude),
                Tessellate = new Tessellate(tesselate),
                AltitudeMode = new AltitudeMode(altitudeMode),
            };

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

        private ICollection<ICoordinates> CoordinatesSet1()
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
