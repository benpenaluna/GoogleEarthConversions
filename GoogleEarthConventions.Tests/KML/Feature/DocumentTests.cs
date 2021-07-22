using GoogleEarthConversions.Core.KML.Feature;
using GoogleEarthConversions.Core.KML.Feature.Attributes;
using GoogleEarthConversions.Core.KML.Geometry;
using GoogleEarthConversions.Core.KML.Geometry.Attributes;
using GoogleEarthConversions.Core.KML.StyleSelector;
using GoogleEarthConversions.Core.KML.StyleSelector.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GoogleEarthConventions.Tests.KML.Feature
{
    public class DocumentTests
    {
        [Fact]
        public void Document_CanInstantiate()
        {
            var sut = new Document();

            Assert.NotNull(sut);
        }

        [Fact]
        public void Document_AllPropertiesInitialised()
        {
            var sut = new Document();

            foreach (var prop in sut.GetType().GetProperties())
            {
                var value = prop.GetValue(sut);
                Assert.NotNull(value);
            }
        }

        [Theory]
        [InlineData("Test.kml", "Google Earth - New Placemark", "Some Descriptive text.", 48.25450093195546, -90.86948943473118, 0, "<Document><name>Test.kml</name><StyleMap id=\"msn_ylw-pushpin\"><Pair><key>normal</key><styleUrl>#sn_ylw-pushpin</styleUrl></Pair><Pair><key>highlight</key><styleUrl>#sh_ylw-pushpin</styleUrl></Pair></StyleMap><Style id=\"sh_ylw-pushpin\"><IconStyle><scale>1.3</scale><Icon><href>http://maps.google.com/mapfiles/kml/pushpin/ylw-pushpin.png</href></Icon><hotSpot x=\"20\" y=\"2\" xunits=\"pixels\" yunits=\"pixels\"/></IconStyle></Style><Style id=\"sn_ylw-pushpin\"><IconStyle><scale>1.1</scale><Icon><href>http://maps.google.com/mapfiles/kml/pushpin/ylw-pushpin.png</href></Icon><hotSpot x=\"20\" y=\"2\" xunits=\"pixels\" yunits=\"pixels\"/></IconStyle></Style><Placemark><name>Google Earth - New Placemark</name><description>Some Descriptive text.</description><styleUrl>#msn_ylw-pushpin</styleUrl><Point><coordinates>-90.869489434731,48.2545009319555,0</coordinates></Point></Placemark></Document>")]
        public void Document_CorrectlyConvertsToKMLWithPoint(string docName, string nameLabel, string description, double lat, double lon, double elev, string expected)
        {
            Placemark placemark = GeneratePlaceMark(nameLabel, description, lat, lon, elev);

            var sut = new Document()
            {
                Name = new Name(docName)
            };
            sut.StyleSelectors.Add(GenerateStyleMap());
            sut.StyleSelectors.Add(GenerateIconStyle("sh_ylw-pushpin", 1.3, "http://maps.google.com/mapfiles/kml/pushpin/ylw-pushpin.png"));
            sut.StyleSelectors.Add(GenerateIconStyle("sn_ylw-pushpin", 1.1, "http://maps.google.com/mapfiles/kml/pushpin/ylw-pushpin.png"));
            sut.Features.Add(placemark);

            var result = sut.ConvertObjectToKML();

            Assert.Equal(expected, result);
        }

        private static StyleMap GenerateStyleMap()
        {
            IPair pair1 = new Pair(new StyleUrl(new Uri("file://C://Test.kml#sn_ylw-pushpin"), styleLocal: true), StyleStateEnum.Normal);
            IPair pair2 = new Pair(new StyleUrl(new Uri("file://C://Test.kml#sh_ylw-pushpin"), styleLocal: true), StyleStateEnum.Highlight);

            return new StyleMap(pair1, pair2) { Id = "msn_ylw-pushpin" };
        }

        private static Style GenerateIconStyle(string id, double scale, string href)
        {
            IIconStyle iconStyle = new IconStyle()
            {
                Icon = new Icon(href),
                Scale = new DoubleKML(nameof(scale)) { Value = scale },
                HotSpot = new HotSpot() { X = 20, Y = 2, Xunits = UnitsEnum.Pixels, Yunits = UnitsEnum.Pixels}
            };

            return new Style() 
            {
                Id = id,
                IconStyle = iconStyle
            };
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
