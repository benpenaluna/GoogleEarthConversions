using GoogleEarthConversions.Core.KML.Feature.Attributes;
using Xunit;

namespace GoogleEarthConventions.Tests.KML.Feature.Attributes
{
    public class NameTests
    {
        [Fact]
        public void Name_CanInstantiate()
        {
            var sut = new Name();

            Assert.NotNull(sut);
        }

        [Fact]
        public void Name_AllPropertiesInitialised()
        {
            var sut = new Name();

            foreach (var prop in sut.GetType().GetProperties())
            {
                var value = prop.GetValue(sut);
                Assert.NotNull(value);
            }
        }

        [Fact]
        public void Extrude_AllPropertiesInitialisedWithLabel()
        {
            var label = "Test";
            var expected = label;

            var sut = new Name(label);
            var result = sut.Label;

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("", "")]
        [InlineData("Test", "<name>Test</name>")]
        public void Extrude_CorrectlyConvertsToKML(string label, string expected)
        {
            var sut = new Name(label);

            var result = sut.SerialiseToKML();

            Assert.Equal(expected, result);
        }
    }
}
