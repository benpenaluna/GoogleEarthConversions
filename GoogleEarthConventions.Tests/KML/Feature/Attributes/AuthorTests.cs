using GoogleEarthConversions.Core.KML.Feature.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GoogleEarthConventions.Tests.KML.Feature.Attributes
{
    public class AuthorTests
    {
        [Fact]
        public void Author_CanInstantiate()
        {
            var sut = new Author();

            Assert.NotNull(sut);
        }

        [Fact]
        public void Author_AllPropertiesInitialised()
        {
            var sut = new Author();

            foreach (var prop in sut.GetType().GetProperties())
            {
                var value = prop.GetValue(sut);
                Assert.NotNull(value);
            }
        }

        [Theory]
        [InlineData("", "")]
        [InlineData("Test", "<atom:author><atom:name>Test</atom:name></atom:author>")]
        public void LatLonAltBox_CorrectlyConvertsToKML(string name, string expected)
        {
            var sut = new Author(name);

            var result = sut.ConvertObjectToKML();

            Assert.Equal(expected, result);
        }
    }
}
