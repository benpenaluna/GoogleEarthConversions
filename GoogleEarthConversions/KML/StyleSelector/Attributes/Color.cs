using GoogleEarthConversions.Core.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleEarthConversions.Core.KML.StyleSelector.Attributes
{
    public class Color : IColor
    {
        public System.Drawing.Color Value { get; set; }
        public System.Drawing.Color DefaultColor { get; set; }
        public string KmlTagName { get; set; }

        public Color(string kmlTagName)
        {
            KmlTagName = kmlTagName;
            Value = System.Drawing.Color.Black;
            DefaultColor = System.Drawing.Color.Black;
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

        public string SerialiseToKML()
        {
            if (Value.ColorHexValue() == DefaultColor.ColorHexValue())
                return "";

            if (KmlTagName == string.Empty)
                return FormatKmlString(nameof(Color).ConvertFirstCharacterToLowerCase());

            return FormatKmlString(KmlTagName);
        }

        private string FormatKmlString(string tagName)
        {
            return string.Format("<{0}>{1}</{0}>", tagName, Value.ColorHexValue());
        }

        public object DeserialiseFromKML()
        {
            throw new NotImplementedException();
        }
    }
}
