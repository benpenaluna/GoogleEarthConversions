using GoogleEarthConversions.Core.KML.Geometry.Attributes;
using System;
using System.IO;

namespace GoogleEarthConversions.Core.KML.Geometry
{
    public class Point : Geometry, IPoint
    {
        // Source: https://developers.google.com/kml/documentation/kmlreference?hl=en#point

        private ICoordinates _coordinates;
        public ICoordinates Coordinates
        {
            get { return _coordinates; }
            set 
            {
                if (value is null)
                    throw new NullReferenceException(value.ToString());

                _coordinates = value; 
            }
        }

        public Point(ICoordinates coordinate)
        {
            InitialiseProperties(coordinate);
        }

        private void InitialiseProperties(ICoordinates coordinate)
        {
            Id = string.Empty;
            Extrude = new Extrude();
            AltitudeMode = new AltitudeMode();
            Coordinates = coordinate;
        }

        public override bool Equals(object obj)
        {
            return obj.GetType() == typeof(Point) && Equals((Point)obj);
        }

        protected bool Equals(Point other)
        {
            return Equals(Id, other.Id) && 
                   Equals(Coordinates, other.Coordinates) &&
                   Equals(Extrude, other.Extrude) && 
                   Equals(AltitudeMode, other.AltitudeMode);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string SerialiseToKML()
        {
            StringWriter sw = new StringWriter();

            sw.Write(OpeningTag(GetType()));
            sw.Write(Extrude.SerialiseToKML());
            sw.Write(AltitudeMode.SerialiseToKML());
            sw.Write(Coordinates.SerialiseToKML());
            sw.Write(ClosingTag(GetType()));

            return sw.ToString();
        }
    }
}
