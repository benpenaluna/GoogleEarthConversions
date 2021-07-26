using GoogleEarthConversions.Core.Common;

namespace GoogleEarthConversions.Core.KML.AbstractView.Attributes
{
    public class Option : IOption
    {
        public bool Enabled { get; set; }
        public OptionName Name { get; set; }

        public Option(OptionName name, bool enabled = false)
        {
            Enabled = enabled;
            Name = name;
        }
        public override bool Equals(object obj)
        {
            return obj.GetType() == typeof(Option) && Equals((Option)obj);
        }

        protected bool Equals(Option other)
        {
            return Equals(Enabled, other.Enabled) &&
                   Equals(Name, other.Name);
        }

        public static bool operator ==(Option a, Option b)
        {
            return EqualityCheck.ObjectEquals(a, b);
        }

        public static bool operator !=(Option a, Option b)
        {
            return !EqualityCheck.ObjectEquals(a, b);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public string SerialiseToKML()
        {
            var enabledText = Enabled == true ? " " : string.Format(" {0}=\"0\" ", nameof(Enabled).ConvertFirstCharacterToLowerCase());

            return string.Format("<gx:{0}{1}{2}=\"{3}\"></gx:{0}>", nameof(Option).ConvertFirstCharacterToLowerCase(),
                                                                      enabledText,
                                                                      nameof(Name).ConvertFirstCharacterToLowerCase(),
                                                                      Name.ToString().ToLower());
        }

        public object DeserialiseFromKML()
        {
            throw new System.NotImplementedException();
        }
    }
}
