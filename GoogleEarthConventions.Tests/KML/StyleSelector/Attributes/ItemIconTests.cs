using GoogleEarthConversions.Core.KML.StyleSelector.Attributes;
using System;
using Xunit;

namespace GoogleEarthConventions.Tests.KML.StyleSelector.Attributes
{
    public class ItemIconTests
    {
        [Fact]
        public void ItemIcon_CanInstantiate()
        {
            var sut = new ItemIcon();

            Assert.NotNull(sut);
        }

        [Fact]
        public void ItemIcon_AllPropertiesInitialised()
        {
            var sut = new ItemIcon();

            foreach (var prop in sut.GetType().GetProperties())
            {
                var value = prop.GetValue(sut);
                Assert.NotNull(value);
            }
        }

        [Fact]
        public void ItemIcon_InstantiatesWithValidUri()
        {
            var validUri = "https://user:password@www.contoso.com:80/Home/Index.htm?q1=v1&q2=v2#FragmentName";
            var sut = new ItemIcon() { Href = validUri };

            Assert.NotNull(sut);
        }

        [Fact]
        public void ItemIcon_ExceptionOnInvalidUri()
        {
            var invalidUri = "Invalid URI";

            Assert.Throws<UriFormatException>(() => new ItemIcon() { Href = invalidUri });
        }

        [Theory]
        [InlineData(ItemStateModeEnum.Open, ItemIconModeEnum.Nil, "", "")]
        [InlineData(ItemStateModeEnum.Open, ItemIconModeEnum.Error, "", "<ItemIcon><state>open error</state></ItemIcon>")]
        [InlineData(ItemStateModeEnum.Open, ItemIconModeEnum.Nil, "http://www.harrypotter.com", "<ItemIcon><href>http://www.harrypotter.com</href></ItemIcon>")]
        [InlineData(ItemStateModeEnum.Closed, ItemIconModeEnum.Fetching0, "http://www.harrypotter.com", "<ItemIcon><state>closed fetching0</state><href>http://www.harrypotter.com</href></ItemIcon>")]
        public void ItemIcon_CorrectlyConvertsToKML(ItemStateModeEnum stateMode, ItemIconModeEnum iconMode, string uri, string expected)
        {
            var sut = new ItemIcon()
            {
                State = new State(stateMode, iconMode),
                Href = uri
            };

            var result = sut.SerialiseToKML();

            Assert.Equal(expected, result);
        }
    }
}
