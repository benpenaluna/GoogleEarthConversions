using GeoFunctions.Core.Coordinates;
using GeoFunctions.Core.Coordinates.Measurement;
using GoogleEarthConversions.Core.KML;
using GoogleEarthConversions.Core.KML.Geometry;
using System;
using Xunit;

namespace GoogleEarthConventions.Tests.KML.Geometry
{
    public class PointTests
    {
        [Theory]
        [InlineData("Test")]
        public void Point_CorrectlyInitialisesProperties(string id)
        {
            var expected = new Point(id)
            {
                Extrude = false,
                AltitudeMode = AltitudeMode.ClampToGround,
                Coordinates = new GeographicCoordinate()
            };

            var result = new Point(id);

            Assert.Equal(expected, result);
        }
        
        [Theory]
        [InlineData("Test", -33.85678333, 151.2152972, 0)]
        public void Point_CorrectlyInitialisesPropertiesWithCoordinates(string id, double lat, double lon, double elev)
        {
            IGeographicCoordinate coordinate = new GeographicCoordinate(lat, lon, elev);
            
            var expected = new Point(id, coordinate)
            {
                Extrude = false,
                AltitudeMode = AltitudeMode.ClampToGround,
                Coordinates = new GeographicCoordinate()
            };

            var result = new Point(id);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("Test", AltitudeMode.ClampToGround)]
        [InlineData("Test", AltitudeMode.ClampToSeaFloor)]
        public void Point_ExtrudeThrowsExceptionWhenAltidudeClampOnInitialisation(string id, AltitudeMode altitudeMode)
        {
            Assert.Throws<InvalidOperationException>(() => new Point(id)
            {
                AltitudeMode = altitudeMode,
                Extrude = true,
                Coordinates = new GeographicCoordinate()
            });
        }

        [Theory]
        [InlineData("Test")]
        public void Point_ExtrudeFalseIfAlitudeModeClampToGround(string id)
        {
            var expected = false;

            var sut = new Point(id)
            {
                Extrude = false,
                AltitudeMode = AltitudeMode.RelativeToGround,
                Coordinates = new GeographicCoordinate()
            }; ;

            sut.Extrude = true;
            sut.AltitudeMode = AltitudeMode.ClampToGround;

            var result = sut.Extrude;
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("Test", AltitudeMode.RelativeToGround, true, "<Point id=\"Test\"><extrude>1</extrude><altitudeMode>relativeToGround</altitudeMode><coordinates>000.000000000000,00.0000000000000,119</coordinates></Point>")]
        [InlineData("Test", AltitudeMode.Absolute, true, "<Point id=\"Test\"><extrude>1</extrude><altitudeMode>absolute</altitudeMode><coordinates>000.000000000000,00.0000000000000,119</coordinates></Point>")]
        [InlineData("Test", AltitudeMode.RelativeToSeaFloor, true, "<Point id=\"Test\"><extrude>1</extrude><gx:altitudeMode>relativeToSeaFloor</gx:altitudeMode><coordinates>000.000000000000,00.0000000000000,119</coordinates></Point>")]
        [InlineData("Test", AltitudeMode.ClampToGround, false, "<Point id=\"Test\"><coordinates>000.000000000000,00.0000000000000,119</coordinates></Point>")]
        [InlineData("Test", AltitudeMode.Absolute, false, "<Point id=\"Test\"><altitudeMode>absolute</altitudeMode><coordinates>000.000000000000,00.0000000000000,119</coordinates></Point>")]
        [InlineData("Test", AltitudeMode.RelativeToSeaFloor, false, "<Point id=\"Test\"><gx:altitudeMode>relativeToSeaFloor</gx:altitudeMode><coordinates>000.000000000000,00.0000000000000,119</coordinates></Point>")]
        [InlineData("Test", AltitudeMode.ClampToSeaFloor, false, "<Point id=\"Test\"><gx:altitudeMode>clampToSeaFloor</gx:altitudeMode><coordinates>000.000000000000,00.0000000000000,119</coordinates></Point>")]
        public void Point_CorrectlyConvertsToKML(string id, AltitudeMode altitudeMode, bool extrude, string expected)
        {
            var sut = new Point(id)
            {
                AltitudeMode = altitudeMode,
                Extrude = extrude,
                Coordinates = new GeographicCoordinate()
                {
                    Elevation = new Distance(118.663, DistanceMeasurement.Meters)
                }
            };

            var result = sut.ConvertObjectToKML();

            Assert.Equal(expected, result);
        }
    }
}
