using GeoFunctions.Core.Coordinates;
using GeoFunctions.Core.Coordinates.Measurement;
using GoogleEarthConversions.Core.KML.AbstractView.Attributes;
using System;
using Xunit;

namespace GoogleEarthConventions.Tests.KML.AbstractView.Attributes
{
    public class RollTests
    {
        [Fact]
        public void Roll_CanInstantiate()
        {
            var sut = new Roll();
            Assert.NotNull(sut);
        }

        [Fact]
        public void Roll_AllPropertiesInitialised()
        {
            var sut = new Roll();

            foreach (var prop in sut.GetType().GetProperties())
            {
                var value = prop.GetValue(sut);
                Assert.NotNull(value);
            }
        }

        [Theory]
        [InlineData(-180.0, AngleMeasurement.Degrees)]
        [InlineData(0.0, AngleMeasurement.Degrees)]
        [InlineData(180.0, AngleMeasurement.Degrees)]
        [InlineData(-Math.PI, AngleMeasurement.Radians)]
        [InlineData(0.0, AngleMeasurement.Radians)]
        [InlineData(Math.PI, AngleMeasurement.Radians)]
        public void Roll_CanInstantiateWithValidDegree(double angle, AngleMeasurement angleMeasurement)
        {
            IAngle testAngle = new Angle(angle, angleMeasurement);
            var expected = testAngle;

            var sut = new Roll(angle, angleMeasurement);
            var result = sut.Angle;

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(double.MinValue, AngleMeasurement.Degrees)]
        [InlineData(-180.0000000000001, AngleMeasurement.Degrees)]
        [InlineData(180.0000000000001, AngleMeasurement.Degrees)]
        [InlineData(-3.1415926535899, AngleMeasurement.Radians)]
        [InlineData(3.1415926535899, AngleMeasurement.Radians)]
        [InlineData(double.MaxValue, AngleMeasurement.Degrees)]
        public void Roll_CannotInstantiateWithInvalidDegree(double angle, AngleMeasurement angleMeasurement)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Roll(angle, angleMeasurement));
        }

        [Theory]
        [InlineData(-180.0, AngleMeasurement.Degrees, "<roll>-180</roll>")]
        [InlineData(0.0, AngleMeasurement.Degrees, "<roll>0</roll>")]
        [InlineData(180.0, AngleMeasurement.Degrees, "<roll>180</roll>")]
        [InlineData(72.5366278, AngleMeasurement.Degrees, "<roll>72.5366278</roll>")]
        [InlineData(-Math.PI, AngleMeasurement.Radians, "<roll>-180</roll>")]
        [InlineData(0.0, AngleMeasurement.Radians, "<roll>0</roll>")]
        [InlineData(Math.PI, AngleMeasurement.Radians, "<roll>180</roll>")]
        public void Roll_CorrectlyConvertsToKML(double angle, AngleMeasurement angleMeasurement, string expected)
        {
            var sut = new Roll(angle, angleMeasurement);

            var result = sut.ConvertObjectToKML();

            Assert.Equal(expected, result);
        }
    }
}
