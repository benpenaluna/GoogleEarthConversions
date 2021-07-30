using GoogleEarthConversions.Core.Common;
using System;
using System.Globalization;

namespace GoogleEarthConversions.Core.KML.Object.Attributes
{
    public class ViewFormat : IViewFormat
    {
        public IBoundingBox BoundingBox { get; set; }

        public ViewFormat()
        {
            BoundingBox = new BoundingBox();
        }

        public override bool Equals(object obj)
        {
            return obj.GetType() == typeof(ViewFormat) && Equals((ViewFormat)obj);
        }

        protected bool Equals(ViewFormat other)
        {
            return Equals(BoundingBox, other.BoundingBox);
        }

        public static bool operator ==(ViewFormat a, ViewFormat b)
        {
            return EqualityCheck.ObjectEquals(a, b);
        }

        public static bool operator !=(ViewFormat a, ViewFormat b)
        {
            return !EqualityCheck.ObjectEquals(a, b);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public string SerialiseToKML()
        {
            var boundingBoxKML = GetBoundingBoxKML();

            return string.Format("<{0}>{1}</{0}>", nameof(ViewFormat).ConvertFirstCharacterToLowerCase(), boundingBoxKML);

        }

        private string GetBoundingBoxKML()
        {
            var bboxNorth = BoundingBox.North.ToString("D.ddddddddddddd", CultureInfo.InvariantCulture).RemoveTrailingZerosAndDecimalPoints();
            var bboxSouth = BoundingBox.South.ToString("D.ddddddddddddd", CultureInfo.InvariantCulture).RemoveTrailingZerosAndDecimalPoints();
            var bboxEast = BoundingBox.East.ToString("D.dddddddddddd", CultureInfo.InvariantCulture).RemoveTrailingZerosAndDecimalPoints();
            var bboxWest = BoundingBox.West.ToString("D.dddddddddddd", CultureInfo.InvariantCulture).RemoveTrailingZerosAndDecimalPoints();

            return string.Format("BBOX={0},{1},{2},{3}", bboxWest, bboxSouth, bboxEast, bboxNorth);
        }

        public static ViewFormat DeserialiseFromKML(string kml)
        {
            throw new NotImplementedException();
        }
    }
}
