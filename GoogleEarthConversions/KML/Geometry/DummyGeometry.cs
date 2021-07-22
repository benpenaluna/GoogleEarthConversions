using GoogleEarthConversions.Core.Common;
using GoogleEarthConversions.Core.KML.Geometry.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleEarthConversions.Core.KML.Geometry
{
    internal class DummyGeometry : Geometry
    {
        public DummyGeometry()
        {
            Id = string.Empty;
            TargetId = string.Empty;
            AltitudeMode = new AltitudeMode();
            Extrude = new Extrude();
        }

        public override bool Equals(object obj)
        {
            return obj.GetType() == typeof(DummyGeometry) && Equals((DummyGeometry)obj);
        }

        protected bool Equals(DummyGeometry other)
        {
            return base.Equals(other);
        }

        public static bool operator ==(DummyGeometry a, DummyGeometry b)
        {
            return EqualityCheck.ObjectEquals(a, b);
        }

        public static bool operator !=(DummyGeometry a, DummyGeometry b)
        {
            return !EqualityCheck.ObjectEquals(a, b);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string SerialiseToKML()
        {
            return string.Empty;
        }
    }
}
