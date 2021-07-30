using System;

namespace GoogleEarthConversions.Core.Common
{
    public class BooleanKML : GenericKML<bool>
    {
        public BooleanKML(string kmlTagName, bool value, bool def) : base(kmlTagName, value, def) { }

        public override bool Equals(object obj)
        {
            return obj.GetType() == typeof(BooleanKML) && Equals((BooleanKML)obj);
        }

        protected bool Equals(BooleanKML other)
        {
            return Equals(KmlTagName, other.KmlTagName) &&
                   Equals(Value, other.Value) &&
                   Equals(Default, other.Default);
        }

        public static bool operator ==(BooleanKML a, BooleanKML b)
        {
            return EqualityCheck.ObjectEquals(a, b);
        }

        public static bool operator !=(BooleanKML a, BooleanKML b)
        {
            return !EqualityCheck.ObjectEquals(a, b);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string SerialiseToKML()
        {
            if (Value == Default)
                return string.Empty;

            return string.Format("<{0}>{1}</{0}>", KmlTagName, Value == true ? "1" : "0");
        }

        public static new BooleanKML DeserialiseFromKML(string kml)
        {
            throw new NotImplementedException();
        }
    }
}
