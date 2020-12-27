using GeoFunctions.Core.Coordinates;
using GeoFunctions.Core.Coordinates.Measurement;
using GoogleEarthConversions.Core.KML.Geometry;
using GoogleEarthConversions.Core.KML.Geometry.Attributes;
using System;
using Xunit;

namespace GoogleEarthConventions.Tests.KML.Geometry
{
    public class PointTests
    {
        [Theory]
        [InlineData(-33.85678333, 151.2152972, 0)]
        public void Point_CorrectlyInstantiates(double lat, double lon, double elev)
        {
            ICoordinates coordinate = new Coordinates(lat, lon, elev);

            var sut = new Point(coordinate)
            {
                Id = "",
                Extrude = new Extrude(),
                AltitudeMode = new AltitudeMode(),
                Coordinates = coordinate
            };

            Assert.NotNull(sut);
        }

        [Fact]
        public void Polygon_InstantiatationFailsIfCoordinatesNull()
        {
            ICoordinates coordinate = null;

            Assert.Throws<NullReferenceException>(() => new Point(coordinate));
        }


        [Theory]
        [InlineData(-33.85678333, 151.2152972, 0)]
        public void Point_CorrectlyInitialisesProperties(double lat, double lon, double elev)
        {
            ICoordinates coordinate = new Coordinates(lat, lon, elev);

            var expected = new Point(coordinate)
            {
                Id = "",
                Extrude = new Extrude(),
                AltitudeMode = new AltitudeMode(),
                Coordinates = coordinate
            };

            var result = new Point(coordinate);

            Assert.Equal(expected, result);
        }


        [Theory]
        [InlineData("", AltMode.RelativeToGround, true, "<Point><extrude>1</extrude><altitudeMode>relativeToGround</altitudeMode><coordinates>000.000000000000,00.0000000000000,119</coordinates></Point>")]
        [InlineData("Test", AltMode.Absolute, true, "<Point id=\"Test\"><extrude>1</extrude><altitudeMode>absolute</altitudeMode><coordinates>000.000000000000,00.0000000000000,119</coordinates></Point>")]
        [InlineData("", AltMode.RelativeToSeaFloor, true, "<Point><extrude>1</extrude><gx:altitudeMode>relativeToSeaFloor</gx:altitudeMode><coordinates>000.000000000000,00.0000000000000,119</coordinates></Point>")]
        [InlineData("Test", AltMode.ClampToGround, false, "<Point id=\"Test\"><coordinates>000.000000000000,00.0000000000000,119</coordinates></Point>")]
        [InlineData("", AltMode.Absolute, false, "<Point><altitudeMode>absolute</altitudeMode><coordinates>000.000000000000,00.0000000000000,119</coordinates></Point>")]
        [InlineData("Test", AltMode.RelativeToSeaFloor, false, "<Point id=\"Test\"><gx:altitudeMode>relativeToSeaFloor</gx:altitudeMode><coordinates>000.000000000000,00.0000000000000,119</coordinates></Point>")]
        [InlineData("", AltMode.ClampToSeaFloor, false, "<Point><gx:altitudeMode>clampToSeaFloor</gx:altitudeMode><coordinates>000.000000000000,00.0000000000000,119</coordinates></Point>")]
        public void Point_CorrectlyConvertsToKML(string id, AltMode altitudeMode, bool extrude, string expected)
        {
            var coordinate = new Coordinates() { Elevation = new Distance(118.663, DistanceMeasurement.Meters) };

            var sut = new Point(coordinate)
            {
                Id = id,
                AltitudeMode = new AltitudeMode(altitudeMode),
                Extrude = new Extrude(extrude)
            };

            var result = sut.ConvertObjectToKML();

            Assert.Equal(expected, result);
        }
    }
}
