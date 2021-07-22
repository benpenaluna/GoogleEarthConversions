using GoogleEarthConversions.Core.KML.TimePrimitive;
using Xunit;


namespace GoogleEarthConventions.Tests.KML.TimePrimative
{
    public class TimeSpanTests
    {
        [Fact]
        public void TimeSpan_CanInstantiate()
        {
            var sut = new TimeSpan(null, null);

            Assert.NotNull(sut);
        }

        [Fact]
        public void TimeSpan_AllPropertiesInitialised()
        {
            var sut = new TimeSpan(null, null);

            foreach (var prop in sut.GetType().GetProperties())
            {
                var value = prop.GetValue(sut);
                Assert.NotNull(value);
            }
        }

        [Theory]
        [InlineData(false, false, "")]
        [InlineData(true, false, "<gx:TimeSpan><begin>2019-01-29T23:12:01</begin></gx:TimeSpan>")]
        [InlineData(false, true, "<gx:TimeSpan><end>2020-12-28T12:10:52</end></gx:TimeSpan>")]
        [InlineData(true, true, "<gx:TimeSpan><begin>2019-01-29T23:12:01</begin><end>2020-12-28T12:10:52</end></gx:TimeSpan>")]
        public void TimeSpan_CorrectlyConvertsToKML(bool beginEnabled, bool endEnabled, string expected)
        {
            System.DateTime? begin = beginEnabled ? CreateDateTime_Beginning() : null;
            System.DateTime? end = endEnabled ? CreateDateTime_End() : null;
            var sut = new TimeSpan(begin, end);

            var result = sut.SerialiseToKML();

            Assert.Equal(expected, result);
        }

        private System.DateTime? CreateDateTime_Beginning()
        {
            return new System.DateTime(2019, 1, 29, 23, 12, 01);
        }

        private System.DateTime? CreateDateTime_End()
        {
            return new System.DateTime(2020, 12, 28, 12, 10, 52);
        }
    }
}
