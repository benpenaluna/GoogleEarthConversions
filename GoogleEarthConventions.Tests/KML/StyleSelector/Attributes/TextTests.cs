using GoogleEarthConversions.Core.KML.StyleSelector.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GoogleEarthConventions.Tests.KML.StyleSelector.Attributes
{
    public class TextTests
    {
        [Fact]
        public void Text_CanInstantiate()
        {
            var sut = new Text();

            Assert.NotNull(sut);
        }

        [Fact]
        public void Text_AllPropertiesInitialised()
        {
            var sut = new Text();

            foreach (var prop in sut.GetType().GetProperties())
            {
                var value = prop.GetValue(sut);
                Assert.NotNull(value);
            }
        }

        [Theory]
        [InlineData("", "")]
        [InlineData("Test string", "<text>Test string</text>")]
        public void LatLonAltBox_CorrectlyConvertsToKML(string text, string expected)
        {
            var sut = new Text(text);

            var result = sut.ConvertObjectToKML();

            Assert.Equal(expected, result);
        }
    }
}
