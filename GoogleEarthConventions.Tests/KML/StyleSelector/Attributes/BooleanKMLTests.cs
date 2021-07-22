using GoogleEarthConversions.Core.KML.StyleSelector.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GoogleEarthConventions.Tests.KML.StyleSelector.Attributes
{
    public class BooleanKMLTests
    {
        [Fact]
        public void BooleanKML_CanInstantiate()
        {
            var sut = new BooleanKML(nameof(BooleanKML));

            Assert.NotNull(sut);
        }

        [Fact]
        public void BooleanKML_AllPropertiesInitialised()
        {
            var sut = new BooleanKML(nameof(BooleanKML));

            foreach (var prop in sut.GetType().GetProperties())
            {
                var value = prop.GetValue(sut);
                Assert.NotNull(value);
            }
        }

        [Theory]
        [InlineData("gx:labelVisibility", false, false, "")]
        [InlineData("gx:labelVisibility", true, false, "<gx:labelVisibility>1</gx:labelVisibility>")]
        public void BooleanKML_CorrectlyConvertsToKML(string kmlTagName, bool value, bool def, string expected)
        {
            var sut = new BooleanKML(kmlTagName) { Value = value, Default = def };

            var result = sut.SerialiseToKML();

            Assert.Equal(expected, result);
        }
    }
}
