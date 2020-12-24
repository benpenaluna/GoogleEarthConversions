using GeoFunctions.Core.Coordinates;
using GeoFunctions.Core.Coordinates.Measurement;
using System;

namespace GoogleEarthConversions.Core.Common
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

        public string ConvertObjectToKML()
        {
            if (AltOffset.ToMeters() == 0)
                return "";
            
            return string.Format("<gx:{0}>{1}</gx:{0}>", 
                                 nameof(AltitudeOffset).ConvertFirstCharacterToLowerCase(),
                                 AltOffset.ToMeters());
        }

        public override bool Equals(object obj)
        {
            return obj.GetType() == typeof(AltitudeOffset) && Equals((AltitudeOffset)obj);
        }

        protected bool Equals(AltitudeOffset other)
        {
            return Equals(AltOffset, other.AltOffset);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
