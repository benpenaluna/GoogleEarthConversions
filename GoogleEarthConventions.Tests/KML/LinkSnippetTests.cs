using GoogleEarthConversions.Core.KML;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GoogleEarthConventions.Tests.KML
{
    public class LinkSnippetTests
    {
        [Fact]
        public void LinkSnippet_CanInstantiate()
        {
            var sut = new LinkSnippet(value: string.Empty);

            Assert.NotNull(sut);
        }

        [Fact]
        public void LinkSnippet_AllPropertiesInitialised()
        {
            var sut = new LinkSnippet(value: string.Empty);

            foreach (var prop in sut.GetType().GetProperties())
            {
                var value = prop.GetValue(sut);
                Assert.NotNull(value);
            }
        }

        [Fact]
        public void LinkSnippet_MaxLinesDefaultIsTwo()
        {
            int expected = 2;

            var sut = new LinkSnippet(value: string.Empty);
            var result = sut.MaxLines;

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(int.MinValue)]
        public void LinkSnippet_MaxLinesThrowExceptionWhenValueLessThanOne(int maxLines)
        {
            var sut = new LinkSnippet(value: string.Empty);

            Assert.Throws<ArgumentOutOfRangeException>(() => sut.MaxLines = maxLines);
        }

        [Theory]
        [InlineData("", 2, "")]
        [InlineData("Test string", 2, "<linkSnippet maxLines=\"2\">Test string</linkSnippet>")]
        public void Link_CorrectlyConvertsToKML(string value, int maxLines, string expected)
        {
            var sut = new LinkSnippet(value)
            {
                MaxLines = maxLines
            };

            var result = sut.SerialiseToKML();

            Assert.Equal(expected, result);
        }
    }
}
