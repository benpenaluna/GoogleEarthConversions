using GoogleEarthConversions.Core.Common;
using GoogleEarthConversions.Core.KML.Feature;
using GoogleEarthConversions.Core.KML.Feature.Attributes;
using GoogleEarthConversions.Core.KML.Object;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GoogleEarthConventions.Tests.KML.Feature
{
    public class NetworkLinkTests
    {
        [Fact]
        public void NetworkLink_CanInstantiateWithLink()
        {
            var validUri = "http://www.example.com";
            var link = new Link() { Href = new Href(validUri) };
            var sut = new NetworkLink(link);

            Assert.NotNull(sut);
        }

        [Fact]
        public void NetworkLink_AllPropertiesInitialisedWithLink()
        {
            var validUri = "http://www.example.com";
            var link = new Link() { Href = new Href(validUri) };
            var sut = new NetworkLink(link);

            foreach (var prop in sut.GetType().GetProperties())
            {
                var value = prop.GetValue(sut);
                Assert.NotNull(value);
            }
        }

        [Fact]
        public void NetworkLink_InstantiationFailsWithNullLink()
        {
            ILink link = null;
            Assert.Throws<ArgumentNullException>(() => new NetworkLink(link));
        }

        [Fact]
        public void NetworkLink_InstantiationFailsWithLinkEmptyHref()
        {
            IHref href = new Href(string.Empty);
            ILink link = new Link() { Href = href };
            Assert.Throws<UriFormatException>(() => new NetworkLink(link));
        }

        [Fact]
        public void NetworkLink_CanInstantiateWithUri()
        {
            var validUri = "http://www.example.com";
            var sut = new NetworkLink(validUri);

            Assert.NotNull(sut);
        }

        [Fact]
        public void NetworkLink_AllPropertiesInitialisedWithUri()
        {
            var validUri = "http://www.example.com";
            var sut = new NetworkLink(validUri);

            foreach (var prop in sut.GetType().GetProperties())
            {
                var value = prop.GetValue(sut);
                Assert.NotNull(value);
            }
        }

        [Fact]
        public void NetworkLink_InstantiationFailsWithNullUri()
        {
            string uri = null;
            Assert.Throws<ArgumentNullException>(() => new NetworkLink(uri));
        }

        [Fact]
        public void NetworkLink_InstantiationFailsWithLinkEmptyUri()
        {
            string uri = string.Empty;
            Assert.Throws<ArgumentNullException>(() => new NetworkLink(uri));
        }

        [Fact]
        public void NetworkLink_InstantiationFailsWithLinkInvalidUri()
        {
            string uri = "Invalid URI";
            Assert.Throws<UriFormatException>(() => new NetworkLink(uri));
        }

        [Theory]
        [InlineData("NE US Radar", false, false, "<NetworkLink><name>NE US Radar</name><Link><href>http://www.example.com</href><viewFormat>BBOX=0,0,0,0</viewFormat></Link></NetworkLink>")]
        [InlineData("NE US Radar", true, true, "<NetworkLink><name>NE US Radar</name><refreshVisibility>1</refreshVisibility><flyToView>1</flyToView><Link><href>http://www.example.com</href><viewFormat>BBOX=0,0,0,0</viewFormat></Link></NetworkLink>")]
        public void NetworkLink_CorrectlyConvertsToKML(string name, bool refreshVisibility, bool flyToView, string expected)
        {
            var uri = "http://www.example.com";
            var sut = new NetworkLink(uri)
            {
                Name = new Name(name),
            };
            sut.RefreshVisibility.Value = refreshVisibility;
            sut.FlyToView.Value = flyToView;

            var result = sut.SerialiseToKML();

            Assert.Equal(expected, result);
        }
    }
}
