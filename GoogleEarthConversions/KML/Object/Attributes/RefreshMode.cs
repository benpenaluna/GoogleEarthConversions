using GoogleEarthConversions.Core.Common;
using System;

namespace GoogleEarthConversions.Core.KML.Object.Attributes
{
    public class RefreshMode : IRefreshMode
    {
        public RefreshModeEnum Value { get; set; }

        public RefreshMode(RefreshModeEnum value = RefreshModeEnum.OnChange)
        {
            Value = value;
        }

        public override bool Equals(object obj)
        {
            return obj.GetType() == typeof(RefreshMode) && Equals((RefreshMode)obj);
        }

        protected bool Equals(RefreshMode other)
        {
            return Equals(Value, other.Value);
        }

        public static bool operator ==(RefreshMode a, RefreshMode b)
        {
            return EqualityCheck.ObjectEquals(a, b);
        }

        public static bool operator !=(RefreshMode a, RefreshMode b)
        {
            return !EqualityCheck.ObjectEquals(a, b);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public string SerialiseToKML()
        {
            if (Value == RefreshModeEnum.OnChange)
                return string.Empty;

            return string.Format("<{0}>{1}</{0}>", nameof(RefreshMode).ConvertFirstCharacterToLowerCase(),
                                                   Value.ToString().ConvertFirstCharacterToLowerCase());
        }

        public static RefreshMode DeserialiseFromKML(string kml)
        {
            throw new NotImplementedException();
        }
    }
}
