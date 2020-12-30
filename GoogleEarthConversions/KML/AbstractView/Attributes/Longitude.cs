using GeoFunctions.Core.Coordinates;
using GeoFunctions.Core.Coordinates.Measurement;
using GoogleEarthConversions.Core.Common;
using GoogleEarthConversions.Core.Geographical;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleEarthConversions.Core.KML.AbstractView.Attributes
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

        public string ConvertObjectToKML()
        {
            if (_convertObjectToKML != null)
                return _convertObjectToKML(this);

            return string.Format("<{0}>{1}</{0}>", nameof(Longitude).ConvertFirstCharacterToLowerCase(), Angle.ToDegrees());
        }
    }
}
