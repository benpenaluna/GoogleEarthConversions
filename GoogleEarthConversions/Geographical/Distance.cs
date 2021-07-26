using GeoFunctions.Core.Coordinates;
using GeoFunctions.Core.Coordinates.Measurement;
using GoogleEarthConversions.Core.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleEarthConversions.Core.Geographical
{
    public class Distance : GeoFunctions.Core.Coordinates.Distance, IDistanceKML
    {
        private Func<Distance, string> _convertObjectToKML;

        public Distance(Func<Distance, string> convertObjectToKML, double range = 0.0, DistanceMeasurement measurement = DistanceMeasurement.Meters) : base(range, measurement)
        {
            InitialiseCallback(convertObjectToKML);
        }

        public Distance(IDistance range, Func<Distance, string> convertObjectToKML)
        {
            Value = range.Value;
            DistanceMeasurement = range.DistanceMeasurement;
            InitialiseCallback(convertObjectToKML);
        }

        private void InitialiseCallback(Func<Distance, string> convertObjectToKML)
        {
            if (convertObjectToKML is null)
                throw new NullReferenceException(string.Format("{0} can not be a null reference.", nameof(convertObjectToKML)));
                
            _convertObjectToKML = convertObjectToKML;
        }

        public override bool Equals(object obj)
        {
            return obj.GetType() == typeof(Distance) && Equals((Distance)obj);
        }

        protected bool Equals(Distance other)
        {
            return Equals(Value, other.Value) &&
                   Equals(DistanceMeasurement, other.DistanceMeasurement);
        }

        public static bool operator ==(Distance a, Distance b)
        {
            return EqualityCheck.ObjectEquals(a, b);
        }

        public static bool operator !=(Distance a, Distance b)
        {
            return !EqualityCheck.ObjectEquals(a, b);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public Distance Clone()
        {
            return new Distance(this, _convertObjectToKML);
        }

        public string SerialiseToKML()
        {
            return _convertObjectToKML(this);
        }

        public object DeserialiseFromKML()
        {
            throw new NotImplementedException();
        }
    }
}
