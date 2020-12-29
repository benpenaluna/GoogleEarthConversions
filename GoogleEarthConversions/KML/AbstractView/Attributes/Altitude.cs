using GeoFunctions.Core.Coordinates;
using GeoFunctions.Core.Coordinates.Measurement;
using GoogleEarthConversions.Core.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleEarthConversions.Core.KML.AbstractView.Attributes
{
    public class Altitude : Distance, IDistanceKML
    {
        public Altitude(double altitdue = 0.0, DistanceMeasurement measurement = DistanceMeasurement.Feet) : base(altitdue, measurement) { }
        public Altitude(IDistance altitude) 
        {
            Value = altitude.Value;
            DistanceMeasurement = altitude.DistanceMeasurement;
        }

        public string ConvertObjectToKML()
        {
            return string.Format("<{0}>{1}</{0}>", nameof(Altitude).ConvertFirstCharacterToLowerCase(), ToMeters());
        }
    }
}
