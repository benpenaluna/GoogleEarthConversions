using GeoFunctions.Core.Coordinates;
using GoogleEarthConversions.Core.Common;

namespace GoogleEarthConversions.Core.KML.Geometry
{
    public interface IPoint
    {
        IExtrude Extrude { get; set; }

        IAltitudeMode AltitudeMode { get; set; }

        ICoordinates Coordinates { get; set; }
    }
}
