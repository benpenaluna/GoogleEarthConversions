using GoogleEarthConversions.Core.KML.TimePrimitive.Attributes;
using System;
using Xunit;

namespace GoogleEarthConventions.Tests.KML.TimePrimative.Attributes
{
    public class TimeSpanDateTimeTests
    {
        [Fact]
        public void TimeSpanDateTime_CanInstantiate()
        {
            var sut = new TimeSpanDateTime(null);

            Assert.NotNull(sut);
        }

        [Fact]
        public void TimeSpanDateTime_AllPropertiesInitialised()
        {
            var sut = new TimeSpanDateTime(null);

            foreach (var prop in sut.GetType().GetProperties())
            {
                var value = prop.GetValue(sut);
                Assert.NotNull(value);
            }
        }

        [Theory]
        [InlineData(2020, 12, 28, 12, 10, 52)]
        public void TimeSpanDateTime_AllPropertiesInitialisedWithDateTimeProvided(int year, int month, int day, int hour, int minute, int second)
        {
            var dateTime = new DateTime(year, month, day, hour, minute, second);
            var sut = new TimeSpanDateTime(dateTime);

            foreach (var prop in sut.GetType().GetProperties())
            {
                var value = prop.GetValue(sut);
                Assert.NotNull(value);
            }
        }

        [Theory]
        [InlineData(2020, 12, 28, 12, 10, 52)]
        public void TimeSpanDateTime_DateTimeCorrectlyPopulates(int year, int month, int day, int hour, int minute, int second)
        {
            var expected = new DateTime(year, month, day, hour, minute, second);
            var sut = new TimeSpanDateTime(expected);

            var result = sut.DateTime;

            Assert.Equal(expected, result);
        }

        [Fact]
        public void TimeSpanDateTime_EnabledCorrectlyPopulates()
        {
            var expected = false;
            var sut = new TimeSpanDateTime(null);

            var result = sut.Enabled;

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(2020, 12, 28, 12, 10, 52)]
        public void TimeSpanDateTime_EnabledCorrectlyPopulatesWithDateTimeProvided(int year, int month, int day, int hour, int minute, int second)
        {
            var expected = true;

            var dateTime = new DateTime(year, month, day, hour, minute, second);
            var sut = new TimeSpanDateTime(dateTime);

            var result = sut.Enabled;

            Assert.Equal(expected, result);
        }
    }
}
