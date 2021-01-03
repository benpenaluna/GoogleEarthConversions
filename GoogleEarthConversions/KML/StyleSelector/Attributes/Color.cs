using GoogleEarthConversions.Core.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleEarthConversions.Core.KML.StyleSelector.Attributes
{
    public class Color : IColor
    {
        public System.Drawing.Color Value { get; set; }

        public Color(int alpha = 255, int red = 255, int green = 255, int blue = 255)
        {
            Value = System.Drawing.Color.FromArgb(alpha, red, green, blue);
        }

        public override bool Equals(object obj)
        {
            return obj.GetType() == typeof(Color) && Equals((Color)obj);
        }

        protected bool Equals(Color other)
        {
            return Equals(Value, other.Value);
        }

        public static bool operator ==(Color a, Color b)
        {
            return EqualityCheck.ObjectEquals(a, b);
        }

        public static bool operator !=(Color a, Color b)
        {
            return !EqualityCheck.ObjectEquals(a, b);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public string ConvertObjectToKML()
        {
            return string.Format("<{0}>{1}</{0}>", nameof(Color).ConvertFirstCharacterToLowerCase(), ColorHexValue());
        }

        public string ColorHexValue()
        {
            return Value.A.ToString("X2").ToLower() + Value.R.ToString("X2").ToLower() + 
                   Value.G.ToString("X2").ToLower() + Value.B.ToString("X2").ToLower();
        }
    }
}
