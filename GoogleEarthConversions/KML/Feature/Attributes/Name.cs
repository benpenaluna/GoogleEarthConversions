using GoogleEarthConversions.Core.Common;
using System;

namespace GoogleEarthConversions.Core.KML.Feature.Attributes
{
    public class Name : IName
    {
        public string Label { get; set; }

        public Name(string label = "")
        {
            Label = label;
        }

        public override bool Equals(object obj)
        {
            return obj.GetType() == typeof(Name) && Equals((Name)obj);
        }

        protected bool Equals(Name other)
        {
            return Equals(Label, other.Label);
        }

        public static bool operator ==(Name a, Name b)
        {
            return EqualityCheck.ObjectEquals(a, b);
        }

        public static bool operator !=(Name a, Name b)
        {
            return !EqualityCheck.ObjectEquals(a, b);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public string SerialiseToKML()
        {
            if (Label == string.Empty)
                return string.Empty;

            return string.Format("<{0}>{1}</{0}>", nameof(Name).ConvertFirstCharacterToLowerCase(), Label);
        }

        public static Name DeserialiseFromKML(string kml)
        {
            throw new NotImplementedException();
        }
    }
}
