using GoogleEarthConversions.Core.Common;
using Xunit;

namespace GoogleEarthConventions.Tests.Common
{
    public class AltitudeModeTests
    {
        [Fact]
        public void AltitudeMode_CanInstantiate()
        {
            var sut = new AltitudeMode();

            Assert.NotNull(sut);
        }

        [Fact]
        public void AltitudeMode_AllPropertiesInitialised()
        {
            var sut = new AltitudeMode();

            foreach (var prop in sut.GetType().GetProperties())
            {
                var value = prop.GetValue(sut);
                Assert.NotNull(value);
            }
        }

        [Theory]
        [InlineData(AltMode.ClampToGround, "")]
        [InlineData(AltMode.RelativeToGround, "<altitudeMode>relativeToGround</altitudeMode>")]
        [InlineData(AltMode.Absolute, "<altitudeMode>absolute</altitudeMode>")]
        [InlineData(AltMode.ClampToSeaFloor, "<gx:altitudeMode>clampToSeaFloor</gx:altitudeMode>")]
        [InlineData(AltMode.RelativeToSeaFloor, "<gx:altitudeMode>relativeToSeaFloor</gx:altitudeMode>")]
        public void AltitudeMode_CorrectlyConvertsToKML(AltMode value, string expected)
        {
            var sut = new AltitudeMode(value);

            var result = sut.ConvertObjectToKML();

            Assert.Equal(expected, result);
        }
    }
}
