using GeoFunctions.Core.Coordinates;
using GeoFunctions.Core.Coordinates.Measurement;

namespace GoogleEarthConversions.Core.KML.Object.Attributes
{
    public class BoundingBox : IBoundingBox
    {
        private ISphericalCoordinate north;
        public ISphericalCoordinate North
        {
            get { return north; }
            private set { north = value; }
        }

        private ISphericalCoordinate south;
        public ISphericalCoordinate South
        {
            get { return south; }
            private set { south = value; }
        }

        private ISphericalCoordinate east;
        public ISphericalCoordinate East
        {
            get { return east; }
            private set { east = value; }
        }

        private ISphericalCoordinate west;
        public ISphericalCoordinate West
        {
            get { return west; }
            private set { west = value; }
        }

        public BoundingBox()
        {
            North = new Geographical.Latitude();
            South = new Geographical.Latitude();
            East = new Geographical.Longitude();
            West = new Geographical.Longitude();
        }

        public void SetNorthAngle(double angle, AngleMeasurement measurement = AngleMeasurement.Degrees)
        {
            North = new Geographical.Latitude(angle, measurement);
        }

        public void SetSouthAngle(double angle, AngleMeasurement measurement = AngleMeasurement.Degrees)
        {
            South = new Geographical.Latitude(angle, measurement);
        }

        public void SetEastAngle(double angle, AngleMeasurement measurement = AngleMeasurement.Degrees)
        {
            East = new Geographical.Longitude(angle, measurement);
        }

        public void SetWestAngle(double angle, AngleMeasurement measurement = AngleMeasurement.Degrees)
        {
            West = new Geographical.Longitude(angle, measurement);
        }
    }
}
