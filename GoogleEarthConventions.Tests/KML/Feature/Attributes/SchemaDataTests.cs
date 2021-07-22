using GoogleEarthConversions.Core.KML.Feature.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GoogleEarthConventions.Tests.KML.Feature.Attributes
{
    public class SchemaDataTests
    {
        [Fact]
        public void SchemaData_CanInstantiate()
        {
            var sut = new SchemaData();

            Assert.NotNull(sut);
        }

        [Fact]
        public void SchemaData_AllPropertiesInitialised()
        {
            var sut = new SchemaData();

            foreach (var prop in sut.GetType().GetProperties())
            {
                var value = prop.GetValue(sut);
                Assert.NotNull(value);
            }
        }

        [Theory]
        [InlineData("", "", "", "", "", "")]
        [InlineData("", "TrailHeadName", "", "", "", "")]
        [InlineData("#TrailHeadTypeId", "TrailHeadName", "Pi in the sky", "", "", "<SchemaData schemaUrl=\"#TrailHeadTypeId\"><SimpleData name=\"TrailHeadName\">Pi in the sky</SimpleData></SchemaData>")]
        [InlineData("#TrailHeadTypeId", "TrailHeadName", "Pi in the sky", "TrailLength", "3.14159", "<SchemaData schemaUrl=\"#TrailHeadTypeId\"><SimpleData name=\"TrailHeadName\">Pi in the sky</SimpleData><SimpleData name=\"TrailLength\">3.14159</SimpleData></SchemaData>")]
        public void SchemaData_CorrectlyConvertsToKML(string url, string name1, string value1, string name2, string value2, string expected)
        {
            var simpleData = new List<ISimpleData>()
            {
                new SimpleData(name1, value1),
                new SimpleData(name2, value2)
            };
            
            var sut = new SchemaData(url, simpleData);

            var result = sut.SerialiseToKML();

            Assert.Equal(expected, result);
        }
    }
}
