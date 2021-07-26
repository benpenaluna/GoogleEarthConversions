using GoogleEarthConversions.Core.Common;
using Xunit;

namespace GoogleEarthConventions.Tests.KML.StyleSelector.Attributes
{
    public class DoubleKMLTests
    {
        [Fact]
        public void DoubleKML_CanInstantiate()
        {
            var sut = new DoubleKML(nameof(DoubleKML));

            Assert.NotNull(sut);
        }

        [Fact]
        public void DoubleKML_AllPropertiesInitialised()
        {
            var sut = new DoubleKML(nameof(DoubleKML));

            foreach (var prop in sut.GetType().GetProperties())
            {
                var value = prop.GetValue(sut);
                Assert.NotNull(value);
            }
        }

        [Theory]
        [InlineData("outerWidth", 0, 0, "")]
        [InlineData("width", 1, 0, "<width>1</width>")]
        [InlineData("gx:outerWidth", 1, 0, "<gx:outerWidth>1</gx:outerWidth>")]
        [InlineData("gx:physicalWidth", 1.2, 0, "<gx:physicalWidth>1.2</gx:physicalWidth>")]
        public void DoubleKML_CorrectlyConvertsToKML(string kmlTagName, double value, double def, string expected)
        {
            var sut = new DoubleKML(kmlTagName) { Value = value, Default = def };

            var result = sut.SerialiseToKML();

            Assert.Equal(expected, result);
        }
    }
}
