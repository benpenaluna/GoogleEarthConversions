using GoogleEarthConversions.Core.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleEarthConversions.Core.KML.StyleSelector.Attributes
{
    public class BooleanKML : IBooleanKML
    {
        public string KmlTagName { get; set; }
        public bool Value { get; set; }
        public bool Default { get; set; }

        public BooleanKML(string kmlTagName)
        {
            KmlTagName = kmlTagName;
        }

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

        public string ConvertObjectToKML()
        {
            if (Value == Default)
                return string.Empty;

            return string.Format("<{0}>{1}</{0}>", KmlTagName, Value == true ? "1" : "0");
        }
    }
}
