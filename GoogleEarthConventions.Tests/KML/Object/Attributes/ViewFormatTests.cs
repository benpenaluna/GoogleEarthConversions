using GoogleEarthConversions.Core.KML.Object.Attributes;
using Xunit;

namespace GoogleEarthConventions.Tests.KML.Object.Attributes
{
    public class ViewFormatTests
    {
        [Fact]
        public void ViewFormat_CanInstantiate()
        {
            var sut = new ViewFormat();

            Assert.NotNull(sut);
        }

        [Fact]
        public void VViewFormat_AllPropertiesInitialised()
        {
            var sut = new ViewFormat();

            foreach (var prop in sut.GetType().GetProperties())
            {
                var value = prop.GetValue(sut);
                Assert.NotNull(value);
            }
        }

        [Theory]
        [InlineData(-23.156, -51.178, 115.00181, 162.556, "<viewFormat>BBOX=162.556,-51.178,115.00181,-23.156</viewFormat>")]
        public void ViewRefreshMode_CorrectlyConvertsToKML(double north, double south, double east, double west, string expected)
        {
            var sut = new ViewFormat();
            sut.BoundingBox.SetNorthAngle(north);
            sut.BoundingBox.SetSouthAngle(south);
            sut.BoundingBox.SetEastAngle(east);
            sut.BoundingBox.SetWestAngle(west);

            var result = sut.SerialiseToKML();

            Assert.Equal(expected, result);
        }
    }
}
