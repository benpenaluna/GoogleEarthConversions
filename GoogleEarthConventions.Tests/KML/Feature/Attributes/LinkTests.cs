using GoogleEarthConversions.Core.KML.Feature.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GoogleEarthConventions.Tests.KML.Feature.Attributes
{
    public class LinkTests
    {
        [Fact]
        public void Link_CanInstantiate()
        {
            var sut = new Link();

            Assert.NotNull(sut);
        }

        [Fact]
        public void Link_AllPropertiesInitialised()
        {
            var sut = new Link();

            foreach (var prop in sut.GetType().GetProperties())
            {
                var value = prop.GetValue(sut);
                Assert.NotNull(value);
            }
        }

        [Fact]
        public void Link_InstantiatesWithValidUri()
        {
            var validUri = "https://user:password@www.contoso.com:80/Home/Index.htm?q1=v1&q2=v2#FragmentName";
            var sut = new Link(validUri);

            Assert.NotNull(sut);
        }

        [Fact]
        public void Link_ExceptionOnInvalidUri()
        {
            var invalidUri = "Invalid URI";
            
            Assert.Throws<UriFormatException>(() => new Link(invalidUri));
        }

        [Theory]
        [InlineData("", "")]
        [InlineData("http://www.harrypotter.com", "<atom:link href=\"http://www.harrypotter.com\" />")]
        public void LatLonAltBox_CorrectlyConvertsToKML(string uri, string expected)
        {
            var sut = new Link(uri);

            var result = sut.SerialiseToKML();

            Assert.Equal(expected, result);
        }
    }
}
