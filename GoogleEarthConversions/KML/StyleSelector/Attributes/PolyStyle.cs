using GoogleEarthConversions.Core.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GoogleEarthConversions.Core.KML.StyleSelector.Attributes
{
    public class PolyStyle : ColorStyle, IPolyStyle
    {
        public IBooleanKML Fill { get; set; }
        public IBooleanKML Outline { get; set; }

        public PolyStyle()
        {
            Id = string.Empty;
            TargetId = string.Empty;
            Color = new Color(string.Empty) { Value = System.Drawing.Color.FromArgb(255, 255, 255, 255), DefaultColor = System.Drawing.Color.FromArgb(255, 255, 255, 255) };
            ColorMode = new ColorMode(ColorModeEnum.Normal);

            Fill = new BooleanKML(nameof(Fill).ConvertFirstCharacterToLowerCase()) { Value = false, Default = false };
            Outline = new BooleanKML(nameof(Outline).ConvertFirstCharacterToLowerCase()) { Value = false, Default = false };
        }

        public override bool Equals(object obj)
        {
            return obj.GetType() == typeof(PolyStyle) && Equals((PolyStyle)obj);
        }

        protected bool Equals(PolyStyle other)
        {
            return Equals(Id, other.Id) &&
                   Equals(TargetId, other.TargetId) &&
                   Equals(Color, other.Color) &&
                   Equals(ColorMode, other.ColorMode) &&
                   Equals(Fill, other.Fill) &&
                   Equals(Outline, other.Outline);
        }

        public static bool operator ==(PolyStyle a, PolyStyle b)
        {
            return EqualityCheck.ObjectEquals(a, b);
        }

        public static bool operator !=(PolyStyle a, PolyStyle b)
        {
            return !EqualityCheck.ObjectEquals(a, b);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ConvertObjectToKML()
        {
            var body = GetKMLBody();
            if (body == string.Empty)
                return string.Empty;
            
            StringWriter sw = new StringWriter();

            sw.Write(OpeningTag(GetType()));
            sw.Write(body);
            sw.Write(ClosingTag(GetType()));

            return sw.ToString();
        }

        private string GetKMLBody()
        {
            StringWriter sw = new StringWriter();

            sw.Write(Color.ConvertObjectToKML());
            sw.Write(ColorMode.ConvertObjectToKML());
            sw.Write(Fill.ConvertObjectToKML());
            sw.Write(Outline.ConvertObjectToKML());

            return sw.ToString();
        }
    }
}
