using GeoFunctions.Core.Coordinates;
using GoogleEarthConversions.Core.KML.AbstractView.Attributes;
using GoogleEarthConversions.Core.KML.Feature.Attributes;
using GoogleEarthConversions.Core.KML.Geometry.Attributes;
using System;
using System.IO;

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
        public override bool Equals(object obj)
        {
            return obj.GetType() == typeof(Camera) && Equals((Camera)obj);
        }

        protected bool Equals(Camera other)
        {
            return Equals(Id, other.Id) &&
                   Equals(TargetId, other.TargetId) &&
                   Equals(TimePrimitive, other.TimePrimitive) &&
                   Equals(ViewerOptions, other.ViewerOptions) &&
                   Equals(HorizFov, other.HorizFov) &&
                   Equals(Longitude, other.Longitude) &&
                   Equals(Latitude, other.Latitude) &&
                   Equals(Altitude, other.Altitude) &&
                   Equals(Heading, other.Heading) &&
                   Equals(Tilt, other.Tilt) &&
                   Equals(Roll, other.Roll) &&
                   Equals(AltitudeMode, other.AltitudeMode);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ConvertObjectToKML()
        {
            StringWriter sw = new StringWriter();

            sw.Write(OpeningTag(GetType()));

            sw.Write(TimePrimitive.ConvertObjectToKML());

            sw.Write(ClosingTag(GetType()));

            return sw.ToString();
        }
    }
}
