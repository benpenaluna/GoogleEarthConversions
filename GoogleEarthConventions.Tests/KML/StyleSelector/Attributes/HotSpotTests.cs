using GoogleEarthConversions.Core.KML.StyleSelector.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GoogleEarthConventions.Tests.KML.StyleSelector.Attributes
{
    public class HotSpotTests
    {
        [Fact]
        public void HotSpot_CanInstantiate()
        {
            var sut = new HotSpot();

            Assert.NotNull(sut);
        }

        [Fact]
        public void HotSpot_AllPropertiesInitialised()
        {
            var sut = new HotSpot();

            foreach (var prop in sut.GetType().GetProperties())
            {
                var value = prop.GetValue(sut);
                Assert.NotNull(value);
            }
        }

        [Theory]
        [InlineData(0.5, 0.5, UnitsEnum.Fraction, UnitsEnum.Fraction, "")]
        [InlineData(0.4, 0.5, UnitsEnum.Fraction, UnitsEnum.Fraction, "<hotSpot x=\"0.4\" y=\"0.5\" xunits=\"fraction\" yunits=\"fraction\"/>")]
        [InlineData(0.5, 0.5, UnitsEnum.Pixels, UnitsEnum.Pixels, "<hotSpot x=\"0.5\" y=\"0.5\" xunits=\"pixels\" yunits=\"pixels\"/>")]
        [InlineData(10.0, 10.0, UnitsEnum.Pixels, UnitsEnum.Pixels, "<hotSpot x=\"10\" y=\"10\" xunits=\"pixels\" yunits=\"pixels\"/>")]
        public void HotSpot_CorrectlyConvertsToKML(double x, double y, UnitsEnum xunits, UnitsEnum yunits, string expected)
        {
            var sut = new HotSpot() 
            { 
                X = x,
                Y = y,
                Xunits = xunits,
                Yunits = yunits
            };

            var result = sut.SerialiseToKML();

            Assert.Equal(expected, result);
        }
    }
}
