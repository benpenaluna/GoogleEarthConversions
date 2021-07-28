using GoogleEarthConversions.Core.Common;
using Xunit;

namespace GoogleEarthConventions.Tests.KML.StyleSelector.Attributes
{
    public class BooleanKMLTests
    {
        [Fact]
        public void BooleanKML_CanInstantiate()
        {
            var sut = new BooleanKML(nameof(BooleanKML), value: false, def: false);

            Assert.NotNull(sut);
        }

        [Fact]
        public void BooleanKML_AllPropertiesInitialised()
        {
            var sut = new BooleanKML(nameof(BooleanKML), value: false, def: false);

            foreach (var prop in sut.GetType().GetProperties())
            {
                var value = prop.GetValue(sut);
                Assert.NotNull(value);
            }
        }

        [Theory]
        [InlineData("gx:labelVisibility", false, false, "")]
        [InlineData("gx:labelVisibility", true, false, "<gx:labelVisibility>1</gx:labelVisibility>")]
        public void BooleanKML_CorrectlyConvertsToKML(string kmlTagName, bool value, bool def, string expected)
        {
            var sut = new BooleanKML(kmlTagName, value, def);

            var result = sut.SerialiseToKML();

            Assert.Equal(expected, result);
        }
    }
}
