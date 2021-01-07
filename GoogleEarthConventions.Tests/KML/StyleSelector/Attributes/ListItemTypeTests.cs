using GoogleEarthConversions.Core.KML.StyleSelector.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GoogleEarthConventions.Tests.KML.StyleSelector.Attributes
{
    public class ListItemTypeTests
    {
        [Fact]
        public void ListItemType_CanInstantiate()
        {
            var sut = new ListItemType();

            Assert.NotNull(sut);
        }

        [Fact]
        public void ListItemType_AllPropertiesInitialised()
        {
            var sut = new ListItemType();

            foreach (var prop in sut.GetType().GetProperties())
            {
                var value = prop.GetValue(sut);
                Assert.NotNull(value);
            }
        }

        [Fact]
        public void ListItemType_ItemTypeDefaultsToCheck()
        {
            var expected = ListItemTypeEnum.Check;
            
            var sut = new ListItemType();
            var result = sut.ItemType;

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(ListItemTypeEnum.Check, "")]
        [InlineData(ListItemTypeEnum.CheckOffOnly, "<listItemType>checkOffOnly</listItemType>")]
        [InlineData(ListItemTypeEnum.CheckHideChildren, "<listItemType>checkHideChildren</listItemType>")]
        [InlineData(ListItemTypeEnum.RadioFolder, "<listItemType>radioFolder</listItemType>")]
        public void LatLonAltBox_CorrectlyConvertsToKML(ListItemTypeEnum itemType, string expected)
        {
            var sut = new ListItemType(itemType);

            var result = sut.ConvertObjectToKML();

            Assert.Equal(expected, result);
        }
    }
}
