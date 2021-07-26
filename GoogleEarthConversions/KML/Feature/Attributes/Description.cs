using GoogleEarthConversions.Core.Common;
using System;

namespace GoogleEarthConversions.Core.KML.Feature.Attributes
{
    public class Description : IDescription
    {
        public string Value { get; set; }

        public Description(string description = "")
        {
            Value = description;
        }

        public override bool Equals(object obj)
        {
            return obj.GetType() == typeof(Description) && Equals((Description)obj);
        }

        protected bool Equals(Description other)
        {
            return Equals(Value, other.Value);
        }

        public static bool operator ==(Description a, Description b)
        {
            return EqualityCheck.ObjectEquals(a, b);
        }

        public static bool operator !=(Description a, Description b)
        {
            return !EqualityCheck.ObjectEquals(a, b);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public string SerialiseToKML()
        {
            if (Value == string.Empty)
                return string.Empty;

            return string.Format("<{0}>{1}</{0}>", nameof(Description).ConvertFirstCharacterToLowerCase(), Value);
        }

        public object DeserialiseFromKML()
        {
            throw new NotImplementedException();
        }
    }
}
