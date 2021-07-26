using GeoFunctions.Core.Coordinates;
using GeoFunctions.Core.Coordinates.Measurement;

namespace GoogleEarthConversions.Core.KML.Object.Attributes
{
    public interface IBoundingBox
    {
        ISphericalCoordinate North { get; }
        ISphericalCoordinate South { get; }
        ISphericalCoordinate East { get; }
        ISphericalCoordinate West { get; }

        void SetNorthAngle(double angle, AngleMeasurement measurement = AngleMeasurement.Degrees);
        void SetSouthAngle(double angle, AngleMeasurement measurement = AngleMeasurement.Degrees);
        void SetEastAngle(double angle, AngleMeasurement measurement = AngleMeasurement.Degrees);
        void SetWestAngle(double angle, AngleMeasurement measurement = AngleMeasurement.Degrees);
    }
}
