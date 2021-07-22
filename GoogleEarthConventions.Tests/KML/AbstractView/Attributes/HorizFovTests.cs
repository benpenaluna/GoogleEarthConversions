using GoogleEarthConversions.Core.KML.AbstractView.Attributes;
using Xunit;

namespace GoogleEarthConventions.Tests.KML.AbstractView.Attributes
{
    public class HorizFovTests
    {
        [Fact]
        public void HorizFov_CanInstantiate()
        {
            var sut = new HorizFov();

            Assert.NotNull(sut);
        }

        [Fact]
        public void HorizFov_AllPropertiesInitialised()
        {
            var sut = new HorizFov();

            foreach (var prop in sut.GetType().GetProperties())
            {
                var value = prop.GetValue(sut);
                Assert.NotNull(value);
            }
        }

        [Theory]
        [InlineData(0, "<gx:horizFov>0</gx:horizFov>")]
        [InlineData(60.0, "<gx:horizFov>60</gx:horizFov>")]
        [InlineData(59.99999999999999, "<gx:horizFov>59.99999999999999</gx:horizFov>")]
        public void HorizFov_CorrectlyConvertsToKML(double value, string expected)
        {
            var sut = new HorizFov(value);

            var result = sut.SerialiseToKML();

            Assert.Equal(expected, result);
        }
    }
}
