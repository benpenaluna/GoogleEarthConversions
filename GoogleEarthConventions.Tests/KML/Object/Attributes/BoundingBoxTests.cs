using GeoFunctions.Core.Coordinates.Measurement;
using GoogleEarthConversions.Core.KML.Object.Attributes;
using System;
using Xunit;

namespace GoogleEarthConventions.Tests.KML.Object.Attributes
{
    public class BoundingBoxTests
    {
        [Fact]
        public void BoundingBox_CanInstantiate()
        {
            var sut = new BoundingBox();

            Assert.NotNull(sut);
        }

        [Fact]
        public void BoundingBox_AllPropertiesInitialised()
        {
            var sut = new BoundingBox();

            foreach (var prop in sut.GetType().GetProperties())
            {
                var value = prop.GetValue(sut);
                Assert.NotNull(value);
            }
        }

        [Theory]
        [InlineData(45.7768, AngleMeasurement.Degrees)]
        public void BoundingBox_CanUpdateNorth(double angle, AngleMeasurement measurement)
        {
            var expected = new GoogleEarthConversions.Core.Geographical.Latitude(angle, measurement);

            var sut = new BoundingBox();
            sut.SetNorthAngle(angle, measurement);
            var result = sut.North as GoogleEarthConversions.Core.Geographical.Latitude;

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(90.01, AngleMeasurement.Degrees)]
        public void BoundingBox_NorthException(double angle, AngleMeasurement measurement)
        {
            var sut = new BoundingBox();

            Assert.Throws<ArgumentOutOfRangeException>(() => sut.SetNorthAngle(angle, measurement));
        }

        [Theory]
        [InlineData(-45.7768, AngleMeasurement.Degrees)]
        public void BoundingBox_CanUpdateSouth(double angle, AngleMeasurement measurement)
        {
            var expected = new GoogleEarthConversions.Core.Geographical.Latitude(angle, measurement);

            var sut = new BoundingBox();
            sut.SetSouthAngle(angle, measurement);
            var result = sut.South as GoogleEarthConversions.Core.Geographical.Latitude;

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(-90.01, AngleMeasurement.Degrees)]
        public void BoundingBox_SouthException(double angle, AngleMeasurement measurement)
        {
            var sut = new BoundingBox();

            Assert.Throws<ArgumentOutOfRangeException>(() => sut.SetSouthAngle(angle, measurement));
        }

        [Theory]
        [InlineData(163.0, AngleMeasurement.Degrees)]
        public void BoundingBox_CanUpdateEast(double angle, AngleMeasurement measurement)
        {
            var expected = new GoogleEarthConversions.Core.Geographical.Longitude(angle, measurement);

            var sut = new BoundingBox();
            sut.SetEastAngle(angle, measurement);
            var result = sut.East as GoogleEarthConversions.Core.Geographical.Longitude;

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(180.01, AngleMeasurement.Degrees)]
        public void BoundingBox_EastException(double angle, AngleMeasurement measurement)
        {
            var sut = new BoundingBox();

            Assert.Throws<ArgumentOutOfRangeException>(() => sut.SetEastAngle(angle, measurement));
        }

        [Theory]
        [InlineData(115.0, AngleMeasurement.Degrees)]
        public void BoundingBox_CanUpdateWest(double angle, AngleMeasurement measurement)
        {
            var expected = new GoogleEarthConversions.Core.Geographical.Longitude(angle, measurement);

            var sut = new BoundingBox();
            sut.SetWestAngle(angle, measurement);
            var result = sut.West as GoogleEarthConversions.Core.Geographical.Longitude;

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(-180.0, AngleMeasurement.Degrees)]
        public void BoundingBox_WestException(double angle, AngleMeasurement measurement)
        {
            var sut = new BoundingBox();

            Assert.Throws<ArgumentOutOfRangeException>(() => sut.SetWestAngle(angle, measurement));
        }
    }
}
