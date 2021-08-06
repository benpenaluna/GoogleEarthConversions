using GeoFunctions.Core.Coordinates;
using GeoFunctions.Core.Coordinates.Measurement;
using GoogleEarthConversions.Core.Common;
using GoogleEarthConversions.Core.Geographical;
using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Xml;

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

        public override bool Equals(object obj)
        {
            return obj.GetType() == typeof(Altitude) && Equals((Altitude)obj);
        }

        protected bool Equals(Altitude other)
        {
            return Equals(Value, other.Value) &&
                   Equals(DistanceMeasurement, other.DistanceMeasurement);
        }

        public static bool operator ==(Altitude a, Altitude b)
        {
            return EqualityCheck.ObjectEquals(a, b);
        }

        public static bool operator !=(Altitude a, Altitude b)
        {
            return !EqualityCheck.ObjectEquals(a, b);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public string SerialiseToKML()
        {
            return string.Format("<{0}>{1}</{0}>", nameof(Altitude).ConvertFirstCharacterToLowerCase(), ToMeters());
        }

        public static Altitude DeserialiseFromKML(string kml)
        {
            XmlNodeList altitudeElemList = XmlOperations.RetrieveElements(kml, nameof(Altitude).ConvertFirstCharacterToLowerCase());

            if (altitudeElemList.Count != 1 || !Double.TryParse(altitudeElemList[0].InnerXml, out double altitude))
                throw new XmlException(string.Format("The received KML string is an invalid {0} KML string.", nameof(Altitude).ConvertFirstCharacterToLowerCase()));

            return new Altitude(altitude, DistanceMeasurement.Meters);
        }
    }
}
