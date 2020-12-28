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

        public ISphericalCoordinate Longitude { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public ISphericalCoordinate Latitude { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IDistance Altitude { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IAngle Heading { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public ISphericalCoordinate Tilt { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public ISphericalCoordinate Roll { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IAltitudeMode AltitudeMode { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Camera()
        {
            Id = string.Empty;
            TargetId = string.Empty;
            TimePrimitive = new TimePrimitive.TimeSpan(null, null);
            ViewerOptions = new ViewerOptions();
            HorizFov = new HorizFov();
            Longitude = new Attributes.Longitude();
            Latitude = new Attributes.Latitude();
            Altitude = new Distance();
            Heading = new Angle();
            Tilt = new Tilt();
            Roll = new Roll();

        }

        public string ConvertObjectToKML()
        {
            throw new NotImplementedException();
        }
    }
}
