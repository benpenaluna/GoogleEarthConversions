using GoogleEarthConversions.Core.Geographical;
using System;
using Xunit;

namespace GoogleEarthConventions.Tests.Geographical
{
    public class DistanceTests
    {
        [Fact]
        public void Distance_InstantiatationFailsIfCallbackNull()
        {
            Assert.Throws<NullReferenceException>(() => new Distance(null));
        }
    }
}
