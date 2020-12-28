using GeoFunctions.Core.Coordinates;
using GeoFunctions.Core.Coordinates.Measurement;
using GeoFunctions.Core.Coordinates.Structs;
using GoogleEarthConversions.Core.Common;
using System;
using System.Globalization;

namespace GoogleEarthConversions.Core.KML.AbstractView.Attributes
{
    public class Tilt : SphericalCoordinate, IKMLFormat
    {
        private IAngle _angle;

        public sealed override IAngle Angle
        {
            get => _angle;
            set
            {
                var minValue = 0.0D;
                var maxValue = value.AngleMeasurement == AngleMeasurement.Degrees ? 180.0 : Math.PI;
                if (value.Value < minValue || value.Value > maxValue)
                    throw new ArgumentOutOfRangeException(value.Value.ToString(CultureInfo.InvariantCulture));

                _angle = value;
            }
        }

        public override DmsCoordinate DmsCoordinate => CalculateDmsCoordinate(Angle.Value >= 0.0 ? Hemisphere.North : Hemisphere.South);

        public Tilt()
        {
            Angle = new Angle();
        }

        public Tilt(double angle, AngleMeasurement measurement)
        {
            Angle = new Angle(angle, measurement);
        }

        public Tilt(IAngle angle)
        {
            Angle = new Angle(angle.Value, angle.AngleMeasurement);
        }

        public override bool Equals(object obj)
        {
            return obj.GetType() == typeof(Tilt) && Equals((Tilt)obj);
        }

        protected bool Equals(Tilt other)
        {
            return Equals(Angle, other.Angle) &&
                   Equals(DmsCoordinate, other.DmsCoordinate);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public string ConvertObjectToKML()
        {
            return string.Format("<{0}>{1}</{0}>", nameof(Tilt).ConvertFirstCharacterToLowerCase(), Angle.ToDegrees());
        }
    }
}
