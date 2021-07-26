using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleEarthConversions.Core.Common
{
    public class DoubleKML : IDoubleKML
    {
        public string KmlTagName { get; set; }
        public double Value { get; set; }
        public double Default { get; set; }

        public DoubleKML(string kmlTagName)
        {
            KmlTagName = kmlTagName;
        }

        public override bool Equals(object obj)
        {
            return obj.GetType() == typeof(DoubleKML) && Equals((DoubleKML)obj);
        }

        protected bool Equals(DoubleKML other)
        {
            return Equals(KmlTagName, other.KmlTagName) &&
                   Equals(Value, other.Value) &&
                   Equals(Default, other.Default);
        }

        public static bool operator ==(DoubleKML a, DoubleKML b)
        {
            return EqualityCheck.ObjectEquals(a, b);
        }

        public static bool operator !=(DoubleKML a, DoubleKML b)
        {
            return !EqualityCheck.ObjectEquals(a, b);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public string SerialiseToKML()
        {
            if (Value == Default)
                return string.Empty;
            
            return string.Format("<{0}>{1}</{0}>", KmlTagName, Value);
        }

        public object DeserialiseFromKML()
        {
            throw new NotImplementedException();
        }
    }
}
