using GoogleEarthConversions.Core.Common;
using GoogleEarthConversions.Core.KML.StyleSelector.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GoogleEarthConventions.Tests.KML.StyleSelector.Attributes
{
    public class HrefTests
    {
        [Fact]
        public void Href_CanInstantiate()
        {
            var sut = new Href(string.Empty);

            Assert.NotNull(sut);
        }

        [Fact]
        public void Href_AllPropertiesInitialised()
        {
            var sut = new Href(string.Empty);

            foreach (var prop in sut.GetType().GetProperties())
            {
                var value = prop.GetValue(sut);
                Assert.NotNull(value);
            }
        }

        [Fact]
        public void Href_InstantiatesWithValidUri()
        {
            var validUri = "https://user:password@www.contoso.com:80/Home/Index.htm?q1=v1&q2=v2#FragmentName";
            var sut = new Href(validUri);

            Assert.NotNull(sut);
        }

        [Fact]
        public void Href_ExceptionOnInvalidUri()
        {
            var invalidUri = "Invalid URI";

            Assert.Throws<UriFormatException>(() => new Href(invalidUri));
        }
    }
}
