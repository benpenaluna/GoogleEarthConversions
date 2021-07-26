using GoogleEarthConversions.Core.KML.StyleSelector;
using GoogleEarthConversions.Core.KML.StyleSelector.Attributes;
using System;
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
        [InlineData("https://user:password@www.contoso.com:80/Home/Index.htm?q1=v1&q2=v2#FragmentName", "file://C://Test.kml#sn_ylw-pushpin")]
        public void StyleMap_CanInstantiateWithTwoPairs(string url1, string url2)
        {
            var styleUr1l = new StyleUrl(new Uri(url1));
            var pair1 = new Pair(styleUr1l);

            var styleUr12 = new StyleUrl(new Uri(url2));
            var pair2 = new Pair(styleUr12);

            var sut = new StyleMap(pair1, pair2);

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
        [InlineData("https://user:password@www.contoso.com:80/Home/Index.htm?q1=v1&q2=v2#FragmentName", "file://C://Test.kml#sn_ylw-pushpin")]
        public void StyleMap_AllPropertiesInitialisedWithTwoPairs(string url1, string url2)
        {
            var styleUr1l = new StyleUrl(new Uri(url1));
            var pair1 = new Pair(styleUr1l);

            var styleUr12 = new StyleUrl(new Uri(url2));
            var pair2 = new Pair(styleUr12);

            var sut = new StyleMap(pair1, pair2);

            foreach (var prop in sut.GetType().GetProperties())
            {
                var value = prop.GetValue(sut);
                Assert.NotNull(value);
            }
        }

        [Theory]
        [InlineData("https://user:password@www.contoso.com:80/Home/Index.htm?q1=v1&q2=v2#FragmentName", null, StyleStateEnum.Normal, false, "<StyleMap><Pair><key>normal</key><styleUrl>https://user:password@www.contoso.com:80/Home/Index.htm?q1=v1&q2=v2#FragmentName</styleUrl></Pair></StyleMap>")]
        [InlineData("https://user:password@www.contoso.com:80/Home/Index.htm?q1=v1&q2=v2#FragmentName", null, StyleStateEnum.Normal, true, "<StyleMap><Pair><key>normal</key><styleUrl>#FragmentName</styleUrl></Pair></StyleMap>")]
        [InlineData("https://user:password@www.contoso.com:80/Home/Index.htm?q1=v1&q2=v2#FragmentName", null, StyleStateEnum.Highlight, false, "<StyleMap><Pair><key>highlight</key><styleUrl>https://user:password@www.contoso.com:80/Home/Index.htm?q1=v1&q2=v2#FragmentName</styleUrl></Pair></StyleMap>")]
        [InlineData("https://user:password@www.contoso.com:80/Home/Index.htm?q1=v1&q2=v2#FragmentName", null, StyleStateEnum.Highlight, true, "<StyleMap><Pair><key>highlight</key><styleUrl>#FragmentName</styleUrl></Pair></StyleMap>")]
        [InlineData("https://user:password@www.contoso.com:80/Home/Index.htm?q1=v1&q2=v2#FragmentName", "file://C://Test.kml#sn_ylw-pushpin", StyleStateEnum.Normal, true, "<StyleMap><Pair><key>normal</key><styleUrl>#FragmentName</styleUrl></Pair><Pair><key>highlight</key><styleUrl>#sn_ylw-pushpin</styleUrl></Pair></StyleMap>")]
        public void StyleMap_CorrectlyConvertsToKML(string href1, string href2, StyleStateEnum styleState, bool styleLocal, string expected)
        {
            IStyleMap sut;

            var styleUrl1 = new StyleUrl(new Uri(href1), styleLocal);
            var pair1 = new Pair(styleUrl1, styleState);

            if (href2 == null)
            {
                sut = new StyleMap(pair1);
            }
            else
            {
                var styleUrl2 = new StyleUrl(new Uri(href2), styleLocal);
                var pair2 = new Pair(styleUrl2, StyleStateEnum.Highlight);

                sut = new StyleMap(pair1, pair2);
            }

            var result = sut.SerialiseToKML();

            Assert.Equal(expected, result);
        }
    }
}
