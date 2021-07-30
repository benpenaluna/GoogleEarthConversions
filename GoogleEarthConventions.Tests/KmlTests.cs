using GoogleEarthConversions.Core.KML;
using Xunit;

namespace GoogleEarthConventions.Tests
{
    public class KmlTests
    {
        [Fact]
        public void Kml_CanInstantiate()
        {
            var sut = new Kml();

            Assert.NotNull(sut);
        }

        [Fact]
        public void Kml_AllPropertiesInitialised()
        {
            var sut = new Kml();

            foreach (var prop in sut.GetType().GetProperties())
            {
                var value = prop.GetValue(sut);
                Assert.NotNull(value);
            }
        }

        [Fact]
        public void Kml_CorrectlyConvertsToKML1()
        {
            var expected = "<?xml version=\"1.0\" encoding=\"UTF-8\"?><kml xmlns=\"http://www.opengis.net/kml/2.2\" xmlns:gx=\"http://www.google.com/kml/ext/2.2\" xmlns:kml=\"http://www.opengis.net/kml/2.2\" xmlns:atom=\"http://www.w3.org/2005/Atom\"></kml>";

            var sut = new Kml();
            var result = sut.SerialiseToKML();

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Kml_CorrectlyConvertsToKML2()
        {
            var expected = "<?xml version=\"1.0\" encoding=\"UTF-8\"?><kml xmlns=\"http://www.opengis.net/kml/2.2\" xmlns:gx=\"http://www.google.com/kml/ext/2.2\" xmlns:kml=\"http://www.opengis.net/kml/2.2\" xmlns:atom=\"http://www.w3.org/2005/Atom\"><NetworkLinkControl><cookie>cookie=sometext</cookie><message>This is a pop-up message. You will only see this once</message><linkName>New KML features</linkName><linkDescription><![CDATA[KML now has new features available!]]></linkDescription></NetworkLinkControl></kml>";

            var sut = new Kml() { NetworkLinkControl = CreateNetworkLinkControl() };
            var result = sut.SerialiseToKML();

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Kml_CorrectlyConvertsToKML3()
        {
            var expected = "<?xml version=\"1.0\" encoding=\"UTF-8\"?><kml xmlns=\"http://www.opengis.net/kml/2.2\" xmlns:gx=\"http://www.google.com/kml/ext/2.2\" xmlns:kml=\"http://www.opengis.net/kml/2.2\" xmlns:atom=\"http://www.w3.org/2005/Atom\"><Document><name>Test.kml</name><StyleMap id=\"msn_ylw-pushpin\"><Pair><key>normal</key><styleUrl>#sn_ylw-pushpin</styleUrl></Pair><Pair><key>highlight</key><styleUrl>#sh_ylw-pushpin</styleUrl></Pair></StyleMap><Style id=\"sh_ylw-pushpin\"><IconStyle><scale>1.3</scale><Icon><href>http://maps.google.com/mapfiles/kml/pushpin/ylw-pushpin.png</href></Icon><hotSpot x=\"20\" y=\"2\" xunits=\"pixels\" yunits=\"pixels\"/></IconStyle></Style><Style id=\"sn_ylw-pushpin\"><IconStyle><scale>1.1</scale><Icon><href>http://maps.google.com/mapfiles/kml/pushpin/ylw-pushpin.png</href></Icon><hotSpot x=\"20\" y=\"2\" xunits=\"pixels\" yunits=\"pixels\"/></IconStyle></Style><Placemark><name>Google Earth - New Placemark</name><description>Some Descriptive text.</description><styleUrl>#msn_ylw-pushpin</styleUrl><Point><coordinates>-90.869489434731,48.2545009319555,0</coordinates></Point></Placemark></Document></kml>";

            var feature = KML.Feature.DocumentTests.CreateNewDocument("Test.kml", "Google Earth - New Placemark", "Some Descriptive text.", 48.25450093195546, -90.86948943473118, 0);
            var sut = new Kml() { Feature = feature };
            var result = sut.SerialiseToKML();

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Kml_CorrectlyConvertsToKML4()
        {
            var expected = "<?xml version=\"1.0\" encoding=\"UTF-8\"?><kml xmlns=\"http://www.opengis.net/kml/2.2\" xmlns:gx=\"http://www.google.com/kml/ext/2.2\" xmlns:kml=\"http://www.opengis.net/kml/2.2\" xmlns:atom=\"http://www.w3.org/2005/Atom\"><NetworkLinkControl><cookie>cookie=sometext</cookie><message>This is a pop-up message. You will only see this once</message><linkName>New KML features</linkName><linkDescription><![CDATA[KML now has new features available!]]></linkDescription></NetworkLinkControl><Document><name>Test.kml</name><StyleMap id=\"msn_ylw-pushpin\"><Pair><key>normal</key><styleUrl>#sn_ylw-pushpin</styleUrl></Pair><Pair><key>highlight</key><styleUrl>#sh_ylw-pushpin</styleUrl></Pair></StyleMap><Style id=\"sh_ylw-pushpin\"><IconStyle><scale>1.3</scale><Icon><href>http://maps.google.com/mapfiles/kml/pushpin/ylw-pushpin.png</href></Icon><hotSpot x=\"20\" y=\"2\" xunits=\"pixels\" yunits=\"pixels\"/></IconStyle></Style><Style id=\"sn_ylw-pushpin\"><IconStyle><scale>1.1</scale><Icon><href>http://maps.google.com/mapfiles/kml/pushpin/ylw-pushpin.png</href></Icon><hotSpot x=\"20\" y=\"2\" xunits=\"pixels\" yunits=\"pixels\"/></IconStyle></Style><Placemark><name>Google Earth - New Placemark</name><description>Some Descriptive text.</description><styleUrl>#msn_ylw-pushpin</styleUrl><Point><coordinates>-90.869489434731,48.2545009319555,0</coordinates></Point></Placemark></Document></kml>";

            var feature = KML.Feature.DocumentTests.CreateNewDocument("Test.kml", "Google Earth - New Placemark", "Some Descriptive text.", 48.25450093195546, -90.86948943473118, 0);
            var sut = new Kml() 
            {
                NetworkLinkControl = CreateNetworkLinkControl(),
                Feature = feature 
            };
            var result = sut.SerialiseToKML();

            Assert.Equal(expected, result);
        }

        private INetworkLinkControl CreateNetworkLinkControl()
        {
            var nlc = new NetworkLinkControl();
            nlc.Message.Value = "This is a pop-up message. You will only see this once";
            nlc.Cookie.Value = "cookie=sometext";
            nlc.LinkName.Value = "New KML features";
            nlc.LinkDescription.Value = "<![CDATA[KML now has new features available!]]>";

            return nlc;
        }
    }
}
