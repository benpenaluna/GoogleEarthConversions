using GoogleEarthConversions.Core.KML.Feature.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GoogleEarthConventions.Tests.KML.Feature.Attributes
{
    public class SimpleDataTests
    {
        [Fact]
        public void SimpleData_CanInstantiate()
        {
            var sut = new SimpleData();

            Assert.NotNull(sut);
        }

        [Fact]
        public void SimpleData_AllPropertiesInitialised()
        {
            var sut = new SimpleData();

            foreach (var prop in sut.GetType().GetProperties())
            {
                var value = prop.GetValue(sut);
                Assert.NotNull(value);
            }
        }

        [Theory]
        [InlineData("", "", "")]
        [InlineData("TrailHeadName", "", "")]
        [InlineData("TrailHeadName", "Pi in the sky", "<SimpleData name=\"TrailHeadName\">Pi in the sky</SimpleData>")]
        public void SimpleData_CorrectlyConvertsToKML(string name, string value, string expected)
        {
            var sut = new SimpleData(name, value);

            var result = sut.ConvertObjectToKML();

            Assert.Equal(expected, result);
        }
    }
}
