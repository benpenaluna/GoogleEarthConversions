using GeoFunctions.Core.Coordinates;
using GoogleEarthConversions.Core.Common;

namespace GoogleEarthConversions.Core.KML.Geometry
{
    public interface IPoint
    {
        bool Extrude { get; set; }

        IAltitudeMode AltitudeMode { get; set; }

        IGeographicCoordinate Coordinates { get; set; }
    }
}
