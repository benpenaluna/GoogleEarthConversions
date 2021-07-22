using GeoFunctions.Core.Coordinates;
using GeoFunctions.Core.Coordinates.Measurement;
using GoogleEarthConversions.Core.KML.Geometry.Attributes;
using GoogleEarthConversions.Core.KML.Object;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GoogleEarthConventions.Tests.KML.Object
{
    public class LatLonAltBoxTests
    {
        [Fact]
        public void LatLonAltBox_CanInstantiate()
        {
            var sut = new LatLonAltBox();

            Assert.NotNull(sut);
        }

        [Fact]
        public void LatLonAltBox_AllPropertiesInitialised()
        {
            var sut = new LatLonAltBox();

            foreach (var prop in sut.GetType().GetProperties())
            {
                var value = prop.GetValue(sut);
                Assert.NotNull(value);
            }
        }

        [Fact]
        public void LatLonAltBox_ExceptionOnNorthNullProvided()
        {
            var sut = new LatLonAltBox();

            Assert.Throws<NullReferenceException>(() => sut.UpdateNorthAngle(null));
        }

        [Theory]
        [InlineData(90.1)]
        public void LatLonAltBox_ExceptionOInvalidNorthAngle(double northAngleinDegrees)
        {
            var sut = new LatLonAltBox();
            
            IAngle newNorthAngle = new Angle(northAngleinDegrees, AngleMeasurement.Degrees);
            Assert.Throws<ArgumentOutOfRangeException>(() => sut.UpdateNorthAngle(newNorthAngle));
        }

        [Fact]
        public void LatLonAltBox_ExceptionOnSouthNullProvided()
        {
            var sut = new LatLonAltBox();

            Assert.Throws<NullReferenceException>(() => sut.UpdateSouthAngle(null));
        }

        [Theory]
        [InlineData(-90.1)]
        public void LatLonAltBox_ExceptionOInvalidSouthAngle(double southAngleinDegrees)
        {
            var sut = new LatLonAltBox();

            IAngle newSouthAngle = new Angle(southAngleinDegrees, AngleMeasurement.Degrees);
            Assert.Throws<ArgumentOutOfRangeException>(() => sut.UpdateSouthAngle(newSouthAngle));
        }

        [Fact]
        public void LatLonAltBox_ExceptionOnEastNullProvided()
        {
            var sut = new LatLonAltBox();

            Assert.Throws<NullReferenceException>(() => sut.UpdateEastAngle(null));
        }

        [Theory]
        [InlineData(180.1)]
        public void LatLonAltBox_ExceptionOInvalidEastAngle(double eastAngleinDegrees)
        {
            var sut = new LatLonAltBox();

            IAngle newEastAngle = new Angle(eastAngleinDegrees, AngleMeasurement.Degrees);
            Assert.Throws<ArgumentOutOfRangeException>(() => sut.UpdateEastAngle(newEastAngle));
        }

        [Fact]
        public void LatLonAltBox_ExceptionOnWestNullProvided()
        {
            var sut = new LatLonAltBox();

            Assert.Throws<NullReferenceException>(() => sut.UpdateWestAngle(null));
        }

        [Theory]
        [InlineData(-180.1)]
        public void LatLonAltBox_ExceptionOInvalidWestAngle(double westAngleinDegrees)
        {
            var sut = new LatLonAltBox();

            IAngle newWestAngle = new Angle(westAngleinDegrees, AngleMeasurement.Degrees);
            Assert.Throws<ArgumentOutOfRangeException>(() => sut.UpdateWestAngle(newWestAngle));
        }

        [Theory]
        [InlineData(43.374, 42.983, -0.335, -1.423, 0, 0, AltMode.ClampToGround, "<LatLonAltBox><north>43.374</north><south>42.983</south><east>-0.335</east><west>-1.423</west>" +
                                                                                 "<minAltitude>0</minAltitude><maxAltitude>0</maxAltitude></LatLonAltBox>")]
        [InlineData(42.983, 43.374, -1.423, -0.335, 100.0, 150.0, AltMode.RelativeToGround, "<LatLonAltBox><north>42.983</north><south>43.374</south><east>-1.423</east><west>-0.335</west>" +
                                                                                            "<minAltitude>100</minAltitude><maxAltitude>150</maxAltitude><altitudeMode>relativeToGround</altitudeMode></LatLonAltBox>")]
        [InlineData(43.374, 42.983, -0.335, -1.423, 150.0, 100.0, AltMode.ClampToGround, "<LatLonAltBox><north>43.374</north><south>42.983</south><east>-0.335</east><west>-1.423</west>" +
                                                                                         "<minAltitude>150</minAltitude><maxAltitude>100</maxAltitude></LatLonAltBox>")]
        public void LatLonAltBox_CorrectlyConvertsToKML(double north, double south, double east, double west, double minAlt, double maxAlt, AltMode altMode, string expected)
        {
            var sut = new LatLonAltBox() { AltitudeMode = new AltitudeMode(altMode) };
            sut.UpdateNorthAngle(new Angle(north));
            sut.UpdateSouthAngle(new Angle(south));
            sut.UpdateEastAngle(new Angle(east));
            sut.UpdateWestAngle(new Angle(west));
            sut.UpdateMinAltitude(minAlt, DistanceMeasurement.Meters);
            sut.UpdateMaxAltitude(maxAlt, DistanceMeasurement.Meters);

            var result = sut.SerialiseToKML();

            Assert.Equal(expected, result);
        }
    }
}
