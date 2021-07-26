using GeoFunctions.Core.Coordinates;
using GeoFunctions.Core.Coordinates.Measurement;
using GoogleEarthConversions.Core.Common;
using GoogleEarthConversions.Core.Geographical;
using System;

namespace GoogleEarthConversions.Core.KML.AbstractView.Attributes
{
    public class Altitude : GeoFunctions.Core.Coordinates.Distance, IDistanceKML
    {
        public Altitude(double altitdue = 0.0, DistanceMeasurement measurement = DistanceMeasurement.Feet) : base(altitdue, measurement) { }
        public Altitude(IDistance altitude)
        {
            Value = altitude.Value;
            DistanceMeasurement = altitude.DistanceMeasurement;
        }

        public string SerialiseToKML()
        {
            return string.Format("<{0}>{1}</{0}>", nameof(Altitude).ConvertFirstCharacterToLowerCase(), ToMeters());
        }

        public object DeserialiseFromKML()
        {
            throw new NotImplementedException();
        }
    }
}
