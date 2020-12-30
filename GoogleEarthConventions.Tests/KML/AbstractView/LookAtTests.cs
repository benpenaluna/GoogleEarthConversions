using GeoFunctions.Core.Coordinates;
using GeoFunctions.Core.Coordinates.Measurement;
using GoogleEarthConversions.Core.KML.AbstractView;
using GoogleEarthConversions.Core.KML.AbstractView.Attributes;
using GoogleEarthConversions.Core.KML.Geometry.Attributes;
using GoogleEarthConversions.Core.KML.TimePrimitive;
using Xunit;

namespace GoogleEarthConventions.Tests.KML.AbstractView
{
    public class LookAtTests
    {
        [Fact]
        public void LookAt_CanInstantiate()
        {
            var sut = new LookAt(CreateRange());

            Assert.NotNull(sut);
        }

        [Fact]
        public void LookAt_AllPropertiesInitialised()
        {
            var sut = new LookAt(CreateRange());

            foreach (var prop in sut.GetType().GetProperties())
            {
                var value = prop.GetValue(sut);
                Assert.NotNull(value);
            }
        }

        [Theory]
        [InlineData("", 0, 0, 0, 0, 0, 500.0, AltMode.RelativeToGround,
            "<LookAt>" +
                "<gx:TimeStamp><when>2020-12-28T12:10:52+11:00</when></gx:TimeStamp>" +
                "<gx:ViewerOptions><gx:option enabled=\"0\" name=\"historicalimagery\"></gx:option><gx:option enabled=\"0\" name=\"sunlight\"></gx:option><gx:option enabled=\"0\" name=\"streetview\"></gx:option></gx:ViewerOptions>" +
                "<longitude>0</longitude>" +
                "<latitude>0</latitude>" +
                "<altitude>0</altitude>" +
                "<heading>0</heading>" +
                "<tilt>0</tilt>" +
                "<range>500</range>" +
                "<altitudeMode>relativeToGround</altitudeMode>" +
            "</LookAt>")]
        [InlineData("Test", 144.98345, -37.81996667, 96.0, 10.0, 45.0, 500.0, AltMode.ClampToGround,
            "<LookAt id=\"Test\">" +
                "<gx:TimeStamp><when>2020-12-28T12:10:52+11:00</when></gx:TimeStamp>" +
                "<gx:ViewerOptions><gx:option enabled=\"0\" name=\"historicalimagery\"></gx:option><gx:option enabled=\"0\" name=\"sunlight\"></gx:option><gx:option enabled=\"0\" name=\"streetview\"></gx:option></gx:ViewerOptions>" +
                "<longitude>144.98345</longitude>" +
                "<latitude>-37.81996667</latitude>" +
                "<altitude>96</altitude>" +
                "<heading>10</heading>" +
                "<tilt>45</tilt>" +
                "<range>500</range>" +
            "</LookAt>")]
        public void LookAt_CorrectlyConvertsToKML(string id, double longitude, double latitude, double altitude,
                                                  double heading, double tilt, double range, AltMode altitudeMode, string expected)
        {
            IDistance rangeObject = new Range(range, DistanceMeasurement.Meters);
            var sut = new LookAt(rangeObject)
            {
                Id = id,
                TimePrimitive = CreateTimeStamp(),
                Longitude = new GoogleEarthConversions.Core.Geographical.Longitude(longitude, AngleMeasurement.Degrees),
                Latitude = new GoogleEarthConversions.Core.Geographical.Latitude(latitude, AngleMeasurement.Degrees),
                Altitude = new Altitude(altitude, DistanceMeasurement.Meters),
                Heading = new Heading(heading, AngleMeasurement.Degrees),
                Tilt = new Tilt(tilt, AngleMeasurement.Degrees),
                Range = new Range(range, DistanceMeasurement.Meters),
                AltitudeMode = new AltitudeMode(altitudeMode)
            };

            var result = sut.ConvertObjectToKML();

            Assert.Equal(expected, result);
        }

        private IDistance CreateRange()
        {
            return new Distance(500.0, DistanceMeasurement.Meters);
        }

        private TimeStamp CreateTimeStamp()
        {
            var dateTime = new System.DateTime(2020, 12, 28, 12, 10, 52);
            var timeZoneInfo = System.TimeZoneInfo.FindSystemTimeZoneById("AUS Eastern Standard Time");
            return new TimeStamp(dateTime, timeZoneInfo);
        }
    }
}
