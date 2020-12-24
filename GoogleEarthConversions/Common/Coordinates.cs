﻿using GeoFunctions.Core.Coordinates;
using System.Globalization;

namespace GoogleEarthConversions.Core.Common
{
    public class Coordinates : GeographicCoordinate, ICoordinates
    {
        public Coordinates() : base() { }

        public Coordinates(ISphericalCoordinate latitude, ISphericalCoordinate longitude) : base(latitude, longitude) { }

        public Coordinates(double latitude, double longitude, double elevation = 0) : base(latitude, longitude, elevation) { }

        public Coordinates(ISphericalCoordinate latitude, ISphericalCoordinate longitude, IDistance elevation) : base(latitude, longitude, elevation) { }
        
        public string ConvertObjectToKML()
        {
            return string.Format("<{0}>{1}</{0}>", nameof(Coordinates).ConvertFirstCharacterToLowerCase(),
                                                   ToString("[lon:DDD.dddddddddddd],[lat:DD.ddddddddddddd],[ele:t]", CultureInfo.InvariantCulture));
        }

        public override bool Equals(object obj)
        {
            return obj.GetType() == typeof(Coordinates) && Equals((Coordinates) obj);
        }

        protected bool Equals(Coordinates other)
        {
            var geographicCoordinate = other as GeographicCoordinate;
            return Equals(geographicCoordinate);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}