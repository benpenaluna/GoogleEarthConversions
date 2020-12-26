using GeoFunctions.Core.Coordinates;
using System.Collections.Generic;
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

        public static string ConvertCoordinatesCollectionToKML(ICollection<ICoordinates> collection)
        {
            var coordinatesKML = "";
            foreach (var coordinate in collection)
            {
                coordinatesKML += coordinate.ConvertObjectToKML();
            }

            var replacementString = string.Format("</{0}><{0}>", nameof(Coordinates).ConvertFirstCharacterToLowerCase());
            return coordinatesKML.Replace(replacementString, " ");

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

        public static bool Equals(ICoordinates coordA, ICoordinates coordB)
        {
            return Equals(coordA.Latitude,  coordB.Latitude) &&
                   Equals(coordA.Longitude, coordB.Longitude) &&
                   Equals(coordA.Elevation, coordB.Elevation);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
