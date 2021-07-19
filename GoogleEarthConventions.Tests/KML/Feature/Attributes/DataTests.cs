using GoogleEarthConversions.Core.KML.Feature.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GoogleEarthConventions.Tests.KML.Feature.Attributes
{
    public class DataTests
    {
        [Fact]
        public void Data_CanInstantiate()
        {
            var sut = new Data("Test");

            Assert.NotNull(sut);
        }

        [Fact]
        public void Data_AllPropertiesInitialised()
        {
            var sut = new Data("Test");

            foreach (var prop in sut.GetType().GetProperties())
            {
                var value = prop.GetValue(sut);
                Assert.NotNull(value);
            }
        }

        [Theory]
        [InlineData("test", "", "", "<Data name=\"test\"><value></value></Data>")]
        [InlineData("holeNumber", "1", "", "<Data name=\"holeNumber\"><value>1</value></Data>")]
        [InlineData("holeNumber", "1", "Hole Number", "<Data name=\"holeNumber\"><displayName>Hole Number</displayName><value>1</value></Data>")]
        public void Data_CorrectlyConvertsToKML(string name, string value, string displayName, string expected)
        {
            var sut = new Data(name, value, displayName);

            var result = sut.ConvertObjectToKML();

            Assert.Equal(expected, result);
        }
    }
}
