using GeoFunctions.Core.Coordinates;
using GoogleEarthConversions.Core.KML.AbstractView.Attributes;
using GoogleEarthConversions.Core.KML.Common;
using GoogleEarthConversions.Core.KML.Geometry.Attributes;

namespace GoogleEarthConversions.Core.KML.AbstractView
{
    public interface ICamera : IKMLFormat
    {
        TimePrimitive.TimePrimitive TimePrimitive { get; set; }
        IViewerOptions ViewerOptions { get; set; }
        IHorizFov HorizFov { get; set; }
        ISphericalCoordinateKML Longitude { get; set; }
        ISphericalCoordinateKML Latitude { get; set; }
        IDistanceKML Altitude { get; set; }
        IAngleKML Heading { get; set; }
        ISphericalCoordinateKML Tilt { get; set; }
        ISphericalCoordinateKML Roll { get; set; }
        IAltitudeMode AltitudeMode { get; set; }
    }
}
