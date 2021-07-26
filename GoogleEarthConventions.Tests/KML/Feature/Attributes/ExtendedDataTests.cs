using GoogleEarthConversions.Core.KML.Feature.Attributes;
using System.Collections.Generic;
using Xunit;

namespace GoogleEarthConventions.Tests.KML.Feature.Attributes
{
    public class ExtendedDataTests
    {
        [Fact]
        public void ExtendedData_CanInstantiate()
        {
            var sut = new ExtendedData();

            Assert.NotNull(sut);
        }

        [Fact]
        public void ExtendedData_AllPropertiesInitialised()
        {
            var sut = new ExtendedData();

            foreach (var prop in sut.GetType().GetProperties())
            {
                var value = prop.GetValue(sut);
                Assert.NotNull(value);
            }
        }
        [Fact]
        public void ExtendedData_CanInstantiateWithProvidedProperties()
        {
            var data = new List<IData>();
            var schemaData = new SchemaData();
            var sut = new ExtendedData(data, schemaData);

            Assert.NotNull(sut);
        }

        [Fact]
        public void ExtendedData_AllPropertiesInitialisedWithProvidedProperties()
        {
            var data = new List<IData>();
            var schemaData = new SchemaData();
            var sut = new ExtendedData(data, schemaData);

            foreach (var prop in sut.GetType().GetProperties())
            {
                var value = prop.GetValue(sut);
                Assert.NotNull(value);
            }
        }

        [Theory]
        [InlineData("holeNumber", "1", "", "", "", "", "", "<ExtendedData><Data name=\"holeNumber\"><value>1</value></Data></ExtendedData>")]
        [InlineData("holeNumber", "1", "holeYardage", "234", "", "", "", "<ExtendedData><Data name=\"holeNumber\"><value>1</value></Data><Data name=\"holeYardage\"><value>234</value></Data></ExtendedData>")]
        [InlineData("", "", "", "", "http://host.com/PlacesIHaveLived.kml#my-schema-id", "TrailHeadName", "Pi in the sky", "<ExtendedData><SchemaData schemaUrl=\"http://host.com/PlacesIHaveLived.kml#my-schema-id\"><SimpleData name=\"TrailHeadName\">Pi in the sky</SimpleData></SchemaData></ExtendedData>")]
        public void ExtendedData_CorrectlyConvertsToKML(string dataName1, string dataValue1, string dataName2, string dataValue2,
                                                        string schemaURL, string simpleDataName, string simpleDataValue, string expected)
        {
            var data1 = dataName1 == string.Empty && dataValue1 == string.Empty ? null : new Data(dataName1, dataValue1);
            var data2 = dataName2 == string.Empty && dataValue2 == string.Empty ? null : new Data(dataName2, dataValue2);

            var data = new List<IData>() { };
            if (data1 != null)
                data.Add(data1);
            if (data2 != null)
                data.Add(data2);

            var simpleData = new List<ISimpleData>() { new SimpleData(simpleDataName, simpleDataValue) };
            var schemaData = schemaURL == string.Empty ? null : new SchemaData(schemaURL, simpleData);

            var sut = new ExtendedData(data, schemaData);

            var result = sut.SerialiseToKML();

            Assert.Equal(expected, result);
        }

        [Fact]
        public void ExtendedData_CorrectlyConvertsToKMLWithoutData()
        {
            var expected = string.Empty;

            var sut = new ExtendedData();

            var result = sut.SerialiseToKML();

            Assert.Equal(expected, result);
        }
    }
}
