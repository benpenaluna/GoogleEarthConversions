using GoogleEarthConversions.Core.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using Xunit;

namespace GoogleEarthConventions.Tests.Common
{
    public class GenericKMLTests
    {
        [Fact]
        public void GenericKML_CanInstantiateWithNullableType()
        {
            var sut = new GenericKML<string>("test", string.Empty, string.Empty);

            Assert.NotNull(sut);
        }

        [Fact]
        public void GenericKML_AllPropertiesInitialisedWithNullableType()
        {
            var sut = new GenericKML<string>("test", string.Empty, string.Empty);

            foreach (var prop in sut.GetType().GetProperties())
            {
                var value = prop.GetValue(sut);
                Assert.NotNull(value);
            }
        }

        [Fact]
        public void GenericKML_CanInstantiateWithNonNullableType()
        {
            var sut = new GenericKML<double>("test", 0, 0);

            Assert.NotNull(sut);
        }

        [Fact]
        public void GenericKML_AllPropertiesInitialisedWithNonNullableType()
        {
            var sut = new GenericKML<double>("test", 0, 0);

            foreach (var prop in sut.GetType().GetProperties())
            {
                var value = prop.GetValue(sut);
                Assert.NotNull(value);
            }
        }

        [Theory]
        [InlineData("tag", "", "", "")]
        [InlineData("tag", "test", "test", "")]
        [InlineData("tag", "tag", "test", "<tag>tag</tag>")]
        public void GenericKML_CorrectlyConvertsToKMLNullableType(string tag, string value, string def, string expected)
        {
            var sut = new GenericKML<string>(tag, value, def);

            var result = sut.SerialiseToKML();

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("tag", "inner Text", "", "<tag>inner Text</tag>")]
        [InlineData("tag", "", "", "<tag></tag>")]
        public void GenericKML_CorrectlyDeserialisedFromKMLToNullableType(string tag, string value, string def, string kmlString)
        {
            var expected = new GenericKML<string>(tag, value, def);

            var sut = GenericKML<string>.DeserialiseFromKML(kmlString, def);

            Assert.Equal(expected, sut);
        }

        [Theory]
        [InlineData("GenericKML", "")]
        [InlineData("<Tag1><Tag2>", "")]
        public void GenericKML_DeserialiseFromKMLThrowExceptionNullableType(string kmlString, string def)
        {
            Assert.Throws<XmlException>(() => GenericKML<string>.DeserialiseFromKML(kmlString, def));
        }

        [Theory]
        [InlineData("tag", false, false, "<tag>0</tag>")]
        [InlineData("tag", true, false, "<tag>1</tag>")]
        public void GenericKML_CorrectlyDeserialisedFromKMLToNonNullableType(string tag, bool value, bool def, string kmlString)
        {
            var expected = new GenericKML<bool>(tag, value, def);

            var sut = GenericKML<bool>.DeserialiseFromKML(kmlString, def);

            Assert.Equal(expected, sut);
        }

        [Theory]
        [InlineData("GenericKML", false)]
        [InlineData("<Tag1><Tag2>", false)]
        [InlineData("<Tag1>2<Tag1>", false)]
        [InlineData("<Tag1>false<Tag1>", false)]
        public void GenericKML_DeserialiseFromKMLThrowExceptionNonNullableType(string kmlString, bool def)
        {
            Assert.Throws<XmlException>(() => GenericKML<bool>.DeserialiseFromKML(kmlString, def));
        }
    }
}
