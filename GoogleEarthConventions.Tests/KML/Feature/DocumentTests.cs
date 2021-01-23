using GoogleEarthConversions.Core.KML.Feature;
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
    }
}
