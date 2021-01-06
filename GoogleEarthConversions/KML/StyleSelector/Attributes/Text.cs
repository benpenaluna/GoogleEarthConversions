using GoogleEarthConversions.Core.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleEarthConversions.Core.KML.StyleSelector.Attributes
{
    public class Text : IText
    {
        public string Value { get; set; }

        public Text(string value = "")
        {
            Value = value;
        }

        public override bool Equals(object obj)
        {
            return obj.GetType() == typeof(Text) && Equals((Text)obj);
        }

        protected bool Equals(Text other)
        {
            return Equals(Value, other.Value);
        }

        public static bool operator ==(Text a, Text b)
        {
            return EqualityCheck.ObjectEquals(a, b);
        }

        public static bool operator !=(Text a, Text b)
        {
            return !EqualityCheck.ObjectEquals(a, b);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public string ConvertObjectToKML()
        {
            if (Value == "")
                return "";

            return string.Format("<{0}>{1}</{0}>", nameof(Text).ConvertFirstCharacterToLowerCase(), Value);
        }
    }
}
