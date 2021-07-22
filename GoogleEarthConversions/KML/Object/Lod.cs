using GoogleEarthConversions.Core.Common;
using GoogleEarthConversions.Core.KML.Object.Attributes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GoogleEarthConversions.Core.KML.Object
{
    public class Lod : GoogleEarthObject, ILod
    {
        // Source: https://developers.google.com/kml/documentation/kmlreference?hl=en#lod
        
        public ILodElement MinLodPixels { get; set; }
        public ILodElement MaxLodPixels { get; set; }
        public ILodElement MinFadeExtent { get; set; }
        public ILodElement MaxFadeExtent { get; set; }

        public Lod(double minLodPixels = 256.0, double maxLodPixels = -1.0, double minFadeExtent = 0.0, double maxFadeExtent = 0.0)
        {
            Id = string.Empty;
            TargetId = string.Empty;
            MinLodPixels = new LodElement(ConvertMinLodPixelsToKML, minLodPixels);
            MaxLodPixels = new LodElement(ConvertMaxLodPixelsToKML, maxLodPixels);
            MinFadeExtent = new LodElement(ConvertMinFadeExtentToKML, minFadeExtent);
            MaxFadeExtent = new LodElement(ConvertMaxFadeExtentToKML, maxFadeExtent);
        }

        private static string ConvertMinLodPixelsToKML(ILodElement lodElement)
        {
            return string.Format("<{0}>{1}</{0}>", nameof(MinLodPixels).ConvertFirstCharacterToLowerCase(), lodElement.Value);
        }

        private static string ConvertMaxLodPixelsToKML(ILodElement lodElement)
        {
            if (lodElement.Value == 0)
                return string.Empty;

            return string.Format("<{0}>{1}</{0}>", nameof(MaxLodPixels).ConvertFirstCharacterToLowerCase(), lodElement.Value);
        }

        private static string ConvertMinFadeExtentToKML(ILodElement lodElement)
        {
            if (lodElement.Value == 0)
                return string.Empty;

            return string.Format("<{0}>{1}</{0}>", nameof(MinFadeExtent).ConvertFirstCharacterToLowerCase(), lodElement.Value);
        }

        private static string ConvertMaxFadeExtentToKML(ILodElement lodElement)
        {
            if (lodElement.Value == 0)
                return string.Empty;

            return string.Format("<{0}>{1}</{0}>", nameof(MaxFadeExtent).ConvertFirstCharacterToLowerCase(), lodElement.Value);
        }

        public override bool Equals(object obj)
        {
            return obj.GetType() == typeof(Lod) && Equals((Lod)obj);
        }

        protected bool Equals(Lod other)
        {
            return Equals(Id, other.Id) &&
                   Equals(TargetId, other.TargetId) &&
                   Equals(MinLodPixels, other.MinLodPixels) &&
                   Equals(MaxLodPixels, other.MaxLodPixels) &&
                   Equals(MinFadeExtent, other.MinFadeExtent) &&
                   Equals(MaxFadeExtent, other.MaxFadeExtent);
        }

        public static bool operator ==(Lod a, Lod b)
        {
            return EqualityCheck.ObjectEquals(a, b);
        }

        public static bool operator !=(Lod a, Lod b)
        {
            return !EqualityCheck.ObjectEquals(a, b);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public string SerialiseToKML()
        {
            StringWriter sw = new StringWriter();

            sw.Write(OpeningTag(GetType()));
            sw.Write(MinLodPixels.SerialiseToKML());
            sw.Write(MaxLodPixels.SerialiseToKML());
            sw.Write(MinFadeExtent.SerialiseToKML());
            sw.Write(MaxFadeExtent.SerialiseToKML());
            sw.Write(ClosingTag(GetType()));

            return sw.ToString();
        }
    }
}
