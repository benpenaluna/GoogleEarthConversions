using GoogleEarthConversions.Core.Common;

namespace GoogleEarthConversions.Core.KML.Feature.Attributes
{
    public class Visibility : IVisibility
    {
        public bool Visible { get; set; }

        public Visibility(bool visible = false)
        {
            Visible = visible;
        }
        public override bool Equals(object obj)
        {
            return obj.GetType() == typeof(Visibility) && Equals((Visibility)obj);
        }

        protected bool Equals(Visibility other)
        {
            return Equals(Visible, other.Visible);
        }

        public static bool operator ==(Visibility a, Visibility b)
        {
            return EqualityCheck.ObjectEquals(a, b);
        }

        public static bool operator !=(Visibility a, Visibility b)
        {
            return !EqualityCheck.ObjectEquals(a, b);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public string SerialiseToKML()
        {
            if (Visible == false)
                return string.Empty;

            return string.Format("<{0}>1</{0}>", nameof(Visibility).ConvertFirstCharacterToLowerCase());
        }

        public object DeserialiseFromKML()
        {
            throw new System.NotImplementedException();
        }
    }
}
