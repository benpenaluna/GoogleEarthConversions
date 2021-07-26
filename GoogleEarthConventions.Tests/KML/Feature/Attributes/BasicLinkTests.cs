using GoogleEarthConversions.Core.KML.Feature.Attributes;
using System;
using Xunit;

namespace GoogleEarthConventions.Tests.KML.Feature.Attributes
{
    public class BasicLinkTests
    {
        [Fact]
        public void BasicLink_CanInstantiate()
        {
            var sut = new BasicLink();

            Assert.NotNull(sut);
        }

        [Fact]
        public void BasicLink_AllPropertiesInitialised()
        {
            var sut = new BasicLink();

            foreach (var prop in sut.GetType().GetProperties())
            {
                var value = prop.GetValue(sut);
                Assert.NotNull(value);
            }
        }

        [Fact]
        public void BasicLink_InstantiatesWithValidUri()
        {
            var validUri = "https://user:password@www.contoso.com:80/Home/Index.htm?q1=v1&q2=v2#FragmentName";
            var sut = new BasicLink(validUri);

            Assert.NotNull(sut);
        }

        [Fact]
        public void BasicLink_ExceptionOnInvalidUri()
        {
            var invalidUri = "Invalid URI";

            Assert.Throws<UriFormatException>(() => new BasicLink(invalidUri));
        }

        [Theory]
        [InlineData("", "")]
        [InlineData("http://www.harrypotter.com", "<atom:link href=\"http://www.harrypotter.com\" />")]
        public void LatLonAltBox_CorrectlyConvertsToKML(string uri, string expected)
        {
            var sut = new BasicLink(uri);

            var result = sut.SerialiseToKML();

            Assert.Equal(expected, result);
        }
    }
}
