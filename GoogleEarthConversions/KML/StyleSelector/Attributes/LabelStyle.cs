using GoogleEarthConversions.Core.Common;
using System.IO;

namespace GoogleEarthConversions.Core.KML.StyleSelector.Attributes
{
    public class LabelStyle : ColorStyle, ILabelStyle
    {
        public IDoubleKML Scale { get; set; }

        public LabelStyle()
        {
            Id = string.Empty;
            TargetId = string.Empty;
            Color = new Color(string.Empty) { Value = System.Drawing.Color.FromArgb(255, 255, 255, 255), DefaultColor = System.Drawing.Color.FromArgb(255, 255, 255, 255) };
            ColorMode = new ColorMode(ColorModeEnum.Normal);

            Scale = new DoubleKML(nameof(Scale).ConvertFirstCharacterToLowerCase()) { Value = 1.0, Default = 1.0 };
        }

        public override bool Equals(object obj)
        {
            return obj.GetType() == typeof(LabelStyle) && Equals((LabelStyle)obj);
        }

        protected bool Equals(LabelStyle other)
        {
            return Equals(Id, other.Id) &&
                   Equals(TargetId, other.TargetId) &&
                   Equals(Color, other.Color) &&
                   Equals(ColorMode, other.ColorMode) &&
                   Equals(Scale, other.Scale);
        }

        public static bool operator ==(LabelStyle a, LabelStyle b)
        {
            return EqualityCheck.ObjectEquals(a, b);
        }

        public static bool operator !=(LabelStyle a, LabelStyle b)
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

            return sw.ToString();
        }

        public override object DeserialiseFromKML()
        {
            throw new System.NotImplementedException();
        }
    }
}
