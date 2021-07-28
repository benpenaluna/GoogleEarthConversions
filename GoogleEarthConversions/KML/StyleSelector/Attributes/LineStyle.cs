using GoogleEarthConversions.Core.Common;
using System.IO;

namespace GoogleEarthConversions.Core.KML.StyleSelector.Attributes
{
    public class LineStyle : ColorStyle, ILineStyle
    {
        public GenericKML<double> Width { get; set; }
        public IColor OuterColor { get; set; }
        public GenericKML<double> OuterWidth { get; set; }
        public GenericKML<double> PhysicalWidth { get; set; }
        public GenericKML<bool> LabelVisibility { get; set; }

        public LineStyle()
        {
            Id = string.Empty;
            TargetId = string.Empty;
            Color = new Color(string.Empty) { Value = System.Drawing.Color.FromArgb(255, 255, 255, 255), DefaultColor = System.Drawing.Color.FromArgb(255, 255, 255, 255) };
            ColorMode = new ColorMode(ColorModeEnum.Normal);

            Width = new GenericKML<double>(nameof(Width).ConvertFirstCharacterToLowerCase(), value: 1.0, def: 1.0 );
            OuterColor = new Color("gx:" + nameof(OuterColor).ConvertFirstCharacterToLowerCase()) { Value = System.Drawing.Color.White, DefaultColor = System.Drawing.Color.White };
            OuterWidth = new GenericKML<double>("gx:" + nameof(OuterWidth).ConvertFirstCharacterToLowerCase(), value: 0.0, def: 0.0);
            PhysicalWidth = new GenericKML<double>("gx:" + nameof(PhysicalWidth).ConvertFirstCharacterToLowerCase(), value: 0.0, def: 0.0);
            LabelVisibility = new BooleanKML("gx:" + nameof(LabelVisibility).ConvertFirstCharacterToLowerCase(), value: false, def: false);
        }

        public override bool Equals(object obj)
        {
            return obj.GetType() == typeof(LineStyle) && Equals((LineStyle)obj);
        }

        protected bool Equals(LineStyle other)
        {
            return Equals(Id, other.Id) &&
                   Equals(TargetId, other.TargetId) &&
                   Equals(Color, other.Color) &&
                   Equals(ColorMode, other.ColorMode) &&
                   Equals(Width, other.Width) &&
                   Equals(OuterColor, other.OuterColor) &&
                   Equals(OuterWidth, other.OuterWidth) &&
                   Equals(PhysicalWidth, other.PhysicalWidth) &&
                   Equals(LabelVisibility, other.LabelVisibility);
        }

        public static bool operator ==(LineStyle a, LineStyle b)
        {
            return EqualityCheck.ObjectEquals(a, b);
        }

        public static bool operator !=(LineStyle a, LineStyle b)
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
            if (body.ToString() == string.Empty)
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
            sw.Write(Width.SerialiseToKML());
            sw.Write(OuterColor.SerialiseToKML());
            sw.Write(OuterWidth.SerialiseToKML());
            sw.Write(PhysicalWidth.SerialiseToKML());
            sw.Write(LabelVisibility.SerialiseToKML());

            return sw.ToString();
        }

        public override object DeserialiseFromKML()
        {
            throw new System.NotImplementedException();
        }
    }
}
