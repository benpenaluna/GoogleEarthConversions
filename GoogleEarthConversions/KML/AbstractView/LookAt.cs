using GeoFunctions.Core.Coordinates;
using GoogleEarthConversions.Core.Common;
using GoogleEarthConversions.Core.Geographical;
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
            Longitude = new Geographical.Longitude();
            Latitude = new Geographical.Latitude();
            Altitude = new Altitude();
            Heading = new Heading();
            Tilt = new Tilt();
            Range = new Attributes.Range(range);
            AltitudeMode = new AltitudeMode();

            InitialiseBaseProperties();
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

        public static bool operator ==(LookAt a, LookAt b)
        {
            return EqualityCheck.ObjectEquals(a, b);
        }

        public static bool operator !=(LookAt a, LookAt b)
        {
            return !EqualityCheck.ObjectEquals(a, b);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
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
            sw.Write(Range.SerialiseToKML());
            sw.Write(AltitudeMode.SerialiseToKML());

            sw.Write(ClosingTag(GetType()));

            return sw.ToString();
        }

        public override object DeserialiseFromKML()
        {
            throw new NotImplementedException();
        }
    }
}
