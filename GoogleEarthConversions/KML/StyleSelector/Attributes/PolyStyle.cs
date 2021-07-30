using GoogleEarthConversions.Core.Common;
using System;
using System.IO;

namespace GoogleEarthConversions.Core.KML.StyleSelector.Attributes
{
    public class PolyStyle : ColorStyle, IPolyStyle
    {
        public GenericKML<bool> Fill { get; set; }
        public GenericKML<bool> Outline { get; set; }

        public PolyStyle()
        {
            Id = string.Empty;
            TargetId = string.Empty;
            Color = new Color(string.Empty) { Value = System.Drawing.Color.FromArgb(255, 255, 255, 255), DefaultColor = System.Drawing.Color.FromArgb(255, 255, 255, 255) };
            ColorMode = new ColorMode(ColorModeEnum.Normal);

            Fill = new BooleanKML(nameof(Fill).ConvertFirstCharacterToLowerCase(), value: false, def: false);
            Outline = new BooleanKML(nameof(Outline).ConvertFirstCharacterToLowerCase(), value: false, def: false);
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

        public override string SerialiseToKML()
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

            sw.Write(Color.SerialiseToKML());
            sw.Write(ColorMode.SerialiseToKML());
            sw.Write(Fill.SerialiseToKML());
            sw.Write(Outline.SerialiseToKML());

            return sw.ToString();
        }

        public static PolyStyle DeserialiseFromKML(string kml)
        {
            throw new NotImplementedException();
        }
    }
}
