using GeoFunctions.Core.Coordinates;
using GeoFunctions.Core.Coordinates.Measurement;
using GeoFunctions.Core.Coordinates.Structs;
using GoogleEarthConversions.Core.Common;
using GoogleEarthConversions.Core.Geographical;
using System;
using System.Globalization;

namespace GoogleEarthConversions.Core.KML.AbstractView.Attributes
{
    public class Roll : SphericalCoordinate, ISphericalCoordinateKML
    {
        private IAngle _angle;

        public sealed override IAngle Angle
        {
            get => _angle;
            set
            {
                var maxValue = value.AngleMeasurement == AngleMeasurement.Degrees ? 180.0 : Math.PI;
                if (Math.Abs(value.Value) > maxValue)
                    throw new ArgumentOutOfRangeException(value.Value.ToString(CultureInfo.InvariantCulture));

                _angle = value;
            }
        }

        public override DmsCoordinate DmsCoordinate => CalculateDmsCoordinate(Angle.Value >= 0.0 ? Hemisphere.North : Hemisphere.South);

        public Roll()
        {
            Angle = new Angle();
        }

        public Roll(double angle, AngleMeasurement measurement)
        {
            Angle = new Angle(angle, measurement);
        }

        public Roll(IAngle angle)
        {
            Angle = new Angle(angle.Value, angle.AngleMeasurement);
        }

        public override bool Equals(object obj)
        {
            return obj.GetType() == typeof(Roll) && Equals((Roll)obj);
        }

        protected bool Equals(Roll other)
        {
            return Equals(Angle, other.Angle);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public string ConvertObjectToKML()
        {
            return string.Format("<{0}>{1}</{0}>", nameof(Roll).ConvertFirstCharacterToLowerCase(), Angle.ToDegrees());
        }
    }
}
