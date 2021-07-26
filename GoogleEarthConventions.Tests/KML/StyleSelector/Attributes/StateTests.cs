using GoogleEarthConversions.Core.KML.StyleSelector.Attributes;
using Xunit;

namespace GoogleEarthConventions.Tests.KML.StyleSelector.Attributes
{
    public class StateTests
    {
        [Fact]
        public void State_CanInstantiate()
        {
            var sut = new State();

            Assert.NotNull(sut);
        }

        [Fact]
        public void State_AllPropertiesInitialised()
        {
            var sut = new State();

            foreach (var prop in sut.GetType().GetProperties())
            {
                var value = prop.GetValue(sut);
                Assert.NotNull(value);
            }
        }

        [Fact]
        public void State_ItemStateModeDefaultsToOpen()
        {
            var expected = ItemStateModeEnum.Open;

            var sut = new State();
            var result = sut.ItemStateMode;

            Assert.Equal(expected, result);
        }

        [Fact]
        public void State_ItemIconModeDefaultsToNil()
        {
            var expected = ItemIconModeEnum.Nil;

            var sut = new State();
            var result = sut.ItemIconMode;

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(ItemStateModeEnum.Open, ItemIconModeEnum.Nil, "")]
        [InlineData(ItemStateModeEnum.Open, ItemIconModeEnum.Error, "<state>open error</state>")]
        [InlineData(ItemStateModeEnum.Open, ItemIconModeEnum.Fetching0, "<state>open fetching0</state>")]
        [InlineData(ItemStateModeEnum.Open, ItemIconModeEnum.Fetching1, "<state>open fetching1</state>")]
        [InlineData(ItemStateModeEnum.Open, ItemIconModeEnum.Fetching2, "<state>open fetching2</state>")]
        [InlineData(ItemStateModeEnum.Closed, ItemIconModeEnum.Nil, "<state>closed</state>")]
        [InlineData(ItemStateModeEnum.Closed, ItemIconModeEnum.Error, "<state>closed error</state>")]
        [InlineData(ItemStateModeEnum.Closed, ItemIconModeEnum.Fetching0, "<state>closed fetching0</state>")]
        [InlineData(ItemStateModeEnum.Closed, ItemIconModeEnum.Fetching1, "<state>closed fetching1</state>")]
        [InlineData(ItemStateModeEnum.Closed, ItemIconModeEnum.Fetching2, "<state>closed fetching2</state>")]
        public void State_CorrectlyConvertsToKML(ItemStateModeEnum stateMode, ItemIconModeEnum iconMode, string expected)
        {
            var sut = new State(stateMode, iconMode);

            var result = sut.SerialiseToKML();

            Assert.Equal(expected, result);
        }
    }
}
