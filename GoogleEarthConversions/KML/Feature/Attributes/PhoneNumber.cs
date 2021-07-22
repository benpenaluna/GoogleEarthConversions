using GoogleEarthConversions.Core.Common;

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
    }
}
