using GoogleEarthConversions.Core.Common;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GoogleEarthConventions.Tests.Common
{
    public class GenericKMLTests
    {
        [Fact]
        public void GenericKML_CanInstantiateWithNullableType()
        {
            var sut = new GenericKML<string>("test", string.Empty, string.Empty);

            Assert.NotNull(sut);
        }

        [Fact]
        public void GenericKML_AllPropertiesInitialisedWithNullableType()
        {
            var sut = new GenericKML<string>("test", string.Empty, string.Empty);

            foreach (var prop in sut.GetType().GetProperties())
            {
                var value = prop.GetValue(sut);
                Assert.NotNull(value);
            }
        }

        [Fact]
        public void GenericKML_CanInstantiateWithNonNullableType()
        {
            var sut = new GenericKML<double>("test", 0, 0);

            Assert.NotNull(sut);
        }

        [Fact]
        public void GenericKML_AllPropertiesInitialisedWithNonNullableType()
        {
            var sut = new GenericKML<double>("test", 0, 0);

            foreach (var prop in sut.GetType().GetProperties())
            {
                var value = prop.GetValue(sut);
                Assert.NotNull(value);
            }
        }


        [Theory]
        [InlineData("tag", "", "", "")]
        [InlineData("tag", "test", "test", "")]
        [InlineData("tag", "tag", "test", "<tag>tag</tag>")]
        public void GenericKML_CorrectlyConvertsToKMLNullableType(string tag, string value, string def, string expected)
        {
            var sut = new GenericKML<string>(tag, value, def);

            var result = sut.SerialiseToKML();

            Assert.Equal(expected, result);
        }
    }
}
