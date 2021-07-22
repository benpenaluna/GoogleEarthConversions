using GeoFunctions.Core.Coordinates;
using GeoFunctions.Core.Coordinates.Measurement;
using GoogleEarthConversions.Core.KML.AbstractView.Attributes;
using System;
using Xunit;

namespace GoogleEarthConventions.Tests.KML.AbstractView.Attributes
{
    public class TiltTests
    {
        [Fact]
        public void Tilt_CanInstantiate()
        {
            var sut = new Tilt();
            Assert.NotNull(sut);
        }

        [Fact]
        public void Tilt_AllPropertiesInitialised()
        {
            var sut = new Tilt();

            foreach (var prop in sut.GetType().GetProperties())
            {
                var value = prop.GetValue(sut);
                Assert.NotNull(value);
            }
        }

        [Theory]
        [InlineData(0.0, AngleMeasurement.Degrees)]
        [InlineData(90.0, AngleMeasurement.Degrees)]
        [InlineData(180.0, AngleMeasurement.Degrees)]
        [InlineData(0.0, AngleMeasurement.Radians)]
        [InlineData(Math.PI / 2.0, AngleMeasurement.Radians)]
        [InlineData(Math.PI, AngleMeasurement.Radians)]
        public void Tilt_CanInstantiateWithValidDegree(double angle, AngleMeasurement angleMeasurement)
        {
            IAngle testAngle = new Angle(angle, angleMeasurement);
            var expected = testAngle;

            var sut = new Tilt(angle, angleMeasurement);
            var result = sut.Angle;

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(double.MinValue, AngleMeasurement.Degrees)]
        [InlineData(-0.0000000000001, AngleMeasurement.Degrees)]
        [InlineData(180.0000000000001, AngleMeasurement.Degrees)]
        [InlineData(-0.0000000000001, AngleMeasurement.Radians)]
        [InlineData(3.1415926535899, AngleMeasurement.Radians)]
        [InlineData(double.MaxValue, AngleMeasurement.Degrees)]
        public void Tilt_CannotInstantiateWithInvalidDegree(double angle, AngleMeasurement angleMeasurement)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Tilt(angle, angleMeasurement));
        }

        [Theory]
        [InlineData(0.0, AngleMeasurement.Degrees, "<tilt>0</tilt>")]
        [InlineData(90.0, AngleMeasurement.Degrees, "<tilt>90</tilt>")]
        [InlineData(180.0, AngleMeasurement.Degrees, "<tilt>180</tilt>")]
        [InlineData(72.5366278, AngleMeasurement.Degrees, "<tilt>72.5366278</tilt>")]
        [InlineData(0.0, AngleMeasurement.Radians, "<tilt>0</tilt>")]
        [InlineData(Math.PI / 2.0, AngleMeasurement.Radians, "<tilt>90</tilt>")]
        [InlineData(Math.PI, AngleMeasurement.Radians, "<tilt>180</tilt>")]
        public void Tilt_CorrectlyConvertsToKML(double angle, AngleMeasurement angleMeasurement, string expected)
        {
            var sut = new Tilt(angle, angleMeasurement);

            var result = sut.SerialiseToKML();

            Assert.Equal(expected, result);
        }
    }
}
