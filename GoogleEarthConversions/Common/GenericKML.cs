using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Text;
using System.Xml;

namespace GoogleEarthConversions.Core.Common
{
    public class GenericKML<T>
    {
        private Func<GenericKML<T>, string> _serialiseToKML;

        public string KmlTagName { get; set; }
        public T Value { get; set; }
        public T Default { get; set; }

        public GenericKML(string kmlTagName, T value, T def)
        {
            KmlTagName = kmlTagName;
            Value = value;
            Default = def;
        }

        public void SetSerialiseToKMLFunction(Func<GenericKML<T>, string> func)
        {
            _serialiseToKML = func;
        }

        public override bool Equals(object obj)
        {
            return obj.GetType() == typeof(GenericKML<T>) && Equals((GenericKML<T>)obj);
        }

        protected bool Equals(GenericKML<T> other)
        {
            return Equals(KmlTagName, other.KmlTagName) &&
                   Equals(Value, other.Value) &&
                   Equals(Default, other.Default);
        }

        public static bool operator ==(GenericKML<T> a, GenericKML<T> b)
        {
            return EqualityCheck.ObjectEquals(a, b);
        }

        public static bool operator !=(GenericKML<T> a, GenericKML<T> b)
        {
            return !EqualityCheck.ObjectEquals(a, b);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public virtual string SerialiseToKML()
        {
            if (_serialiseToKML != null)
                return _serialiseToKML(this);

            if (Value.ToString() == Default.ToString())
                return string.Empty;

            var value = DetermineValueString();
            return string.Format("<{0}>{1}</{0}>", KmlTagName, value);
        }

        private string DetermineValueString()
        {
            string value = Value.ToString();
            
            if (typeof(T) == typeof(bool))
                value = value == "True" ? "1" : "0";
            
            return value;
        }

        public static GenericKML<T> DeserialiseFromKML(string kml, T def)
        {
            var kmlElements = XmlOperations.RetrieveXmlElements(kml);

            string innerValue;
            kmlElements.ChildElements.TryGetValue(kmlElements.ElementName, out innerValue);

            T value = DetermineKmlValue(innerValue);
            return new GenericKML<T>(kmlElements.ElementName, value: value, def: def);
        }

        private static T DetermineKmlValue(string innerValue)
        {
            T value;
            if (typeof(T) == typeof(bool) && (innerValue == "0" || innerValue == "1"))
            {
                var newInnerValue = innerValue == "0" ? "false" : "true";
                value = Conversions.TryParse<T>(newInnerValue);
            }
            else
            {
                value = Conversions.TryParse<T>(innerValue);
            }

            return value;
        }
    }
}
