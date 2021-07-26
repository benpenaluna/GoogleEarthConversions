using GoogleEarthConversions.Core.KML.Object.Attributes;
using Xunit;

namespace GoogleEarthConventions.Tests.KML.Object.Attributes
{
    public class RefreshModeTests
    {
        [Fact]
        public void RefreshMode_CanInstantiate()
        {
            var sut = new RefreshMode();

            Assert.NotNull(sut);
        }

        [Fact]
        public void RefreshMode_AllPropertiesInitialised()
        {
            var sut = new RefreshMode();

            foreach (var prop in sut.GetType().GetProperties())
            {
                var value = prop.GetValue(sut);
                Assert.NotNull(value);
            }
        }

        [Fact]
        public void RefreshMode_InstantiatesWithEnum()
        {
            var sut = new RefreshMode(RefreshModeEnum.OnInterval);

            Assert.NotNull(sut);
        }

        [Fact]
        public void RefreshMode_AllPropertiesInitialisedWithEnum()
        {
            var sut = new RefreshMode(RefreshModeEnum.OnInterval);

            foreach (var prop in sut.GetType().GetProperties())
            {
                var value = prop.GetValue(sut);
                Assert.NotNull(value);
            }
        }

        [Theory]
        [InlineData(RefreshModeEnum.OnChange, "")]
        [InlineData(RefreshModeEnum.OnExpire, "<refreshMode>onExpire</refreshMode>")]
        [InlineData(RefreshModeEnum.OnInterval, "<refreshMode>onInterval</refreshMode>")]
        public void RefreshMode_CorrectlyConvertsToKML(RefreshModeEnum refreshMode, string expected)
        {
            var sut = new RefreshMode(refreshMode);

            var result = sut.SerialiseToKML();

            Assert.Equal(expected, result);
        }
    }
}
