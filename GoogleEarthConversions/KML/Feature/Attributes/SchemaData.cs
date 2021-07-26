using GoogleEarthConversions.Core.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleEarthConversions.Core.KML.Feature.Attributes
{
    public class SchemaData : ISchemaData
    {
        public IHref SchemaUrl { get; set; }
        public ICollection<ISimpleData> SimpleData { get; set; }

        public SchemaData(string schemaUrl = "", ICollection<ISimpleData> simpleData = null)
        {
            SchemaUrl = new Href(schemaUrl);
            SimpleData = simpleData ?? new List<ISimpleData>();
        }

        public override bool Equals(object obj)
        {
            return obj.GetType() == typeof(SchemaData) && Equals((SchemaData)obj);
        }

        protected bool Equals(SchemaData other)
        {
            return Equals(SchemaUrl, other.SchemaUrl) &&
                   Equals(SimpleData, other.SimpleData);
        }

        public static bool operator ==(SchemaData a, SchemaData b)
        {
            return EqualityCheck.ObjectEquals(a, b);
        }

        public static bool operator !=(SchemaData a, SchemaData b)
        {
            return !EqualityCheck.ObjectEquals(a, b);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public string SerialiseToKML()
        {
            var simpleDataKML = GetSimpleDataKML();
            if (simpleDataKML == string.Empty)
                return string.Empty;

            return string.Format("<{0} {1}=\"{2}\">{3}</{0}>", nameof(SchemaData),
                                                               nameof(SchemaUrl).ConvertFirstCharacterToLowerCase(),
                                                               SchemaUrl.Value,
                                                               simpleDataKML);
        }

        private string GetSimpleDataKML()
        {
            StringBuilder sw = new StringBuilder();

            foreach (ISimpleData simpleData in SimpleData)
            {
                sw.Append(simpleData.SerialiseToKML());
            }

            return sw.ToString();
        }

        public object DeserialiseFromKML()
        {
            throw new NotImplementedException();
        }
    }
}
