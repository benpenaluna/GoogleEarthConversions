using GoogleEarthConversions.Core.KML.Object.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GoogleEarthConventions.Tests.KML.Object.Attributes
{
    public class ViewRefreshModeTests
    {
        [Fact]
        public void ViewRefreshMode_CanInstantiate()
        {
            var sut = new ViewRefreshMode();

            Assert.NotNull(sut);
        }

        [Fact]
        public void ViewRefreshMode_AllPropertiesInitialised()
        {
            var sut = new ViewRefreshMode();

            foreach (var prop in sut.GetType().GetProperties())
            {
                var value = prop.GetValue(sut);
                Assert.NotNull(value);
            }
        }

        [Fact]
        public void ViewRefreshMode_InstantiatesWithEnum()
        {
            var sut = new ViewRefreshMode(ViewRefreshModeEnum.OnStop);

            Assert.NotNull(sut);
        }

        [Fact]
        public void ViewRefreshMode_AllPropertiesInitialisedWithEnum()
        {
            var sut = new ViewRefreshMode(ViewRefreshModeEnum.OnStop);

            foreach (var prop in sut.GetType().GetProperties())
            {
                var value = prop.GetValue(sut);
                Assert.NotNull(value);
            }
        }

        [Theory]
        [InlineData(ViewRefreshModeEnum.Never, "")]
        [InlineData(ViewRefreshModeEnum.OnRegion, "<viewRefreshMode>onRegion</viewRefreshMode>")]
        [InlineData(ViewRefreshModeEnum.OnRequest, "<viewRefreshMode>onRequest</viewRefreshMode>")]
        [InlineData(ViewRefreshModeEnum.OnStop, "<viewRefreshMode>onStop</viewRefreshMode>")]
        public void ViewRefreshMode_CorrectlyConvertsToKML(ViewRefreshModeEnum refreshMode, string expected)
        {
            var sut = new ViewRefreshMode(refreshMode);

            var result = sut.SerialiseToKML();

            Assert.Equal(expected, result);
        }
    }
}
