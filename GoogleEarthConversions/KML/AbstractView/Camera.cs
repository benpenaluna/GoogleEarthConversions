using GeoFunctions.Core.Coordinates;
using GoogleEarthConversions.Core.KML.AbstractView.Attributes;
using GoogleEarthConversions.Core.KML.Feature.Attributes;
using GoogleEarthConversions.Core.KML.Geometry.Attributes;
using System;

namespace GoogleEarthConversions.Core.KML.AbstractView
{
    public class Camera : AbstractView, ICamera
    {
        // Source: https://developers.google.com/kml/documentation/kmlreference?hl=en#camera

        public ISphericalCoordinate Longitude { get; set; }
        public ISphericalCoordinate Latitude { get; set; }
        public IDistance Altitude { get; set; }
        public IAngle Heading { get; set; }
        public ISphericalCoordinate Tilt { get; set; }
        public ISphericalCoordinate Roll { get; set; }
        public IAltitudeMode AltitudeMode { get; set; }

        public Camera()
        {
            Id = string.Empty;
            TargetId = string.Empty;
            TimePrimitive = new TimePrimitive.TimeSpan(null, null);
            ViewerOptions = new ViewerOptions();
            HorizFov = new HorizFov();
            Longitude = new Attributes.Longitude();
            Latitude = new Attributes.Latitude();
            Altitude = new Altitude();
            Heading = new Heading();
            Tilt = new Tilt();
            Roll = new Roll();
            AltitudeMode = new AltitudeMode();
        }

        public string ConvertObjectToKML()
        {
            throw new NotImplementedException();
        }
    }
}
