using GoogleEarthConversions.Core.KML.AbstractView.Attributes;
using Xunit;

namespace GoogleEarthConventions.Tests.KML.AbstractView.Attributes
{
    public class OptionTests
    {
        [Fact]
        public void Option_CanInstantiate()
        {
            var sut = new Option(OptionName.Streetview);

            Assert.NotNull(sut);
        }

        [Fact]
        public void Option_AllPropertiesInitialised()
        {
            var sut = new Option(OptionName.Streetview);

            foreach (var prop in sut.GetType().GetProperties())
            {
                var value = prop.GetValue(sut);
                Assert.NotNull(value);
            }
        }

        [Theory]
        [InlineData(OptionName.Historicalimagery, false, "<gx:option enabled=\"0\" name=\"historicalimagery\"></gx:option>")]
        [InlineData(OptionName.Sunlight, false, "<gx:option enabled=\"0\" name=\"sunlight\"></gx:option>")]
        [InlineData(OptionName.Streetview, true, "<gx:option name=\"streetview\"></gx:option>")]
        public void Visibility_CorrectlyConvertsToKML(OptionName name, bool enabled, string expected)
        {
            var sut = new Option(name, enabled);

            var result = sut.ConvertObjectToKML();

            Assert.Equal(expected, result);
        }
    }
}
