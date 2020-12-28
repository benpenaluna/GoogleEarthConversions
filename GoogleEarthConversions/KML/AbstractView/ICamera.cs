using GeoFunctions.Core.Coordinates;
using GoogleEarthConversions.Core.KML.AbstractView.Attributes;
using GoogleEarthConversions.Core.KML.Geometry.Attributes;

namespace GoogleEarthConversions.Core.KML.AbstractView
{
    public interface ICamera : IKMLFormat
    {
        TimePrimitive.TimePrimitive TimePrimitive { get; set; }
        IViewerOptions ViewerOptions { get; set; }
        IHorizFov HorizFov { get; set; }
        ISphericalCoordinate Longitude { get; set; }
        ISphericalCoordinate Latitude { get; set; }
        IDistance Altitude { get; set; }
        IAngle Heading { get; set; }
        ISphericalCoordinate Tilt { get; set; }
        ISphericalCoordinate Roll { get; set; }
        IAltitudeMode AltitudeMode { get; set; }
    }
}
