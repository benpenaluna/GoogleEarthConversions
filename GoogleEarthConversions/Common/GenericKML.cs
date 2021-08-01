using System;
using System.Collections.Generic;
using System.Text;

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

            string value = Value.ToString();
            if (typeof(T) == typeof(bool))
                value = value == "True" ? "1" : "0"; 

            return string.Format("<{0}>{1}</{0}>", KmlTagName, value);
        }

        public static GenericKML<T> DeserialiseFromKML(string kml)
        {
            throw new NotImplementedException();

            //throw new NotImplementedException();


            //MemoryStream memStream = new MemoryStream(Encoding.UTF8.GetBytes(kml));
            //var doc = new XmlDocument();
            //doc.Load(memStream);
            //memStream.Close();



            ////XmlNodeList altitudeElemList = XmlOperations.RetrieveElements(kml, kmlTagName);


            //XmlNodeList altitudeElemList = doc.GetElementsByTagName(kmlTagName);


            //return new BooleanKML(kmlTagName, value: false, def: false);
        }
    }
}
