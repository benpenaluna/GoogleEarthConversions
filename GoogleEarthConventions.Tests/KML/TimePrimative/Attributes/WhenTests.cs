﻿using GoogleEarthConversions.Core.KML.TimePrimitive.Attributes;
using System;
using Xunit;

namespace GoogleEarthConventions.Tests.KML.TimePrimative.Attributes
{
    public class WhenTests
    {
        [Fact]
        public void When_CanInstantiate()
        {
            var sut = new When(DateTime.Now, TimeZoneInfo.Local);

            Assert.NotNull(sut);
        }

        [Fact]
        public void When_AllPropertiesInitialised()
        {
            var sut = new When(DateTime.Now, TimeZoneInfo.Local);

            foreach (var prop in sut.GetType().GetProperties())
            {
                var value = prop.GetValue(sut);
                Assert.NotNull(value);
            }
        }

        [Theory]
        [InlineData(2020, 12, 28, 12, 10, 52, "AUS Eastern Standard Time", "<when>2020-12-28T12:10:52+11:00</when>")]
        [InlineData(2020, 12, 28, 12, 10, 52, "Canada Central Standard Time", "<when>2020-12-28T12:10:52-06:00</when>")]
        [InlineData(2020, 12, 28, 12, 10, 52, "GMT Standard Time", "<when>2020-12-28T12:10:52+00:00</when>")]
        public void When_CorrectlyConvertsToKML(int year, int month, int day, int hour, int minute, int second, string timeZoneId, string expected)
        {
            var dateTime = new DateTime(year, month, day, hour, minute, second);
            var timeZone = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);

            var sut = new When(dateTime, timeZone);

            var result = sut.SerialiseToKML();

            Assert.Equal(expected, result);
        }


    }
}
