using GoogleEarthConversions.Core.KML.Geometry.Attributes;

namespace GoogleEarthConversions.Core.KML.Geometry
{
    public interface IPoint
    {
        string Id { get; set; }

        IExtrude Extrude { get; set; }

        IAltitudeMode AltitudeMode { get; set; }

        ICoordinates Coordinates { get; set; }
    }
}
