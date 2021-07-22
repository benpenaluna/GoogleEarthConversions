using GoogleEarthConversions.Core.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleEarthConversions.Core.KML.Feature.Attributes
{
    public class ExtendedData : IExtendedData
    {
        public IList<IData> Data { get; set; }
        public ISchemaData SchemaData { get; set; }

        public ExtendedData(IList<IData> data = null, SchemaData schemaData = null)
        {
            Data = data ?? new List<IData>();
            SchemaData = schemaData ?? new SchemaData();
        }

        public override bool Equals(object obj)
        {
            return obj.GetType() == typeof(ExtendedData) && Equals((ExtendedData)obj);
        }

        protected bool Equals(ExtendedData other)
        {
            return DataCollectionEqual(other.Data) &&
                   Equals(SchemaData, other.SchemaData);
        }

        private bool DataCollectionEqual(IList<IData> other)
        {
            if (other is null || Data.Count != other.Count)
                return false;

            for (var i = 0; i < Data.Count; i++)
            {
                if (!Equals(Data[i], other[i]))
                    return false;
            }

            return true;
        }

        public static bool operator ==(ExtendedData a, ExtendedData b)
        {
            return EqualityCheck.ObjectEquals(a, b);
        }

        public static bool operator !=(ExtendedData a, ExtendedData b)
        {
            return !EqualityCheck.ObjectEquals(a, b);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public string SerialiseToKML()
        {
            var dataKML = ConvertDataToKML();
            var schemaDataKML = SchemaData.SerialiseToKML();

            if (dataKML == string.Empty && schemaDataKML == string.Empty)
                return string.Empty;

            return string.Format("<{0}>{1}{2}</{0}>", nameof(ExtendedData), 
                                                      ConvertDataToKML(), 
                                                      SchemaData.SerialiseToKML());
        }

        private string ConvertDataToKML()
        {
            StringBuilder sw = new StringBuilder();

            foreach (var data in Data)
            {
                sw.Append(data.SerialiseToKML());
            }

            return sw.ToString();
        }
    }
}
