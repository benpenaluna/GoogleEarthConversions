using GoogleEarthConversions.Core.KML.StyleSelector.Attributes;
using System;
using Xunit;

namespace GoogleEarthConventions.Tests.KML.StyleSelector.Attributes
{
    public class PairTests
    {
        [Theory]
        [InlineData("https://user:password@www.contoso.com:80/Home/Index.htm?q1=v1&q2=v2#FragmentName")]
        public void Pair_CanInstantiateWithUri(string href)
        {
            var url = new Uri(href);
            var sut = new Pair(url);

            Assert.NotNull(sut);
        }
        [Theory]
        [InlineData("https://user:password@www.contoso.com:80/Home/Index.htm?q1=v1&q2=v2#FragmentName")]
        public void Pair_CanInstantiateWithStyleUrl(string href)
        {
            var styleUrl = new StyleUrl(new Uri(href));
            var sut = new Pair(styleUrl);

            Assert.NotNull(sut);
        }

        [Theory]
        [InlineData("https://user:password@www.contoso.com:80/Home/Index.htm?q1=v1&q2=v2#FragmentName")]
        public void Pair_AllPropertiesInitialised(string href)
        {
            var url = new Uri(href);
            var sut = new Pair(url);

            foreach (var prop in sut.GetType().GetProperties())
            {
                var value = prop.GetValue(sut);
                Assert.NotNull(value);
            }
        }

        [Fact]
        public void Pair_ThrowsExceptionOnInavlidUrl()
        {
            Assert.Throws<UriFormatException>(() => new Pair(new Uri(string.Empty)));
        }

        [Theory]
        [InlineData("https://user:password@www.contoso.com:80/Home/Index.htm?q1=v1&q2=v2#FragmentName", StyleStateEnum.Normal, false, "<Pair><key>normal</key><styleUrl>https://user:password@www.contoso.com:80/Home/Index.htm?q1=v1&q2=v2#FragmentName</styleUrl></Pair>")]
        [InlineData("https://user:password@www.contoso.com:80/Home/Index.htm?q1=v1&q2=v2#FragmentName", StyleStateEnum.Normal, true, "<Pair><key>normal</key><styleUrl>#FragmentName</styleUrl></Pair>")]
        [InlineData("https://user:password@www.contoso.com:80/Home/Index.htm?q1=v1&q2=v2#FragmentName", StyleStateEnum.Highlight, false, "<Pair><key>highlight</key><styleUrl>https://user:password@www.contoso.com:80/Home/Index.htm?q1=v1&q2=v2#FragmentName</styleUrl></Pair>")]
        [InlineData("https://user:password@www.contoso.com:80/Home/Index.htm?q1=v1&q2=v2#FragmentName", StyleStateEnum.Highlight, true, "<Pair><key>highlight</key><styleUrl>#FragmentName</styleUrl></Pair>")]
        public void Pair_CorrectlyConvertsToKML(string href, StyleStateEnum styleState, bool styleLocal, string expected)
        {
            var uri = new Uri(href);
            var styleUrl = new StyleUrl(uri, styleLocal);
            var sut = new Pair(styleUrl, styleState);

            var result = sut.SerialiseToKML();

            Assert.Equal(expected, result);
        }
    }
}
