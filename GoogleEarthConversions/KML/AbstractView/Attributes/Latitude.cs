using GeoFunctions.Core.Coordinates;
using GeoFunctions.Core.Coordinates.Measurement;
using GoogleEarthConversions.Core.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleEarthConversions.Core.KML.AbstractView.Attributes
{
    public class Latitude : GeoFunctions.Core.Coordinates.Longitude, IKMLFormat
    {
        public Latitude() : base() { }

        public Latitude(double angle, AngleMeasurement measurement = AngleMeasurement.Degrees) : base(angle, measurement) { }

        public Latitude(IAngle angle) : base(angle) { }

        public string ConvertObjectToKML()
        {
            return string.Format("<{0}>{1}</{0}>", nameof(Latitude).ConvertFirstCharacterToLowerCase(), Angle.ToDegrees());
        }
    }
}
