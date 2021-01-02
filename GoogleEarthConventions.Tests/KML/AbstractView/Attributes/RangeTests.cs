using GeoFunctions.Core.Coordinates;
using GeoFunctions.Core.Coordinates.Measurement;
using GoogleEarthConversions.Core.KML.AbstractView.Attributes;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GoogleEarthConventions.Tests.KML.AbstractView.Attributes
{
    public class RangeTests
    {
        [Theory]
        [InlineData(0, DistanceMeasurement.Meters)]
        public void Range_CanInstantiateWithIDistance(double distance, DistanceMeasurement measurement)
        {
            IDistance range = new Distance(distance, measurement); 
            var sut = new Range(range);

            Assert.NotNull(sut);
        }

        [Theory]
        [InlineData(0, DistanceMeasurement.Meters)]
        public void Range_AllPropertiesInitialisedWithIDistance(double distance, DistanceMeasurement measurement)
        {
            IDistance range = new Distance(distance, measurement);
            var sut = new Range(range);

            foreach (var prop in sut.GetType().GetProperties())
            {
                var value = prop.GetValue(sut);
                Assert.NotNull(value);
            }
        }

        [Theory]
        [InlineData(0, DistanceMeasurement.Meters, "<range>0</range>")]
        [InlineData(90, DistanceMeasurement.Meters, "<range>90</range>")]
        [InlineData(9000, DistanceMeasurement.Centimeters, "<range>90</range>")]
        [InlineData(5280, DistanceMeasurement.Feet, "<range>1609.344</range>")]
        public void Range_CorrectlyConvertsToKML(double elevation, DistanceMeasurement measurement, string expected)
        {
            var sut = new Range(elevation, measurement);

            var result = sut.ConvertObjectToKML();

            Assert.Equal(expected, result);
        }
    }
}
