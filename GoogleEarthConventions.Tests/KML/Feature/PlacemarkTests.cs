using GoogleEarthConversions.Core.KML.Feature;
using GoogleEarthConversions.Core.KML.Feature.Attributes;
using GoogleEarthConversions.Core.KML.Geometry;
using GoogleEarthConversions.Core.KML.Geometry.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GoogleEarthConventions.Tests.KML.Feature
{
    public class PlacemarkTests
    {
        [Fact]
        public void Placemark_CanInstantiate()
        {
            var sut = new Placemark();

            Assert.NotNull(sut);
        }

        [Fact]
        public void Placemark_AllPropertiesInitialised()
        {
            var sut = new Placemark();

            foreach (var prop in sut.GetType().GetProperties())
            {
                var value = prop.GetValue(sut);
                Assert.NotNull(value);
            }
        }

        [Theory]
        [InlineData(-33.85678333, 151.2152972, 0)]
        public void Placemark_CanInstantiateWithGeometry(double lat, double lon, double elev)
        {
            ICoordinates coordinate = new Coordinates(lat, lon, elev);
            var point = new Point(coordinate)
            {
                Id = "",
                Extrude = new Extrude(),
                AltitudeMode = new AltitudeMode(),
                Coordinates = coordinate
            };

            var sut = new Placemark(point);

            Assert.NotNull(sut);
        }

        [Theory]
        [InlineData(-33.85678333, 151.2152972, 0)]
        public void Placemark_AllPropertiesInitialisedWithGeometry(double lat, double lon, double elev)
        {
            ICoordinates coordinate = new Coordinates(lat, lon, elev);
            var point = new Point(coordinate)
            {
                Id = "",
                Extrude = new Extrude(),
                AltitudeMode = new AltitudeMode(),
                Coordinates = coordinate
            };

            var sut = new Placemark(point);

            foreach (var prop in sut.GetType().GetProperties())
            {
                var value = prop.GetValue(sut);
                Assert.NotNull(value);
            }
        }

        [Theory]
        [InlineData("", "", double.MaxValue, double.MaxValue, double.MaxValue, "<Placemark></Placemark>")]
        [InlineData("", "", 48.25450093195546, -90.86948943473118, 0, "<Placemark><Point><coordinates>-90.869489434731,48.2545009319555,0</coordinates></Point></Placemark>")] 
        [InlineData("Google Earth - New Placemark", "Some Descriptive text.", 48.25450093195546, -90.86948943473118, 0, "<Placemark><name>Google Earth - New Placemark</name><description>Some Descriptive text.</description><Point><coordinates>-90.869489434731,48.2545009319555,0</coordinates></Point></Placemark>")] 
        public void Placemark_CorrectlyConvertsToKMLWithPoint(string nameLabel, string description, double lat, double lon, double elev, string expected)
        {
            var sut = new Placemark() 
            { 
                Name = new Name(nameLabel),
                Description = new Description(description)
            };

            if (lat != double.MaxValue || lon != double.MaxValue || elev != double.MaxValue)
            {
                ICoordinates coordinate = new Coordinates(lat, lon, elev);
                sut.Geometry = new Point(coordinate);
            }

            var result = sut.SerialiseToKML();

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("Google Earth - New Placemark", "Some Descriptive text.", 48.25450093195546, -90.86948943473118, 37.824664, -122.364383, "<Placemark><name>Google Earth - New Placemark</name><description>Some Descriptive text.</description><LineString><coordinates>-90.869489434731,48.2545009319555,0 -122.364383,37.824664,0</coordinates></LineString></Placemark>")]
        public void Placemark_CorrectlyConvertsToKMLWithLineString(string nameLabel, string description, double lat1, double lon1, double lat2, double lon2, string expected)
        {
            var sut = new Placemark()
            {
                Name = new Name(nameLabel),
                Description = new Description(description)
            };

            var coordinates = new List<ICoordinates>()
            {
                new Coordinates(lat1, lon1, 0),
                new Coordinates(lat2, lon2, 0)
            };
            sut.Geometry = new LineString(coordinates);

            var result = sut.SerialiseToKML();

            Assert.Equal(expected, result);
        }
    }
}
