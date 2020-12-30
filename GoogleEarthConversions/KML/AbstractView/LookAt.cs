using GeoFunctions.Core.Coordinates;
using GoogleEarthConversions.Core.KML.AbstractView.Attributes;
using GoogleEarthConversions.Core.KML.Geometry.Attributes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GoogleEarthConversions.Core.KML.AbstractView
{
    public class LookAt : AbstractView, ILookAt
    {
        public ISphericalCoordinateKML Longitude { get; set; }
        public ISphericalCoordinateKML Latitude { get; set; }
        public IDistanceKML Altitude { get; set; }
        public IAngleKML Heading { get; set; }
        public ISphericalCoordinateKML Tilt { get; set; }
        public IDistanceKML Range { get; set; }
        public IAltitudeMode AltitudeMode { get; set; }

        public LookAt(IDistance range)
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
            Range = new Attributes.Range(range);
            AltitudeMode = new AltitudeMode();
        }

        public override bool Equals(object obj)
        {
            return obj.GetType() == typeof(LookAt) && Equals((LookAt)obj);
        }

        protected bool Equals(LookAt other)
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
                   Equals(Range, other.Range) &&
                   Equals(AltitudeMode, other.AltitudeMode);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static bool operator ==(LookAt a, LookAt b)
        {
            return Common.EqualityCheck.ObjectEquals(a, b);
        }

        public static bool operator !=(LookAt a, LookAt b)
        {
            return !Common.EqualityCheck.ObjectEquals(a, b);
        }

        public override string ConvertObjectToKML()
        {
            StringWriter sw = new StringWriter();

            sw.Write(OpeningTag(GetType()));

            sw.Write(TimePrimitive.ConvertObjectToKML());
            sw.Write(ViewerOptions.ConvertObjectToKML());
            sw.Write(Longitude.ConvertObjectToKML());
            sw.Write(Latitude.ConvertObjectToKML());
            sw.Write(Altitude.ConvertObjectToKML());
            sw.Write(Heading.ConvertObjectToKML());
            sw.Write(Tilt.ConvertObjectToKML());
            sw.Write(Range.ConvertObjectToKML());
            sw.Write(AltitudeMode.ConvertObjectToKML());

            sw.Write(ClosingTag(GetType()));

            return sw.ToString();
        }
    }
}
