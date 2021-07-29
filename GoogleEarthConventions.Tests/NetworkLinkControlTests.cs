using GoogleEarthConversions.Core.KML;
using GoogleEarthConversions.Core.KML.AbstractView;
using GoogleEarthConversions.Core.KML.TimePrimitive;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GoogleEarthConventions.Tests
{
    public class NetworkLinkControlTests
    {
        [Fact]
        public void NetworkLinkControl_CanInstantiate()
        {
            var sut = new NetworkLinkControl();

            Assert.NotNull(sut);
        }

        [Fact]
        public void NetworkLinkControl()
        {
            var sut = new NetworkLinkControl();

            foreach (var prop in sut.GetType().GetProperties())
            {
                var value = prop.GetValue(sut);
                Assert.NotNull(value);
            }
        }

        [Theory]
        [InlineData(0, -1, "", "", "", "", "", 2, 1, 1, 1, NetworkLinkControlUpdate.Change, false, "")]
        [InlineData(3600, -1, "", "", "", "", "", 2, 1, 1, 1, NetworkLinkControlUpdate.Change, false, "<NetworkLinkControl><minRefreshPeriod>3600</minRefreshPeriod></NetworkLinkControl>")]
        [InlineData(0, 60, "", "", "", "", "", 2, 1, 1, 1, NetworkLinkControlUpdate.Change, false, "<NetworkLinkControl><maxSessionLength>60</maxSessionLength></NetworkLinkControl>")]
        [InlineData(0, -1, "cookie:sometext", "", "", "", "", 2, 1, 1, 1, NetworkLinkControlUpdate.Change, false, "<NetworkLinkControl><cookie>cookie:sometext</cookie></NetworkLinkControl>")]
        [InlineData(0, -1, "", "This is a test", "", "", "", 2, 1, 1, 1, NetworkLinkControlUpdate.Change, false, "<NetworkLinkControl><message>This is a test</message></NetworkLinkControl>")]
        [InlineData(0, -1, "", "", "New KML features", "", "", 2, 1, 1, 1, NetworkLinkControlUpdate.Change, false, "<NetworkLinkControl><linkName>New KML features</linkName></NetworkLinkControl>")]
        [InlineData(0, -1, "", "", "", "<![CDATA[KML now has new features available!]]>", "", 2, 1, 1, 1, NetworkLinkControlUpdate.Change, false, "<NetworkLinkControl><linkDescription><![CDATA[KML now has new features available!]]></linkDescription></NetworkLinkControl>")]
        [InlineData(0, -1, "", "", "", "", "Test string", 4, 1, 1, 1, NetworkLinkControlUpdate.Change, false, "<NetworkLinkControl><linkSnippet maxLines=\"4\">Test string</linkSnippet></NetworkLinkControl>")]
        [InlineData(0, -1, "", "", "", "", "", 2, 2021, 7, 29, NetworkLinkControlUpdate.Change, false, "<NetworkLinkControl><expires>2021-07-29T00:00:00</expires></NetworkLinkControl>")]
        [InlineData(0, -1, "", "", "", "", "", 2, 1, 1, 1, NetworkLinkControlUpdate.Create, false, "<NetworkLinkControl><Update>Create</Update></NetworkLinkControl>")]
        [InlineData(0, -1, "", "", "", "", "", 2, 1, 1, 1, NetworkLinkControlUpdate.Change, true, "<NetworkLinkControl><Camera><gx:TimeStamp><when>2020-12-28T12:10:52+11:00</when></gx:TimeStamp><gx:ViewerOptions><gx:option enabled=\"0\" name=\"historicalimagery\"></gx:option><gx:option enabled=\"0\" name=\"sunlight\"></gx:option><gx:option enabled=\"0\" name=\"streetview\"></gx:option></gx:ViewerOptions><longitude>0</longitude><latitude>0</latitude><altitude>0</altitude><heading>0</heading><tilt>0</tilt><roll>0</roll></Camera></NetworkLinkControl>")]
        [InlineData(3600, 60, "cookie:sometext", "This is a test", "New KML features", "<![CDATA[KML now has new features available!]]>", "Test string", 4, 2021, 7, 29, NetworkLinkControlUpdate.Create, true, "<NetworkLinkControl><minRefreshPeriod>3600</minRefreshPeriod><maxSessionLength>60</maxSessionLength><cookie>cookie:sometext</cookie><message>This is a test</message><linkName>New KML features</linkName><linkDescription><![CDATA[KML now has new features available!]]></linkDescription><linkSnippet maxLines=\"4\">Test string</linkSnippet><expires>2021-07-29T00:00:00</expires><Update>Create</Update><Camera><gx:TimeStamp><when>2020-12-28T12:10:52+11:00</when></gx:TimeStamp><gx:ViewerOptions><gx:option enabled=\"0\" name=\"historicalimagery\"></gx:option><gx:option enabled=\"0\" name=\"sunlight\"></gx:option><gx:option enabled=\"0\" name=\"streetview\"></gx:option></gx:ViewerOptions><longitude>0</longitude><latitude>0</latitude><altitude>0</altitude><heading>0</heading><tilt>0</tilt><roll>0</roll></Camera></NetworkLinkControl>")]
        public void Link_CorrectlyConvertsToKML(double minRefreshPeriod, double maxSessionLength, string cookie, string message, 
                                                string linkName, string linkDescription, string linkSnippet, int linkSnippetMaxLines, 
                                                int year, int month, int day, NetworkLinkControlUpdate networkLinkControlUpdate, bool includeAbstractView,
                                                string expected)
        {
            var sut = new NetworkLinkControl();
            sut.MinRefreshPeriod.Value = minRefreshPeriod;
            sut.MaxSessionLength.Value = maxSessionLength;
            sut.Cookie.Value = cookie;
            sut.Message.Value = message;
            sut.LinkName.Value = linkName;
            sut.LinkDescription.Value = linkDescription;
            sut.LinkSnippet.Value = linkSnippet;
            sut.LinkSnippet.MaxLines = linkSnippetMaxLines;
            sut.Expires.Value.DateTime = new DateTime(year, month, day);
            sut.Update.Value = networkLinkControlUpdate;
            
            if (includeAbstractView)
                sut.AbstractView = CreateAbstractView();

            var result = sut.SerialiseToKML();

            Assert.Equal(expected, result);
        }

        private AbstractView CreateAbstractView()
        {
            var dateTime = new DateTime(2020, 12, 28, 12, 10, 52);
            var timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("AUS Eastern Standard Time");
            var timeStamp = new TimeStamp(dateTime, timeZoneInfo);

            return new Camera() { TimePrimitive = timeStamp };
        }

        private object TimeStamp(DateTime dateTime, TimeZoneInfo timeZoneInfo)
        {
            throw new NotImplementedException();
        }
    }
}
