using GoogleEarthConversions.Core.Common;
using System;

namespace GoogleEarthConversions.Core.KML.Object.Attributes
{
    public class ViewRefreshMode : IViewRefreshMode
    {
        public ViewRefreshModeEnum Value { get; set; }

        public ViewRefreshMode(ViewRefreshModeEnum value = ViewRefreshModeEnum.Never)
        {
            Value = value;
        }

        public override bool Equals(object obj)
        {
            return obj.GetType() == typeof(ViewRefreshMode) && Equals((ViewRefreshMode)obj);
        }

        protected bool Equals(ViewRefreshMode other)
        {
            return Equals(Value, other.Value);
        }

        public static bool operator ==(ViewRefreshMode a, ViewRefreshMode b)
        {
            return EqualityCheck.ObjectEquals(a, b);
        }

        public static bool operator !=(ViewRefreshMode a, ViewRefreshMode b)
        {
            return !EqualityCheck.ObjectEquals(a, b);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public string SerialiseToKML()
        {
            if (Value == ViewRefreshModeEnum.Never)
                return string.Empty;

            return string.Format("<{0}>{1}</{0}>", nameof(ViewRefreshMode).ConvertFirstCharacterToLowerCase(),
                                                   Value.ToString().ConvertFirstCharacterToLowerCase());
        }

        public static ViewRefreshMode DeserialiseFromKML(string kml)
        {
            throw new NotImplementedException();
        }
    }
}
