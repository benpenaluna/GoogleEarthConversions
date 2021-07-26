using GoogleEarthConversions.Core.Common;
using GoogleEarthConversions.Core.KML.Geometry.Attributes;
using System;
using System.IO;

namespace GoogleEarthConversions.Core.KML.Geometry
{
    public class Polygon : Geometry, IPolygon
    {
        // Source: https://developers.google.com/kml/documentation/kmlreference?hl=en#polygon

        public ITessellate Tessellate { get; set; }

        private IOuterBoundaryIs _outerBoundaryIs;
        public IOuterBoundaryIs OuterBoundaryIs
        {
            get { return _outerBoundaryIs; }
            set
            {
                if (value is null)
                    throw new NullReferenceException(value.ToString());

                _outerBoundaryIs = value;
            }
        }

        public IInnerBoundaryIs InnerBoundaryIs { get; set; }

        public Polygon(IOuterBoundaryIs outerBoundary, IInnerBoundaryIs innerBoundary = null)
        {
            Id = string.Empty;
            Extrude = new Extrude();
            Tessellate = new Tessellate();
            AltitudeMode = new AltitudeMode();
            OuterBoundaryIs = outerBoundary;
            InnerBoundaryIs = innerBoundary ?? new InnerBoundaryIs();
        }

        public override bool Equals(object obj)
        {
            return obj.GetType() == typeof(Polygon) && Equals((Polygon)obj);
        }

        protected bool Equals(Polygon other)
        {
            return Equals(Id, other.Id) &&
                   Equals(Extrude, other.Extrude) &&
                   Equals(Tessellate, other.Tessellate) &&
                   Equals(AltitudeMode, other.AltitudeMode) &&
                   Equals(OuterBoundaryIs, other.OuterBoundaryIs) &&
                   Equals(InnerBoundaryIs, other.InnerBoundaryIs);
        }

        public static bool operator ==(Polygon a, Polygon b)
        {
            return EqualityCheck.ObjectEquals(a, b);
        }

        public static bool operator !=(Polygon a, Polygon b)
        {
            return !EqualityCheck.ObjectEquals(a, b);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string SerialiseToKML()
        {
            StringWriter sw = new StringWriter();

            sw.Write(OpeningTag(GetType()));

            sw.Write(Extrude.SerialiseToKML());
            sw.Write(Tessellate.SerialiseToKML());
            sw.Write(AltitudeMode.SerialiseToKML());
            sw.Write(OuterBoundaryIs.SerialiseToKML());
            sw.Write(InnerBoundaryIs.SerialiseToKML());

            sw.Write(ClosingTag(GetType()));

            return sw.ToString();
        }

        public override object DeserialiseFromKML()
        {
            throw new NotImplementedException();
        }
    }
}
