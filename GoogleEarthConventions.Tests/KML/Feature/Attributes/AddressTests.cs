using GoogleEarthConversions.Core.KML.Feature.Attributes;
using Xunit;

namespace GoogleEarthConventions.Tests.KML.Feature.Attributes
{
    public class AddressTests
    {
        [Fact]
        public void Address_CanInstantiate()
        {
            var sut = new Address();

            Assert.NotNull(sut);
        }

        [Fact]
        public void Address_AllPropertiesInitialised()
        {
            var sut = new Address();

            foreach (var prop in sut.GetType().GetProperties())
            {
                var value = prop.GetValue(sut);
                Assert.NotNull(value);
            }
        }

        [Fact]
        public void Address_AllPropertiesInitialisedWithLabel()
        {
            var address = "Test";
            var expected = address;

            var sut = new Address(address);
            var result = sut.UnstructuredAddress;

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("", "")]
        [InlineData("Test", "<address>Test</address>")]
        public void Address_CorrectlyConvertsToKML(string address, string expected)
        {
            var sut = new Address(address);

            var result = sut.SerialiseToKML();

            Assert.Equal(expected, result);
        }
    }
}
