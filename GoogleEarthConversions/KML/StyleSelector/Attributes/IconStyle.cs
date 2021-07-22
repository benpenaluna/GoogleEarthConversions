using GoogleEarthConversions.Core.Common;
using GoogleEarthConversions.Core.Geographical;
using GoogleEarthConversions.Core.KML.AbstractView.Attributes;
using System.IO;

namespace GoogleEarthConversions.Core.KML.StyleSelector.Attributes
{
    public class IconStyle : ColorStyle, IIconStyle
    {
        public IDoubleKML Scale { get; set; }
        public IAngleKML Heading { get; set; }
        public IIcon Icon { get; set; }
        public IHotSpot HotSpot { get; set; }

        public IconStyle()
        {
            Id = string.Empty;
            TargetId = string.Empty;
            Color = new Color(string.Empty) { Value = System.Drawing.Color.FromArgb(255, 255, 255, 255), DefaultColor = System.Drawing.Color.FromArgb(255, 255, 255, 255) };
            ColorMode = new ColorMode(ColorModeEnum.Normal);

            Scale = new DoubleKML(nameof(Scale).ConvertFirstCharacterToLowerCase()) { Value = 1.0, Default = 1.0 };
            Heading = new Heading();
            Icon = new Icon();
            HotSpot = new HotSpot();
        }

        public override bool Equals(object obj)
        {
            return obj.GetType() == typeof(IconStyle) && Equals((IconStyle)obj);
        }

        protected bool Equals(IconStyle other)
        {
            return Equals(Id, other.Id) &&
                   Equals(TargetId, other.TargetId) &&
                   Equals(Color, other.Color) &&
                   Equals(ColorMode, other.ColorMode) &&
                   Equals(Scale, other.Scale) &&
                   Equals(Heading, other.Heading) &&
                   Equals(Icon, other.Icon) &&
                   Equals(HotSpot, other.HotSpot);
        }

        public static bool operator ==(IconStyle a, IconStyle b)
        {
            return EqualityCheck.ObjectEquals(a, b);
        }

        public static bool operator !=(IconStyle a, IconStyle b)
        {
            return !EqualityCheck.ObjectEquals(a, b);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string SerialiseToKML()
        {
            var body = GenerateKmlBody();

            if (body == string.Empty)
                return string.Empty;

            StringWriter sw = new StringWriter();

            sw.Write(OpeningTag(GetType()));
            sw.Write(body);
            sw.Write(ClosingTag(GetType()));

            return sw.ToString();
        }

        private string GenerateKmlBody()
        {
            StringWriter sw = new StringWriter();

            sw.Write(Color.SerialiseToKML());
            sw.Write(ColorMode.SerialiseToKML());
            sw.Write(Scale.SerialiseToKML());
            sw.Write(GetHeadingKML());
            sw.Write(Icon.SerialiseToKML());
            sw.Write(HotSpot.SerialiseToKML());

            return sw.ToString();
        }

        private string GetHeadingKML()
        {
            if (Heading.CoTerminalValue == 0.0)
                return string.Empty;

            return Heading.SerialiseToKML();
        }
    }
}
