using GoogleEarthConversions.Core.KML.Geometry.Attributes;
using Xunit;

namespace GoogleEarthConventions.Tests.KML.Geometry.Attributes
{
    public class DrawOrderTests
    {
        [Fact]
        public void DrawOrder_CanInstantiate()
        {
            var sut = new DrawOrder();

            Assert.NotNull(sut);
        }

        [Fact]
        public void DrawOrder_AllPropertiesInitialised()
        {
            var sut = new DrawOrder();

            foreach (var prop in sut.GetType().GetProperties())
            {
                var value = prop.GetValue(sut);
                Assert.NotNull(value);
            }
        }

        [Theory]
        [InlineData(0, "")]
        [InlineData(1, "<gx:drawOrder>1</gx:drawOrder>")]
        public void DrawOrder_CorrectlyConvertsToKML(int value, string expected)
        {
            var sut = new DrawOrder(value);

            var result = sut.ConvertObjectToKML();

            Assert.Equal(expected, result);
        }
    }
}
