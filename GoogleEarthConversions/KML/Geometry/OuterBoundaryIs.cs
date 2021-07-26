using GoogleEarthConversions.Core.Common;

namespace GoogleEarthConversions.Core.KML.Geometry
{
    public class OuterBoundaryIs : IOuterBoundaryIs
    {
        // Source: https://developers.google.com/kml/documentation/kmlreference?hl=en#outerboundaryis

        public ILinearRing LinearRing { get; set; }

        public OuterBoundaryIs(ILinearRing linearRing)
        {
            LinearRing = linearRing;
        }

        public override bool Equals(object obj)
        {
            return obj.GetType() == typeof(OuterBoundaryIs) && Equals((OuterBoundaryIs)obj);
        }

        protected bool Equals(OuterBoundaryIs other)
        {
            return LinearRing.Equals(other);
        }

        public static bool operator ==(OuterBoundaryIs a, OuterBoundaryIs b)
        {
            return EqualityCheck.ObjectEquals(a, b);
        }

        public static bool operator !=(OuterBoundaryIs a, OuterBoundaryIs b)
        {
            return !EqualityCheck.ObjectEquals(a, b);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public string SerialiseToKML()
        {
            return string.Format("<{0}>{1}</{0}>", nameof(OuterBoundaryIs).ConvertFirstCharacterToLowerCase(),
                                                   LinearRing.SerialiseToKML());
        }

        public object DeserialiseFromKML()
        {
            throw new System.NotImplementedException();
        }
    }
}
