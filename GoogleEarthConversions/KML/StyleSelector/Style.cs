using GoogleEarthConversions.Core.Common;
using GoogleEarthConversions.Core.KML.StyleSelector.Attributes;
using System;
using System.IO;

namespace GoogleEarthConversions.Core.KML.StyleSelector
{
    public class Style : StyleSelector, IStyle
    {
        public IIconStyle IconStyle { get; set; }
        public ILabelStyle LabelStyle { get; set; }
        public ILineStyle LineStyle { get; set; }
        public IPolyStyle PolyStyle { get; set; }
        public IBalloonStyle BalloonStyle { get; set; }
        public IListStyle ListStyle { get; set; }

        public Style()
        {
            Id = string.Empty;
            TargetId = string.Empty;
            IconStyle = new IconStyle();
            LabelStyle = new LabelStyle();
            LineStyle = new LineStyle();
            PolyStyle = new PolyStyle();
            BalloonStyle = new BalloonStyle();
            ListStyle = new ListStyle();
        }

        public override bool Equals(object obj)
        {
            return obj.GetType() == typeof(Style) && Equals((Style)obj);
        }

        protected bool Equals(Style other)
        {
            return Equals(Id, other.Id) &&
                   Equals(TargetId, other.TargetId) &&
                   Equals(IconStyle, other.IconStyle) &&
                   Equals(LabelStyle, other.LabelStyle) &&
                   Equals(LineStyle, other.LineStyle) &&
                   Equals(PolyStyle, other.PolyStyle) &&
                   Equals(BalloonStyle, other.BalloonStyle) &&
                   Equals(ListStyle, other.ListStyle);
        }

        public static bool operator ==(Style a, Style b)
        {
            return EqualityCheck.ObjectEquals(a, b);
        }

        public static bool operator !=(Style a, Style b)
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

            sw.Write(IconStyle.SerialiseToKML());
            sw.Write(LabelStyle.SerialiseToKML());
            sw.Write(LineStyle.SerialiseToKML());
            sw.Write(PolyStyle.SerialiseToKML());
            sw.Write(BalloonStyle.SerialiseToKML());
            sw.Write(ListStyle.SerialiseToKML());

            return sw.ToString();
        }

        public static Style DeserialiseFromKML(string kml)
        {
            throw new NotImplementedException();
        }
    }
}
