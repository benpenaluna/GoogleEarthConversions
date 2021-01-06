using GoogleEarthConversions.Core.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

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

        public override string ConvertObjectToKML()
        {
            StringWriter sw = new StringWriter();

            sw.Write(OpeningTag(GetType()));
            sw.Write(BgColor.ConvertObjectToKML());
            sw.Write(TextColor.ConvertObjectToKML());
            sw.Write(Text.ConvertObjectToKML());
            sw.Write(DisplayMode.ConvertObjectToKML());
            sw.Write(ClosingTag(GetType()));

            return sw.ToString();
        }
    }
}
