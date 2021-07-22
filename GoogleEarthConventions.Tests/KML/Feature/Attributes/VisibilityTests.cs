using GoogleEarthConversions.Core.KML.Feature.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GoogleEarthConventions.Tests.KML.Feature.Attributes
{
    public class VisibilityTests
    {
        [Fact]
        public void Visibility_CanInstantiate()
        {
            var sut = new Visibility();

            Assert.NotNull(sut);
        }

        [Fact]
        public void Visibility_AllPropertiesInitialised()
        {
            var sut = new Visibility();

            foreach (var prop in sut.GetType().GetProperties())
            {
                var value = prop.GetValue(sut);
                Assert.NotNull(value);
            }
        }

        [Theory]
        [InlineData(false, "")]
        [InlineData(true, "<visibility>1</visibility>")]
        public void Visibility_CorrectlyConvertsToKML(bool value, string expected)
        {
            var sut = new Visibility(value);

            var result = sut.SerialiseToKML();

            Assert.Equal(expected, result);
        }
    }
}
