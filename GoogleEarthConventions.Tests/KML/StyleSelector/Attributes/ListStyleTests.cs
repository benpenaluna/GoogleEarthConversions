using GoogleEarthConversions.Core.KML.StyleSelector.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GoogleEarthConventions.Tests.KML.StyleSelector.Attributes
{
    public class ListStyleTests
    {
        [Fact]
        public void ListStyle_CanInstantiate()
        {
            var sut = new ListStyle();

            Assert.NotNull(sut);
        }

        [Fact]
        public void ListStyle_AllPropertiesInitialised()
        {
            var sut = new ListStyle();

            foreach (var prop in sut.GetType().GetProperties())
            {
                var value = prop.GetValue(sut);
                Assert.NotNull(value);
            }
        }

        [Fact]
        public void ListStyle_InstantiatesWithValidUri()
        {
            var sut = new ListStyle();

            Assert.NotNull(sut);
        }

        [Theory]
        [InlineData("", ListItemTypeEnum.Check, 255, 255, 255, 255, ItemStateModeEnum.Open, ItemIconModeEnum.Nil, "", "<ListStyle><ItemIcon><state>open</state></ItemIcon></ListStyle>")]
        [InlineData("ID", ListItemTypeEnum.CheckOffOnly, 255, 255, 255, 255, ItemStateModeEnum.Open, ItemIconModeEnum.Nil, "", "<ListStyle id=\"ID\"><listItemType>checkOffOnly</listItemType><ItemIcon><state>open</state></ItemIcon></ListStyle>")]
        [InlineData("ID", ListItemTypeEnum.CheckOffOnly, 255, 0, 0, 0, ItemStateModeEnum.Open, ItemIconModeEnum.Nil, "", "<ListStyle id=\"ID\"><listItemType>checkOffOnly</listItemType><bgColor>ff000000</bgColor><ItemIcon><state>open</state></ItemIcon></ListStyle>")]
        [InlineData("ID", ListItemTypeEnum.CheckOffOnly, 255, 0, 0, 0, ItemStateModeEnum.Closed, ItemIconModeEnum.Fetching0, "", "<ListStyle id=\"ID\"><listItemType>checkOffOnly</listItemType><bgColor>ff000000</bgColor><ItemIcon><state>closed fetching0</state></ItemIcon></ListStyle>")]
        [InlineData("ID", ListItemTypeEnum.CheckOffOnly, 255, 0, 0, 0, ItemStateModeEnum.Closed, ItemIconModeEnum.Fetching0, "http://www.harrypotter.com", "<ListStyle id=\"ID\"><listItemType>checkOffOnly</listItemType><bgColor>ff000000</bgColor><ItemIcon><state>closed fetching0</state><href>http://www.harrypotter.com</href></ItemIcon></ListStyle>")]
        public void ListStyle_CorrectlyConvertsToKML(string id, ListItemTypeEnum itemType,
                                                     int valueAlpha, int valueRed, int valueGreen, int valueBlue, 
                                                     ItemStateModeEnum stateMode, ItemIconModeEnum iconMode, string uri, 
                                                     string expected)
        {
            var sut = new ListStyle()
            {
                Id = id,
                ListItemType = new ListItemType(itemType),
                ItemIcon = new ItemIcon() { State = new State(stateMode, iconMode), Href = uri }
            };
            sut.BgColor.Value = System.Drawing.Color.FromArgb(valueAlpha, valueRed, valueGreen, valueBlue);

            var result = sut.ConvertObjectToKML();

            Assert.Equal(expected, result);
        }
    }
}
