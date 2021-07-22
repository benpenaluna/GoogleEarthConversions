using GoogleEarthConversions.Core.KML.Geometry.Attributes;
using Xunit;

namespace GoogleEarthConventions.Tests.KML.Geometry.Attributes
{
    public class TessellateTests
    {
        [Fact]
        public void Tessellate_CanInstantiate()
        {
            var sut = new Tessellate();

            Assert.NotNull(sut);
        }

        [Fact]
        public void Tessellate_AllPropertiesInitialised()
        {
            var sut = new Tessellate();

            foreach (var prop in sut.GetType().GetProperties())
            {
                var value = prop.GetValue(sut);
                Assert.NotNull(value);
            }
        }

        [Theory]
        [InlineData(false, "")]
        [InlineData(true, "<tessellate>1</tessellate>")]
        public void Tessellate_CorrectlyConvertsToKML(bool value, string expected)
        {
            var sut = new Tessellate(value);

            var result = sut.SerialiseToKML();

            Assert.Equal(expected, result);
        }
    }
}
