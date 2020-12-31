using GeoFunctions.Core.Coordinates;
using GeoFunctions.Core.Coordinates.Measurement;
using GoogleEarthConversions.Core.Common;
using GoogleEarthConversions.Core.Geographical;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleEarthConversions.Core.KML.Object.Attributes
{
    public class MaxAltitude : GeoFunctions.Core.Coordinates.Distance, IDistanceKML
    {
        public MaxAltitude(double altitdue = 0.0, DistanceMeasurement measurement = DistanceMeasurement.Feet) : base(altitdue, measurement) { }
        public MaxAltitude(IDistance altitude)
        {
            Value = altitude.Value;
            DistanceMeasurement = altitude.DistanceMeasurement;
        }

        public string ConvertObjectToKML()
        {
            return string.Format("<{0}>{1}</{0}>", nameof(MaxAltitude).ConvertFirstCharacterToLowerCase(), ToMeters());
        }
    }
}
