using GoogleEarthConversions.Core.Common;
using Xunit;

namespace GoogleEarthConventions.Tests.Common
{
    public class StringFormattingTests
    {
        [Theory]
        [InlineData("","")]
        [InlineData("0","0")]
        [InlineData("A","a")]
        [InlineData("a","a")]
        [InlineData("Test", "test")]
        [InlineData("TEST", "tEST")]
        [InlineData("Test00", "test00")]
        [InlineData("0Test", "0Test")]
        [InlineData(":Test", ":Test")]
        public void StringFormatting_ConvertFirstCharacterToLowerCase(string testString, string expected)
        {
            var result = testString.ConvertFirstCharacterToLowerCase();

            Assert.Equal(expected, result);
        }
    }
}
