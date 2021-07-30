using GeoFunctions.Core.Coordinates;
using GeoFunctions.Core.Coordinates.Measurement;
using GoogleEarthConversions.Core.Common;
using GoogleEarthConversions.Core.Geographical;
using System;

namespace GoogleEarthConversions.Core.KML.AbstractView.Attributes
{
    public class Range : GeoFunctions.Core.Coordinates.Distance, IDistanceKML
    {
        public Range(double range = 0.0, DistanceMeasurement measurement = DistanceMeasurement.Meters) : base(range, measurement) { }
        public Range(IDistance range)
        {
            Value = range.Value;
            DistanceMeasurement = range.DistanceMeasurement;
        }

        public string SerialiseToKML()
        {
            return string.Format("<{0}>{1}</{0}>", nameof(Range).ConvertFirstCharacterToLowerCase(), ToMeters());
        }

        public static Range DeserialiseFromKML(string kml)
        {
            throw new NotImplementedException();
        }
    }
}
