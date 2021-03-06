﻿using GoogleEarthConversions.Core.KML.Geometry.Attributes;
using Xunit;

namespace GoogleEarthConventions.Tests.KML.Geometry.Attributes
{
    public class ExtrudeTests
    {
        [Fact]
        public void Extrude_CanInstantiate()
        {
            var sut = new Extrude();

            Assert.NotNull(sut);
        }

        [Fact]
        public void Extrude_AllPropertiesInitialised()
        {
            var sut = new Extrude();

            foreach (var prop in sut.GetType().GetProperties())
            {
                var value = prop.GetValue(sut);
                Assert.NotNull(value);
            }
        }

        [Theory]
        [InlineData(false, "")]
        [InlineData(true, "<extrude>1</extrude>")]
        public void Extrude_CorrectlyConvertsToKML(bool value, string expected)
        {
            var sut = new Extrude(value);

            var result = sut.SerialiseToKML();

            Assert.Equal(expected, result);
        }
    }
}
