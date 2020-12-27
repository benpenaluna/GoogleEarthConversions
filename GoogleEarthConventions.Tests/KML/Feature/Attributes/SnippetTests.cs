using GoogleEarthConversions.Core.KML.Feature.Attributes;
using Xunit;

namespace GoogleEarthConventions.Tests.KML.Feature.Attributes
{
    public class SnippetTests
    {
        [Fact]
        public void Snippet_CanInstantiate()
        {
            var sut = new Snippet();

            Assert.NotNull(sut);
        }

        [Fact]
        public void Snippet_AllPropertiesInitialised()
        {
            var sut = new Snippet();

            foreach (var prop in sut.GetType().GetProperties())
            {
                var value = prop.GetValue(sut);
                Assert.NotNull(value);
            }
        }

        [Fact]
        public void Snippet_AllPropertiesInitialisedWithLabel()
        {
            var expectedShortDescription = "This is a short description of the Snippet.";
            var expectedMaxLines = 2;

            var result = new Snippet(expectedShortDescription);

            Assert.Equal(expectedShortDescription, result.ShortDescription);
            Assert.Equal(expectedMaxLines, result.MaxLines);
        }

        [Theory]
        [InlineData("", 2, "")]
        [InlineData("This is a short description of the Snippet.", 3, "<Snippet maxLines=\"3\">This is a short description of the Snippet.</Snippet>")]
        public void Snippet_CorrectlyConvertsToKML(string address, int maxLines, string expected)
        {
            var sut = new Snippet(address, maxLines);

            var result = sut.ConvertObjectToKML();

            Assert.Equal(expected, result);
        }
    }
}
