﻿using GoogleEarthConversions.Core.Geographical;
using GoogleEarthConversions.Core.KML.AbstractView.Attributes;
using GoogleEarthConversions.Core.KML.Geometry.Attributes;
using System;
using System.IO;

namespace GoogleEarthConversions.Core.KML.AbstractView
{
    public class Camera : AbstractView, ICamera
    {
        // Source: https://developers.google.com/kml/documentation/kmlreference?hl=en#camera

        public ISphericalCoordinateKML Longitude { get; set; }
        public ISphericalCoordinateKML Latitude { get; set; }
        public IDistanceKML Altitude { get; set; }
        public IAngleKML Heading { get; set; }
        public ISphericalCoordinateKML Tilt { get; set; }
        public ISphericalCoordinateKML Roll { get; set; }
        public IAltitudeMode AltitudeMode { get; set; }

        public Camera()
        {
            Longitude = new Geographical.Longitude();
            Latitude = new Geographical.Latitude();
            Altitude = new Altitude();
            Heading = new Heading();
            Tilt = new Tilt();
            Roll = new Roll();
            AltitudeMode = new AltitudeMode();

            InitialiseBaseProperties();
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

        public static bool operator ==(Camera a, Camera b)
        {
            return Common.EqualityCheck.ObjectEquals(a, b);
        }

        public static bool operator !=(Camera a, Camera b)
        {
            return !Common.EqualityCheck.ObjectEquals(a, b);
        }

        public override string SerialiseToKML()
        {
            StringWriter sw = new StringWriter();

            sw.Write(OpeningTag(GetType()));

            sw.Write(TimePrimitive.SerialiseToKML());
            sw.Write(ViewerOptions.SerialiseToKML());
            sw.Write(Longitude.SerialiseToKML());
            sw.Write(Latitude.SerialiseToKML());
            sw.Write(Altitude.SerialiseToKML());
            sw.Write(Heading.SerialiseToKML());
            sw.Write(Tilt.SerialiseToKML());
            sw.Write(Roll.SerialiseToKML());
            sw.Write(AltitudeMode.SerialiseToKML());

            sw.Write(ClosingTag(GetType()));

            return sw.ToString();
        }

        public static Camera DeserialiseFromKML(string kml)
        {
            throw new NotImplementedException();
        }
    }
}
