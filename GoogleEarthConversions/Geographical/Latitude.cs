using GeoFunctions.Core.Coordinates;
using GeoFunctions.Core.Coordinates.Measurement;
using GoogleEarthConversions.Core.Common;
using System;

namespace GoogleEarthConversions.Core.Geographical
{
    public class Latitude : GeoFunctions.Core.Coordinates.Latitude, ISphericalCoordinateKML
    {
        private Func<Latitude, string> _convertObjectToKML;

        public Latitude(Func<Latitude, string> convertObjectToKML = null) : base()
        {
            InitialiseCallback(convertObjectToKML);
        }

        public Latitude(double angle, AngleMeasurement measurement = AngleMeasurement.Degrees, Func<Latitude, string> convertObjectToKML = null) : base(angle, measurement)
        {
            InitialiseCallback(convertObjectToKML);
        }

        public Latitude(IAngle angle, Func<Latitude, string> convertObjectToKML = null) : base(angle)
        {
            InitialiseCallback(convertObjectToKML);
        }

        private void InitialiseCallback(Func<Latitude, string> convertObjectToKML)
        {
            if (convertObjectToKML != null)
                _convertObjectToKML = convertObjectToKML;
        }

        public override bool Equals(object obj)
        {
            return obj.GetType() == typeof(Latitude) && Equals((Latitude)obj);
        }

        protected bool Equals(Latitude other)
        {
            return Equals(Angle, other.Angle);
        }

        public static bool operator ==(Latitude a, Latitude b)
        {
            return EqualityCheck.ObjectEquals(a, b);
        }

        public static bool operator !=(Latitude a, Latitude b)
        {
            return !EqualityCheck.ObjectEquals(a, b);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public Latitude Clone()
        {
            return new Latitude(this.Angle, _convertObjectToKML);
        }

        public string SerialiseToKML()
        {
            if (_convertObjectToKML != null)
                return _convertObjectToKML(this);

            return string.Format("<{0}>{1}</{0}>", nameof(Latitude).ConvertFirstCharacterToLowerCase(), Angle.ToDegrees());
        }

        public object DeserialiseFromKML()
        {
            throw new NotImplementedException();
        }
    }
}
