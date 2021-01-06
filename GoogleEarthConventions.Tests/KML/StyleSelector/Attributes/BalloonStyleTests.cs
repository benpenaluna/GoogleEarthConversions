using GoogleEarthConversions.Core.Common;
using GoogleEarthConversions.Core.KML.StyleSelector.Attributes;
using Xunit;

namespace GoogleEarthConventions.Tests.KML.StyleSelector.Attributes
{
    public class BalloonStyleTests
    {
        [Fact]
        public void BalloonStyle_CanInstantiate()
        {
            var sut = new BalloonStyle();

            Assert.NotNull(sut);
        }

        [Fact]
        public void BalloonStyle_AllPropertiesInitialised()
        {
            var sut = new BalloonStyle();

            foreach (var prop in sut.GetType().GetProperties())
            {
                var value = prop.GetValue(sut);
                Assert.NotNull(value);
            }
        }

        [Fact]
        public void BalloonStyle_BgColorDefaultsToOpaqueWhite()
        {
            var expected = "ffffffff";
            
            var sut = new BalloonStyle();
            var result = sut.BgColor.Value.ColorHexValue();

            Assert.Equal(expected, result);
        }

        [Fact]
        public void BalloonStyle_TextColorDefaultsToOpaqueBlack()
        {
            var expected = "ff000000";

            var sut = new BalloonStyle();
            var result = sut.TextColor.Value.ColorHexValue();

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(255, 255, 255, 255, 255, 0, 0, 0, "ID", "This is a test string", "<BalloonStyle id=\"ID\"><text>This is a test string</text><displayMode>default</displayMode></BalloonStyle>")]
        [InlineData(167, 178, 12, 205, 255, 0, 0, 0, "", "This is a test string", "<BalloonStyle><bgColor>a7b20ccd</bgColor><text>This is a test string</text><displayMode>default</displayMode></BalloonStyle>")]
        [InlineData(255, 255, 255, 255, 167, 178, 12, 205, "ID", "This is a test string", "<BalloonStyle id=\"ID\"><textColor>a7b20ccd</textColor><text>This is a test string</text><displayMode>default</displayMode></BalloonStyle>")]
        [InlineData(167, 178, 12, 205, 255, 240, 248, 255, "", "This is a test string", "<BalloonStyle><bgColor>a7b20ccd</bgColor><textColor>fff0f8ff</textColor><text>This is a test string</text><displayMode>default</displayMode></BalloonStyle>")]
        public void BalloonStyle_CorrectlyConvertsToKML(int bgColorAlpha, int bgColorRed, int bgColorGreen, int bgColorBlue,
                                                        int textColorAlpha, int textColorRed, int textColorGreen, int textColorBlue,
                                                        string id, string text, string expected)
        {
            var sut = new BalloonStyle() { Id = id, Text = new Text(text) };
            sut.BgColor.Value = System.Drawing.Color.FromArgb(bgColorAlpha, bgColorRed, bgColorGreen, bgColorBlue);
            sut.TextColor.Value = System.Drawing.Color.FromArgb(textColorAlpha, textColorRed, textColorGreen, textColorBlue);

            var result = sut.ConvertObjectToKML();

            Assert.Equal(expected, result);
        }
    }
}
