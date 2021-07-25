using GoogleEarthConversions.Core.Common;
using GoogleEarthConversions.Core.KML.Object;
using GoogleEarthConversions.Core.KML.Object.Attributes;
using Xunit;

namespace GoogleEarthConventions.Tests.KML.Object.Attributes
{
    public class LinkTests
    {
        [Fact]
        public void Link_CanInstantiate()
        {
            var sut = new Link();

            Assert.NotNull(sut);
        }

        [Fact]
        public void Link_AllPropertiesInitialised()
        {
            var sut = new Link();

            foreach (var prop in sut.GetType().GetProperties())
            {
                var value = prop.GetValue(sut);
                Assert.NotNull(value);
            }
        }

        [Theory]
        [InlineData("", RefreshModeEnum.OnChange, 0.0, ViewRefreshModeEnum.Never, 0.0, 1.0, 115.0, -45.0, 163.0, -2.0, "")]
        [InlineData("file://C://Test.kml", RefreshModeEnum.OnChange, 0.0, ViewRefreshModeEnum.Never, 0.0, 1.0, 115.0, -45.0, 163.0, -2.0, "<Link><href>file://C://Test.kml</href></Link>")]
        [InlineData("http://www.example.com/geotiff/NE/MergedReflectivityQComposite.kml", RefreshModeEnum.OnChange, 0.0, ViewRefreshModeEnum.Never, 0.0, 1.0, 0, 0, 0, 0, "<Link><href>http://www.example.com/geotiff/NE/MergedReflectivityQComposite.kml</href><viewFormat>BBOX=0,0,0,0</viewFormat></Link>")]
        [InlineData("http://www.example.com/geotiff/NE/MergedReflectivityQComposite.kml", RefreshModeEnum.OnChange, 0.0, ViewRefreshModeEnum.Never, 0.0, 1.0, 115.0, -45.0, 163.0, -2.0, "<Link><href>http://www.example.com/geotiff/NE/MergedReflectivityQComposite.kml</href><viewFormat>BBOX=115,-45,163,-2</viewFormat></Link>")]
        [InlineData("http://www.example.com/geotiff/NE/MergedReflectivityQComposite.kml", RefreshModeEnum.OnInterval, 300.0, ViewRefreshModeEnum.OnStop, 7.0, 0.8, 115.0, -45.0, 163.0, -2.0, "<Link><href>http://www.example.com/geotiff/NE/MergedReflectivityQComposite.kml</href><refreshMode>onInterval</refreshMode><refreshInterval>300</refreshInterval><viewRefreshMode>onStop</viewRefreshMode><viewRefreshTime>7</viewRefreshTime><viewBoundScale>0.8</viewBoundScale><viewFormat>BBOX=115,-45,163,-2</viewFormat></Link>")]
        public void Link_CorrectlyConvertsToKML(string href, RefreshModeEnum refreshMode, double refreshInterval, ViewRefreshModeEnum viewRefreshMode,
                                                double viewRefreshTime, double viewBoundScale, double west, double south, double east, double north, string expected)
        {
            var sut = new Link()
            {
                Href = new Href(href),
                RefreshMode = new RefreshMode(refreshMode),
                ViewRefreshMode = new ViewRefreshMode(viewRefreshMode)
            };
            sut.RefreshInterval.Value = refreshInterval;
            sut.ViewRefreshTime.Value = viewRefreshTime;
            sut.ViewBoundScale.Value = viewBoundScale;
            sut.ViewFormat.BoundingBox.SetWestAngle(west);
            sut.ViewFormat.BoundingBox.SetSouthAngle(south);
            sut.ViewFormat.BoundingBox.SetEastAngle(east);
            sut.ViewFormat.BoundingBox.SetNorthAngle(north);

            var result = sut.SerialiseToKML();

            Assert.Equal(expected, result);
        }
    }
}
