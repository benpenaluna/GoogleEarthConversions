using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleEarthConversions.Core.Common
{
    public class GenericKML<T>
    {
        public string KmlTagName { get; set; }
        public T Value { get; set; }
        public T Default { get; set; }

        public GenericKML(string kmlTagName, T value, T def)
        {
            KmlTagName = kmlTagName;
            Value = value;
            Default = def;
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
            if (Value.ToString() == Default.ToString())
                return string.Empty;

            return string.Format("<{0}>{1}</{0}>", KmlTagName, Value.ToString());
        }
    }
}
