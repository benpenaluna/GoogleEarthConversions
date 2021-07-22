using GeoFunctions.Core.Coordinates.Measurement;
using GoogleEarthConversions.Core.Geographical;
using GoogleEarthConversions.Core.KML.AbstractView;
using GoogleEarthConversions.Core.KML.AbstractView.Attributes;
using GoogleEarthConversions.Core.KML.Geometry.Attributes;
using GoogleEarthConversions.Core.KML.TimePrimitive;
using Xunit;

namespace GoogleEarthConventions.Tests.KML.AbstractView
{
    public class CameraTests
    {
        [Fact]
        public void Camera_CanInstantiate()
        {
            var sut = new Camera();

            Assert.NotNull(sut);
        }

        [Fact]
        public void Camera_AllPropertiesInitialised()
        {
            var sut = new Camera();

            foreach (var prop in sut.GetType().GetProperties())
            {
                var value = prop.GetValue(sut);
                Assert.NotNull(value);
            }
        }

        [Theory]
        [InlineData("", 0, 0, 0, 0, 0, 0, AltMode.RelativeToGround, 
            "<Camera>" +
                "<gx:TimeStamp><when>2020-12-28T12:10:52+11:00</when></gx:TimeStamp>" +
                "<gx:ViewerOptions><gx:option enabled=\"0\" name=\"historicalimagery\"></gx:option><gx:option enabled=\"0\" name=\"sunlight\"></gx:option><gx:option enabled=\"0\" name=\"streetview\"></gx:option></gx:ViewerOptions>" +
                "<longitude>0</longitude>" +
                "<latitude>0</latitude>" +
                "<altitude>0</altitude>" +
                "<heading>0</heading>" +
                "<tilt>0</tilt>" +
                "<roll>0</roll>" +
                "<altitudeMode>relativeToGround</altitudeMode>" +
            "</Camera>")]
        public void Camera_CorrectlyConvertsToKML(string id, double longitude, double latitude, double altitude, 
                                                  double heading, double tilt, double roll, AltMode altitudeMode, string expected)
        {
            var sut = new Camera()
            {
                Id = id,
                TimePrimitive = CreateTimeStamp(),
                Longitude = new Longitude(longitude, AngleMeasurement.Degrees),
                Latitude = new Latitude(latitude, AngleMeasurement.Degrees),
                Altitude = new Altitude(altitude, DistanceMeasurement.Meters),
                Heading = new Heading(heading, AngleMeasurement.Degrees),
                Tilt = new Tilt(tilt, AngleMeasurement.Degrees),
                Roll = new Roll(roll, AngleMeasurement.Degrees),
                AltitudeMode = new AltitudeMode(altitudeMode)
            };

            var result = sut.SerialiseToKML();

            Assert.Equal(expected, result);
        }

        private TimeStamp CreateTimeStamp()
        {
            var dateTime = new System.DateTime(2020, 12, 28, 12, 10, 52);
            var timeZoneInfo = System.TimeZoneInfo.FindSystemTimeZoneById("AUS Eastern Standard Time");
            return new TimeStamp(dateTime, timeZoneInfo);
        }
    }
}
