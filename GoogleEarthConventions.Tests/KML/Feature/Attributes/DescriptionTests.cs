using GoogleEarthConversions.Core.KML.Feature.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GoogleEarthConventions.Tests.KML.Feature.Attributes
{
    public class DescriptionTests
    {
        [Fact]
        public void Description_CanInstantiate()
        {
            var sut = new Description();

            Assert.NotNull(sut);
        }

        [Fact]
        public void Description_AllPropertiesInitialised()
        {
            var sut = new Description();

            foreach (var prop in sut.GetType().GetProperties())
            {
                var value = prop.GetValue(sut);
                Assert.NotNull(value);
            }
        }

        [Theory]
        [InlineData("", "")]
        [InlineData("Some Descriptive text.", "<description>Some Descriptive text.</description>")]
        public void Description_CorrectlyConvertsToKML(string value, string expected)
        {
            var sut = new Description(value);

            var result = sut.ConvertObjectToKML();

            Assert.Equal(expected, result);
        }
    }
}
