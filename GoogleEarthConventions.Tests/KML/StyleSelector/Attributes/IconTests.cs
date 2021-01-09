using GoogleEarthConversions.Core.KML.StyleSelector.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GoogleEarthConventions.Tests.KML.StyleSelector.Attributes
{
    public class IconTests
    {
        [Fact]
        public void Icon_CanInstantiate()
        {
            var sut = new Icon();

            Assert.NotNull(sut);
        }

        [Fact]
        public void Icon_AllPropertiesInitialised()
        {
            var sut = new Icon();

            foreach (var prop in sut.GetType().GetProperties())
            {
                var value = prop.GetValue(sut);
                Assert.NotNull(value);
            }
        }

        [Fact]
        public void Icon_InstantiatesWithValidUri()
        {
            var validUri = "https://user:password@www.contoso.com:80/Home/Index.htm?q1=v1&q2=v2#FragmentName";
            var sut = new Icon() { Href = validUri };

            Assert.NotNull(sut);
        }

        [Fact]
        public void Icon_ExceptionOnInvalidUri()
        {
            var invalidUri = "Invalid URI";

            Assert.Throws<UriFormatException>(() => new Icon() { Href = invalidUri });
        }

        [Theory]
        [InlineData("", "")]
        [InlineData("https://user:password@www.contoso.com:80/Home/Index.htm?q1=v1&q2=v2#FragmentName", "<Icon><href>https://user:password@www.contoso.com:80/Home/Index.htm?q1=v1&q2=v2#FragmentName</href></Icon>")]
        public void Icon_CorrectlyConvertsToKML(string uri, string expected)
        {
            var sut = new Icon(uri);

            var result = sut.ConvertObjectToKML();

            Assert.Equal(expected, result);
        }

    }
}
