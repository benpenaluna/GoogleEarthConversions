using GoogleEarthConversions.Core.KML.StyleSelector;
using GoogleEarthConversions.Core.KML.StyleSelector.Attributes;
using Xunit;

namespace GoogleEarthConventions.Tests.KML.StyleSelector
{
    public class StyleTests
    {
        [Fact]
        public void Style_CanInstantiate()
        {
            var sut = new Style();

            Assert.NotNull(sut);
        }

        [Fact]
        public void Style_AllPropertiesInitialised()
        {
            var sut = new Style();

            foreach (var prop in sut.GetType().GetProperties())
            {
                var value = prop.GetValue(sut);
                Assert.NotNull(value);
            }
        }

        [Theory]
        [InlineData("", false, false, false, false, false, false, "")]
        [InlineData("ID", false, false, false, false, false, false, "")]
        [InlineData("ID", true, false, false, false, false, false, "<Style id=\"ID\"><IconStyle><color>ff000000</color></IconStyle></Style>")]
        [InlineData("ID", false, true, false, false, false, false, "<Style id=\"ID\"><LabelStyle><scale>1.5</scale></LabelStyle></Style>")]
        [InlineData("", false, false, true, false, false, false, "<Style><LineStyle><color>ff000000</color></LineStyle></Style>")]
        [InlineData("", false, false, false, true, false, false, "<Style><PolyStyle><color>ff000000</color></PolyStyle></Style>")]
        [InlineData("", false, false, false, false, true, false, "<Style><BalloonStyle><bgColor>ff000000</bgColor><text>This is a test string</text></BalloonStyle></Style>")]
        [InlineData("", false, false, false, false, false, true, "<Style><ListStyle><listItemType>checkOffOnly</listItemType></ListStyle></Style>")]
        [InlineData("ID", true, true, false, false, false, false, "<Style id=\"ID\"><IconStyle><color>ff000000</color></IconStyle><LabelStyle><scale>1.5</scale></LabelStyle></Style>")]
        [InlineData("ID", true, true, true, false, false, false, "<Style id=\"ID\"><IconStyle><color>ff000000</color></IconStyle><LabelStyle><scale>1.5</scale></LabelStyle><LineStyle><color>ff000000</color></LineStyle></Style>")]
        [InlineData("ID", true, true, true, true, false, false, "<Style id=\"ID\"><IconStyle><color>ff000000</color></IconStyle><LabelStyle><scale>1.5</scale></LabelStyle><LineStyle><color>ff000000</color></LineStyle><PolyStyle><color>ff000000</color></PolyStyle></Style>")]
        [InlineData("ID", true, true, true, true, true, false, "<Style id=\"ID\"><IconStyle><color>ff000000</color></IconStyle><LabelStyle><scale>1.5</scale></LabelStyle><LineStyle><color>ff000000</color></LineStyle><PolyStyle><color>ff000000</color></PolyStyle><BalloonStyle><bgColor>ff000000</bgColor><text>This is a test string</text></BalloonStyle></Style>")]
        [InlineData("ID", true, true, true, true, true, true, "<Style id=\"ID\"><IconStyle><color>ff000000</color></IconStyle><LabelStyle><scale>1.5</scale></LabelStyle><LineStyle><color>ff000000</color></LineStyle><PolyStyle><color>ff000000</color></PolyStyle><BalloonStyle><bgColor>ff000000</bgColor><text>This is a test string</text></BalloonStyle><ListStyle><listItemType>checkOffOnly</listItemType></ListStyle></Style>")]
        public void Style_CorrectlyConvertsToKML(string id, bool includeIconStyle, bool includeLabelStyle, bool includeLineStyle,
                                                 bool includePolyStyle, bool includeBalloonStyle, bool includeListStyle, string expected)
        {
            var sut = new Style() { Id = id };

            if (includeIconStyle)
                sut.IconStyle = CreateTestIconStyle();

            if (includeLabelStyle)
                sut.LabelStyle = CreateTestLabelStyle();

            if (includeLineStyle)
                sut.LineStyle = CreateTestLineStyle();

            if (includePolyStyle)
                sut.PolyStyle = CreateTestPolyStyle();

            if (includeBalloonStyle)
                sut.BalloonStyle = CreateTestBalloonStyle();

            if (includeListStyle)
                sut.ListStyle = CreateTestListStyle();

            var result = sut.SerialiseToKML();

            Assert.Equal(expected, result);
        }

        private static IconStyle CreateTestIconStyle()
        {
            var iconStyle = new IconStyle();
            iconStyle.Color.Value = System.Drawing.Color.FromArgb(255, 0, 0, 0);

            return iconStyle;
        }

        private static LabelStyle CreateTestLabelStyle()
        {
            var labelStyle = new LabelStyle();
            labelStyle.Scale.Value = 1.5;

            return labelStyle;
        }

        private static LineStyle CreateTestLineStyle()
        {
            var lineStyle = new LineStyle();
            lineStyle.Color.Value = System.Drawing.Color.FromArgb(255, 0, 0, 0);

            return lineStyle;
        }

        private static PolyStyle CreateTestPolyStyle()
        {
            var polyStyle = new PolyStyle();
            polyStyle.Color.Value = System.Drawing.Color.FromArgb(255, 0, 0, 0);

            return polyStyle;
        }

        private static BalloonStyle CreateTestBalloonStyle()
        {
            var balloonStyle = new BalloonStyle();
            balloonStyle.BgColor.Value = System.Drawing.Color.FromArgb(255, 0, 0, 0);
            balloonStyle.Text.Value = "This is a test string";

            return balloonStyle;
        }

        private static ListStyle CreateTestListStyle()
        {
            var listStyle = new ListStyle();
            listStyle.ListItemType.ItemType = ListItemTypeEnum.CheckOffOnly;

            return listStyle;
        }
    }
}
