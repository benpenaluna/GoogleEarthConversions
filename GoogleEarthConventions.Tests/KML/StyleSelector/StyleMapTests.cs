using GoogleEarthConversions.Core.KML.StyleSelector;
using GoogleEarthConversions.Core.KML.StyleSelector.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GoogleEarthConventions.Tests.KML.StyleSelector
{
    public class StyleMapTests
    {
        [Theory]
        [InlineData("https://user:password@www.contoso.com:80/Home/Index.htm?q1=v1&q2=v2#FragmentName")]
        public void StyleMap_CanInstantiateWithUrl(string url)
        {
            var sut = new StyleMap(new Uri(url));

            Assert.NotNull(sut);
        }

        [Theory]
        [InlineData("https://user:password@www.contoso.com:80/Home/Index.htm?q1=v1&q2=v2#FragmentName")]
        public void StyleMap_AllPropertiesInitialisedWithUrl(string url)
        {
            var sut = new StyleMap(new Uri(url));

            foreach (var prop in sut.GetType().GetProperties())
            {
                var value = prop.GetValue(sut);
                Assert.NotNull(value);
            }
        }

        [Theory]
        [InlineData("https://user:password@www.contoso.com:80/Home/Index.htm?q1=v1&q2=v2#FragmentName")]
        public void StyleMap_CanInstantiateWithIStyleMap(string url)
        {
            var uri = new Uri(url);
            var styleUrl = new StyleUrl(uri);
            var sut = new StyleMap(styleUrl);

            Assert.NotNull(sut);
        }

        [Theory]
        [InlineData("https://user:password@www.contoso.com:80/Home/Index.htm?q1=v1&q2=v2#FragmentName")]
        public void StyleMap_AllPropertiesInitialisedWithIStyleMap(string url)
        {
            var uri = new Uri(url);
            var styleUrl = new StyleUrl(uri);
            var sut = new StyleMap(styleUrl);

            foreach (var prop in sut.GetType().GetProperties())
            {
                var value = prop.GetValue(sut);
                Assert.NotNull(value);
            }
        }

        [Theory]
        [InlineData("https://user:password@www.contoso.com:80/Home/Index.htm?q1=v1&q2=v2#FragmentName")]
        public void StyleMap_CanInstantiateWithPair(string url)
        {
            var uri = new Uri(url);
            var styleUrl = new StyleUrl(uri);
            var pair = new Pair(styleUrl);
            var sut = new StyleMap(pair);

            Assert.NotNull(sut);
        }

        [Theory]
        [InlineData("https://user:password@www.contoso.com:80/Home/Index.htm?q1=v1&q2=v2#FragmentName")]
        public void StyleMap_AllPropertiesInitialisedWithPair(string url)
        {
            var uri = new Uri(url);
            var styleUrl = new StyleUrl(uri);
            var pair = new Pair(styleUrl);
            var sut = new StyleMap(pair);

            foreach (var prop in sut.GetType().GetProperties())
            {
                var value = prop.GetValue(sut);
                Assert.NotNull(value);
            }
        }

        [Theory]
        [InlineData("https://user:password@www.contoso.com:80/Home/Index.htm?q1=v1&q2=v2#FragmentName", StyleStateEnum.Normal, false, "<StyleMap><Pair><key>normal</key><styleUrl>https://user:password@www.contoso.com:80/Home/Index.htm?q1=v1&q2=v2#FragmentName</styleUrl></Pair></StyleMap>")]
        [InlineData("https://user:password@www.contoso.com:80/Home/Index.htm?q1=v1&q2=v2#FragmentName", StyleStateEnum.Normal, true, "<StyleMap><Pair><key>normal</key><styleUrl>#FragmentName</styleUrl></Pair></StyleMap>")]
        [InlineData("https://user:password@www.contoso.com:80/Home/Index.htm?q1=v1&q2=v2#FragmentName", StyleStateEnum.Highlight, false, "<StyleMap><Pair><key>highlight</key><styleUrl>https://user:password@www.contoso.com:80/Home/Index.htm?q1=v1&q2=v2#FragmentName</styleUrl></Pair></StyleMap>")]
        [InlineData("https://user:password@www.contoso.com:80/Home/Index.htm?q1=v1&q2=v2#FragmentName", StyleStateEnum.Highlight, true, "<StyleMap><Pair><key>highlight</key><styleUrl>#FragmentName</styleUrl></Pair></StyleMap>")]
        public void StyleMap_CorrectlyConvertsToKML(string href, StyleStateEnum styleState, bool styleLocal, string expected)
        {
            var uri = new Uri(href);
            var styleUrl = new StyleUrl(uri, styleLocal);
            var sut = new StyleMap(styleUrl, styleState);

            var result = sut.ConvertObjectToKML();

            Assert.Equal(expected, result);
        }
    }
}
