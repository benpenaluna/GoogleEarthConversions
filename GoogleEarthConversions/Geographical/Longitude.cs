using GeoFunctions.Core.Coordinates;
using GeoFunctions.Core.Coordinates.Measurement;
using GoogleEarthConversions.Core.Common;
using System;

namespace GoogleEarthConversions.Core.Geographical
{
    public class Longitude : GeoFunctions.Core.Coordinates.Longitude, ISphericalCoordinateKML
    {
        private Func<Longitude, string> _convertObjectToKML;

        public Longitude(Func<Longitude, string> convertObjectToKML = null) : base()
        {
            InitialiseCallback(convertObjectToKML);
        }

        public Longitude(double angle, AngleMeasurement measurement = AngleMeasurement.Degrees, Func<Longitude, string> convertObjectToKML = null) : base(angle, measurement)
        {
            InitialiseCallback(convertObjectToKML);
        }

        public Longitude(IAngle angle, Func<Longitude, string> convertObjectToKML = null) : base(angle)
        {
            InitialiseCallback(convertObjectToKML);
        }

        private void InitialiseCallback(Func<Longitude, string> convertObjectToKML)
        {
            if (convertObjectToKML != null)
                _convertObjectToKML = convertObjectToKML;
        }

        public override bool Equals(object obj)
        {
            return obj.GetType() == typeof(Longitude) && Equals((Longitude)obj);
        }

        protected bool Equals(Longitude other)
        {
            return Equals(Angle, other.Angle);
        }

        public static bool operator ==(Longitude a, Longitude b)
        {
            return EqualityCheck.ObjectEquals(a, b);
        }

        public static bool operator !=(Longitude a, Longitude b)
        {
            return !EqualityCheck.ObjectEquals(a, b);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public Longitude Clone()
        {
            return new Longitude(this.Angle, _convertObjectToKML);
        }

        public string SerialiseToKML()
        {
            if (_convertObjectToKML != null)
                return _convertObjectToKML(this);

            return string.Format("<{0}>{1}</{0}>", nameof(Longitude).ConvertFirstCharacterToLowerCase(), Angle.ToDegrees());
        }

        public static Longitude DeserialiseFromKML(string kml)
        {
            throw new NotImplementedException();
        }
    }
}
