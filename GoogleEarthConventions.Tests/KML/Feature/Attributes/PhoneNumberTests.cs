using GoogleEarthConversions.Core.KML.Feature.Attributes;
using Xunit;

namespace GoogleEarthConventions.Tests.KML.Feature.Attributes
{
    public class PhoneNumberTests
    {
        [Fact]
        public void PhoneNumber_CanInstantiate()
        {
            var sut = new PhoneNumber();

            Assert.NotNull(sut);
        }

        [Fact]
        public void PhoneNumber_AllPropertiesInitialised()
        {
            var sut = new PhoneNumber();

            foreach (var prop in sut.GetType().GetProperties())
            {
                var value = prop.GetValue(sut);
                Assert.NotNull(value);
            }
        }

        [Fact]
        public void PhoneNumber_AllPropertiesInitialisedWithLabel()
        {
            var number = "1234567890";
            var expected = number;

            var sut = new PhoneNumber(number);
            var result = sut.Number;

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("", "")]
        [InlineData("1234567890", "<phoneNumber>1234567890</phoneNumber>")]
        public void PhoneNumber_CorrectlyConvertsToKML(string number, string expected)
        {
            var sut = new PhoneNumber(number);

            var result = sut.SerialiseToKML();

            Assert.Equal(expected, result);
        }
    }
}
