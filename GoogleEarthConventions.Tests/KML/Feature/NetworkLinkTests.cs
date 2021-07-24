using GoogleEarthConversions.Core.KML.Feature;
using GoogleEarthConversions.Core.KML.Feature.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GoogleEarthConventions.Tests.KML.Feature
{
    public class NetworkLinkTests
    {
        [Fact]
        public void NetworkLink_CanInstantiate()
        {
            var sut = new NetworkLink(new BasicLink());

            Assert.NotNull(sut);
        }
        [Fact]
        public void NetworkLink_InstantiationFailsWithNullLink()
        {
            Assert.Throws<NullReferenceException >(() => new NetworkLink(null));
        }

        [Fact]
        public void NetworkLink_AllPropertiesInitialised()
        {
            var sut = new NetworkLink(new BasicLink());

            foreach (var prop in sut.GetType().GetProperties())
            {
                var value = prop.GetValue(sut);
                Assert.NotNull(value);
            }
        }

        [Theory]
        [InlineData("NE US Radar", "<NetworkLink><name>NE US Radar</name></NetworkLink>")]
        public void NetworkLink_CorrectlyConvertsToKML(string name, string expected)
        {
            var link = new BasicLink();

            var sut = new NetworkLink(link)
            {
                Name = new Name(name)
            };

            var result = sut.SerialiseToKML();

            Assert.Equal(expected, result);
        }
    }
}
