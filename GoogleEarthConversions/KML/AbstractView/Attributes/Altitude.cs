using GeoFunctions.Core.Coordinates;
using GeoFunctions.Core.Coordinates.Measurement;
using GoogleEarthConversions.Core.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleEarthConversions.Core.KML.AbstractView.Attributes
{
    public class Altitude : Distance, IKMLFormat
    {
        public Altitude(double elevation = 0.0, DistanceMeasurement measurement = DistanceMeasurement.Feet) : base(elevation, measurement) { }

        public string ConvertObjectToKML()
        {
            return string.Format("<{0}>{1}</{0}>", nameof(Altitude).ConvertFirstCharacterToLowerCase(), ToMeters());
        }
    }
}
