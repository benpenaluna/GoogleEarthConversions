using GoogleEarthConversions.Core.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleEarthConversions.Core.KML.StyleSelector.Attributes
{
    public class DisplayMode : IDisplayMode
    {
        public DisplayModeEnum Mode { get; set; }

        public DisplayMode(DisplayModeEnum mode = DisplayModeEnum.Default)
        {
            Mode = mode;
        }

        public override bool Equals(object obj)
        {
            return obj.GetType() == typeof(DisplayMode) && Equals((DisplayMode)obj);
        }

        protected bool Equals(DisplayMode other)
        {
            return Equals(Mode, other.Mode);
        }

        public static bool operator ==(DisplayMode a, DisplayMode b)
        {
            return EqualityCheck.ObjectEquals(a, b);
        }

        public static bool operator !=(DisplayMode a, DisplayMode b)
        {
            return !EqualityCheck.ObjectEquals(a, b);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public string SerialiseToKML()
        {
            if (Mode == DisplayModeEnum.Default)
                return "";
            
            return string.Format("<{0}>{1}</{0}>", nameof(DisplayMode).ConvertFirstCharacterToLowerCase(),
                                                   Mode.ToString().ConvertFirstCharacterToLowerCase());
        }
    }
}
