using GeoFunctions.Core.Coordinates;
using GeoFunctions.Core.Coordinates.Measurement;
using GoogleEarthConversions.Core.Common;
using GoogleEarthConversions.Core.Geographical;
using System;

namespace GoogleEarthConversions.Core.KML.AbstractView.Attributes
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

        public string ConvertObjectToKML()
        {
            if (_convertObjectToKML != null)
                return _convertObjectToKML(this);
            
            return string.Format("<{0}>{1}</{0}>", nameof(Latitude).ConvertFirstCharacterToLowerCase(), Angle.ToDegrees());
        }
    }
}
