using GoogleEarthConversions.Core.KML.Feature;
using GoogleEarthConversions.Core.KML.Feature.Attributes;
using GoogleEarthConversions.Core.KML.Geometry;
using GoogleEarthConversions.Core.KML.Geometry.Attributes;
using GoogleEarthConversions.Core.KML.StyleSelector.Attributes;
using System;
using Xunit;

namespace GoogleEarthConventions.Tests.KML.Feature
{
    public class FolderTests
    {
        [Fact]
        public void Folder_CanInstantiate()
        {
            var sut = new Folder();

            Assert.NotNull(sut);
        }

        [Fact]
        public void Folder_AllPropertiesInitialised()
        {
            var sut = new Folder();

            foreach (var prop in sut.GetType().GetProperties())
            {
                var value = prop.GetValue(sut);
                Assert.NotNull(value);
            }
        }

        [Theory]
        [InlineData("Test.kml", "Google Earth - New Placemark", "Some Descriptive text.", 48.25450093195546, -90.86948943473118, 0, "<Folder><name>Test.kml</name><open>1</open><Placemark><name>Google Earth - New Placemark</name><description>Some Descriptive text.</description><styleUrl>#msn_ylw-pushpin</styleUrl><Point><coordinates>-90.869489434731,48.2545009319555,0</coordinates></Point></Placemark></Folder>")]
        public void Folder_CorrectlyConvertsToKMLWithPoint(string docName, string nameLabel, string description, double lat, double lon, double elev, string expected)
        {
            Placemark placemark = GeneratePlaceMark(nameLabel, description, lat, lon, elev);

            var sut = new Folder()
            {
                Name = new Name(docName),
                Open = new Open(FolderAppearance.Expanded)
            };
            sut.Features.Add(placemark);

            var result = sut.SerialiseToKML();

            Assert.Equal(expected, result);
        }

        private static Placemark GeneratePlaceMark(string nameLabel, string description, double lat, double lon, double elev)
        {
            var placemark = new Placemark()
            {
                Name = new Name(nameLabel),
                Description = new Description(description)
            };
            placemark.SetStyleUrl(new StyleUrl(new Uri("file://C://Test.kml#msn_ylw-pushpin"), styleLocal: true));

            if (lat != double.MaxValue || lon != double.MaxValue || elev != double.MaxValue)
            {
                ICoordinates coordinate = new Coordinates(lat, lon, elev);
                placemark.Geometry = new Point(coordinate);
            }

            return placemark;
        }
    }
}
