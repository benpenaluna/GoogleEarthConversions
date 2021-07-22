using GoogleEarthConversions.Core.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleEarthConversions.Core.KML.StyleSelector.Attributes
{
    public class ColorMode : IColorMode
    {
        public ColorModeEnum Mode { get; set; }

        public ColorMode(ColorModeEnum mode = ColorModeEnum.Normal)
        {
            Mode = mode;
        }

        public override bool Equals(object obj)
        {
            return obj.GetType() == typeof(ColorMode) && Equals((ColorMode)obj);
        }

        protected bool Equals(ColorMode other)
        {
            return Equals(Mode, other.Mode);
        }

        public static bool operator ==(ColorMode a, ColorMode b)
        {
            return EqualityCheck.ObjectEquals(a, b);
        }

        public static bool operator !=(ColorMode a, ColorMode b)
        {
            return !EqualityCheck.ObjectEquals(a, b);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public string SerialiseToKML()
        {
            if (Mode == ColorModeEnum.Normal)
                return "";
            
            return string.Format("<{0}>{1}</{0}>", nameof(ColorMode).ConvertFirstCharacterToLowerCase(), 
                                                   Mode.ToString().ConvertFirstCharacterToLowerCase());
        }
    }
}
