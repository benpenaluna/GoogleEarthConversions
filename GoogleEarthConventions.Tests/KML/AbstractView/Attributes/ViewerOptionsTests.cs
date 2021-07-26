using GoogleEarthConversions.Core.KML.AbstractView.Attributes;
using Xunit;

namespace GoogleEarthConventions.Tests.KML.AbstractView.Attributes
{
    public class ViewerOptionsTests
    {
        [Fact]
        public void ViewerOptions_CanInstantiate()
        {
            var sut = new ViewerOptions();

            Assert.NotNull(sut);
        }

        [Fact]
        public void ViewerOptions_AllPropertiesInitialised()
        {
            var sut = new ViewerOptions();

            foreach (var prop in sut.GetType().GetProperties())
            {
                var value = prop.GetValue(sut);
                Assert.NotNull(value);
            }
        }

        [Fact]
        public void ViewerOptions_AllOptionsEnabledFalseByDefault()
        {
            var expected = false;

            var sut = new ViewerOptions();

            foreach (var prop in sut.GetType().GetProperties())
            {
                if (prop.PropertyType == typeof(bool))
                {
                    var result = (bool)prop.GetValue(sut);
                    Assert.True(expected.Equals(result));
                }
            }
        }

        [Fact]
        public void ViewerOptions_CanEnableHistoricalimagery()
        {
            var expected = true;

            var sut = new ViewerOptions
            {
                HistoricalimageryEnabled = true
            };

            var result = sut.HistoricalimageryEnabled;

            Assert.Equal(expected, result);
        }

        [Fact]
        public void ViewerOptions_CanEnableSunlight()
        {
            var expected = true;

            var sut = new ViewerOptions
            {
                SunlightEnabled = true
            };

            var result = sut.SunlightEnabled;

            Assert.Equal(expected, result);
        }

        [Fact]
        public void ViewerOptions_CanEnableStreetView()
        {
            var expected = true;

            var sut = new ViewerOptions
            {
                StreetviewEnabled = true
            };

            var result = sut.StreetviewEnabled;

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(false, false, true, "<gx:ViewerOptions><gx:option enabled=\"0\" name=\"historicalimagery\"></gx:option><gx:option enabled=\"0\" name=\"sunlight\">" +
                                        "</gx:option><gx:option name=\"streetview\"></gx:option></gx:ViewerOptions>")]
        [InlineData(true, true, true, "<gx:ViewerOptions><gx:option name=\"historicalimagery\"></gx:option><gx:option name=\"sunlight\">" +
                                      "</gx:option><gx:option name=\"streetview\"></gx:option></gx:ViewerOptions>")]
        public void ViewerOptions_CorrectlyConvertsToKML(bool historicalimageryEnabled, bool sunlightEnabled, bool streetviewEnabled, string expected)
        {
            var sut = new ViewerOptions(historicalimageryEnabled, sunlightEnabled, streetviewEnabled);

            var result = sut.SerialiseToKML();

            Assert.Equal(expected, result);
        }
    }
}
