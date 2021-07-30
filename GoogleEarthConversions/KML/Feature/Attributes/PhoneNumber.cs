using GoogleEarthConversions.Core.Common;
using System;

namespace GoogleEarthConversions.Core.KML.Feature.Attributes
{
    public class PhoneNumber : IPhoneNumber
    {
        public string Number { get; set; }

        public PhoneNumber(string number = "")
        {
            Number = number;
        }
        public override bool Equals(object obj)
        {
            return obj.GetType() == typeof(PhoneNumber) && Equals((PhoneNumber)obj);
        }

        protected bool Equals(PhoneNumber other)
        {
            return Equals(Number, other.Number);
        }

        public static bool operator ==(PhoneNumber a, PhoneNumber b)
        {
            return EqualityCheck.ObjectEquals(a, b);
        }

        public static bool operator !=(PhoneNumber a, PhoneNumber b)
        {
            return !EqualityCheck.ObjectEquals(a, b);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public string SerialiseToKML()
        {
            if (Number == string.Empty)
                return string.Empty;

            return string.Format("<{0}>{1}</{0}>", nameof(PhoneNumber).ConvertFirstCharacterToLowerCase(), Number);
        }

        public static PhoneNumber DeserialiseFromKML(string kml)
        {
            throw new NotImplementedException();
        }
    }
}
