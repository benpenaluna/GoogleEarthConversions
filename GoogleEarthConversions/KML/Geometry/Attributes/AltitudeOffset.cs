﻿using GeoFunctions.Core.Coordinates;
using GeoFunctions.Core.Coordinates.Measurement;
using GoogleEarthConversions.Core.Common;
using System;

namespace GoogleEarthConversions.Core.KML.Geometry.Attributes
{
    public class AltitudeOffset : IAltitudeOffset
    {
        public IDistance AltOffset { get; set; }

        public AltitudeOffset(double altOffsetInMeters = 0.0)
        {
            AltOffset = new Distance(altOffsetInMeters, DistanceMeasurement.Meters);
        }

        public AltitudeOffset(IDistance altOffset)
        {
            AltOffset = altOffset;
        }

        public override bool Equals(object obj)
        {
            return obj.GetType() == typeof(AltitudeOffset) && Equals((AltitudeOffset)obj);
        }

        protected bool Equals(AltitudeOffset other)
        {
            return Equals(AltOffset, other.AltOffset);
        }

        public static bool operator ==(AltitudeOffset a, AltitudeOffset b)
        {
            return EqualityCheck.ObjectEquals(a, b);
        }

        public static bool operator !=(AltitudeOffset a, AltitudeOffset b)
        {
            return !EqualityCheck.ObjectEquals(a, b);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public string SerialiseToKML()
        {
            if (AltOffset.ToMeters() == 0)
                return "";

            return string.Format("<gx:{0}>{1}</gx:{0}>",
                                 nameof(AltitudeOffset).ConvertFirstCharacterToLowerCase(),
                                 AltOffset.ToMeters());
        }

        public static AltitudeOffset DeserialiseFromKML(string kml)
        {
            throw new NotImplementedException();
        }
    }
}
