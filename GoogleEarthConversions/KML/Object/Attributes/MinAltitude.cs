using GeoFunctions.Core.Coordinates;
using GeoFunctions.Core.Coordinates.Measurement;
using GoogleEarthConversions.Core.Common;
using GoogleEarthConversions.Core.Geographical;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleEarthConversions.Core.KML.Object.Attributes
{
    public class MinAltitude : GeoFunctions.Core.Coordinates.Distance, IDistanceKML
    {
        public MinAltitude(double altitdue = 0.0, DistanceMeasurement measurement = DistanceMeasurement.Feet) : base(altitdue, measurement) { }
        public MinAltitude(IDistance altitude)
        {
            Value = altitude.Value;
            DistanceMeasurement = altitude.DistanceMeasurement;
        }

        public string ConvertObjectToKML()
        {
            return string.Format("<{0}>{1}</{0}>", nameof(MinAltitude).ConvertFirstCharacterToLowerCase(), ToMeters());
        }
    }
}
