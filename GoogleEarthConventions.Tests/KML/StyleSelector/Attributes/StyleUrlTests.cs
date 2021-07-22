using GoogleEarthConversions.Core.KML.StyleSelector.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GoogleEarthConventions.Tests.KML.StyleSelector.Attributes
{
    public class StyleUrlTests
    {
        [Theory]
        [InlineData("https://user:password@www.contoso.com:80/Home/Index.htm?q1=v1&q2=v2#FragmentName")]
        public void StyleUrl_CanInstantiate(string href)
        {
            var url = new Uri(href);
            var sut = new StyleUrl(url);

            Assert.NotNull(sut);
        }

        [Theory]
        [InlineData("https://user:password@www.contoso.com:80/Home/Index.htm?q1=v1&q2=v2#FragmentName")]
        public void StyleUrl_AllPropertiesInitialised(string href)
        {
            var url = new Uri(href);
            var sut = new StyleUrl(url);

            foreach (var prop in sut.GetType().GetProperties())
            {
                var value = prop.GetValue(sut);
                Assert.NotNull(value);
            }
        }

        [Fact]
        public void StyleUrl_ThrowsExceptionOnInavlidUrl()
        {
            Assert.Throws<UriFormatException>(() => new StyleUrl(new Uri(string.Empty)));
        }

        [Theory]
        [InlineData("https://user:password@www.contoso.com:80/Home/Index.htm?q1=v1&q2=v2#FragmentName", false, "<styleUrl>https://user:password@www.contoso.com:80/Home/Index.htm?q1=v1&q2=v2#FragmentName</styleUrl>")]
        [InlineData("https://user:password@www.contoso.com:80/Home/Index.htm?q1=v1&q2=v2#FragmentName", true, "<styleUrl>#FragmentName</styleUrl>")]
        public void StyleUrl_CorrectlyConvertsToKML(string href, bool styleLocal, string expected)
        {
            var uri = new Uri(href);
            var sut = new StyleUrl(uri, styleLocal);

            var result = sut.SerialiseToKML();

            Assert.Equal(expected, result);
        }
    }
}
