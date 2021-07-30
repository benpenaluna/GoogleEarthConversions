using GoogleEarthConversions.Core.Common;
using System;
using System.IO;

namespace GoogleEarthConversions.Core.KML.StyleSelector.Attributes
{
    public class BalloonStyle : ColorStyle, IBalloonStyle
    {
        public IColor BgColor { get; set; }
        public IColor TextColor { get; set; }
        public IText Text { get; set; }
        public IDisplayMode DisplayMode { get; set; }

        public BalloonStyle()
        {
            Id = string.Empty;
            TargetId = string.Empty;
            Color = new Color(string.Empty);
            ColorMode = new ColorMode(ColorModeEnum.Normal);
            BgColor = new Color(nameof(BgColor).ConvertFirstCharacterToLowerCase()) { Value = System.Drawing.Color.White, DefaultColor = System.Drawing.Color.White };
            TextColor = new Color(nameof(TextColor).ConvertFirstCharacterToLowerCase());
            Text = new Text();
            DisplayMode = new DisplayMode();
        }

        public override bool Equals(object obj)
        {
            return obj.GetType() == typeof(BalloonStyle) && Equals((BalloonStyle)obj);
        }

        protected bool Equals(BalloonStyle other)
        {
            return Equals(Id, other.Id) &&
                   Equals(TargetId, other.TargetId) &&
                   Equals(Color, other.Color) &&
                   Equals(ColorMode, other.ColorMode) &&
                   Equals(BgColor, other.BgColor) &&
                   Equals(TextColor, other.TextColor) &&
                   Equals(Text, other.Text) &&
                   Equals(DisplayMode, other.DisplayMode);
        }

        public static bool operator ==(BalloonStyle a, BalloonStyle b)
        {
            return EqualityCheck.ObjectEquals(a, b);
        }

        public static bool operator !=(BalloonStyle a, BalloonStyle b)
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

            sw.Write(BgColor.SerialiseToKML());
            sw.Write(TextColor.SerialiseToKML());
            sw.Write(Text.SerialiseToKML());
            sw.Write(DisplayMode.SerialiseToKML());

            return sw.ToString();
        }

        public static BalloonStyle DeserialiseFromKML(string kml)
        {
            throw new NotImplementedException();
        }
    }
}
