using GoogleEarthConversions.Core.Common;
using GoogleEarthConversions.Core.KML.Geometry;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GoogleEarthConversions.Core.KML.Feature
{
    public class Placemark : Feature, IPlacemark
    {
        public Geometry.Geometry Geometry { get; set; }

        public Placemark()
        {
            InitialisePlacemark(new DummyGeometry());
        }

        public Placemark(Geometry.Geometry geometry)
        {
            InitialisePlacemark(geometry);
        }

        private void InitialisePlacemark(Geometry.Geometry geometry)
        {
            InitiailiseFeatureProperties();
            Geometry = geometry;
        }

        public override bool Equals(object obj)
        {
            return obj.GetType() == typeof(Placemark) && Equals((Placemark)obj);
        }

        protected bool Equals(Placemark other)
        {
            return Equals(Geometry, other.Geometry) && 
                   base.Equals(other);
        }

        public static bool operator ==(Placemark a, Placemark b)
        {
            return EqualityCheck.ObjectEquals(a, b);
        }

        public static bool operator !=(Placemark a, Placemark b)
        {
            return !EqualityCheck.ObjectEquals(a, b);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string SerialiseToKML()
        {
            var baseKML = GetFeatureKMLTags(includeTypeTag: false);
            var geometryKML = Geometry.SerialiseToKML();

            return string.Format("<{0}>{1}{2}</{0}>", nameof(Placemark), baseKML, geometryKML);
        }

        public override object DeserialiseFromKML()
        {
            throw new NotImplementedException();
        }
    }
}
