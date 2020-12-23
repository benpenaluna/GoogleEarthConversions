using GeoFunctions.Core.Coordinates;
using GoogleEarthConversions.Core.Common;
using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;

namespace GoogleEarthConversions.Core.KML.Geometry
{
    public class Point : Geometry, IPoint
    {
        // Source: https://developers.google.com/kml/documentation/kmlreference?hl=en#point

        public IGeographicCoordinate Coordinates { get; set; }

        private AltitudeMode _altitudeMode;
        public AltitudeMode AltitudeMode
        {
            get { return _altitudeMode; }
            set 
            { 
                _altitudeMode = value;

                if (_altitudeMode == AltitudeMode.ClampToGround)
                    _extrude = false;
            }
        }
                
        private bool _extrude;
        public bool Extrude
        {
            get { return _extrude; }
            set 
            {
                if (value == false || _altitudeMode != AltitudeMode.ClampToGround)
                    _extrude = value;
                else
                {
                    var message = string.Format("Property '{0}' cannot be set to true when '{1}' is set to {2}.", nameof(Extrude), nameof(AltitudeMode), nameof(AltitudeMode.ClampToGround));
                    throw new InvalidOperationException(message);
                }
                    
            }
        }

        public Point(string id)
        {
            InitialiseProperties(id, new GeographicCoordinate());
        }

        public Point(string id, IGeographicCoordinate coordinate)
        {
            InitialiseProperties(id, coordinate);
        }

        private void InitialiseProperties(string id, IGeographicCoordinate coordinate)
        {
            Id = id;
            Extrude = false;
            AltitudeMode = AltitudeMode.ClampToGround;
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

        public override string ConvertObjectToKML()
        {
            StringWriter sw = new StringWriter();

            sw.Write(OpeningTag());
            sw.Write(ExtrudeKML());
            sw.Write(AltitudeModeKML());
            sw.Write(CoorindatesKML());
            sw.Write(ClosingTag());

            if (Debugger.IsAttached)
            {
                Debug.Write(sw.ToString());
                Debugger.Break();
            }

            return sw.ToString();
        }

        private string OpeningTag()
        {
            return string.Format("<{0} {1}=\"{2}\">", GetType().Name, nameof(Id).ConvertFirstCharacterToLowerCase(), Id);
        }

        private string ExtrudeKML()
        {
            if (Extrude == false)
                return "";

            return string.Format("<{0}>1</{0}>", nameof(Extrude).ConvertFirstCharacterToLowerCase());
        }

        private string AltitudeModeKML()
        {
            if (AltitudeMode == AltitudeMode.ClampToGround)
                return "";

            return string.Format("<{0}>{1}</{0}>", nameof(AltitudeMode).ConvertFirstCharacterToLowerCase(),
                                                   AltitudeMode.ClampToGround.ToString().ConvertFirstCharacterToLowerCase());
        }

        private string CoorindatesKML()
        {
            return string.Format("<{0}>{1}</{0}>", nameof(Coordinates).ConvertFirstCharacterToLowerCase(),
                                                   Coordinates.ToString("[lon:DDD.dddddddddddd],[lat:DD.ddddddddddddd],[ele:t]", CultureInfo.InvariantCulture));
        }

        private string ClosingTag()
        {
            return string.Format("</{0}>", GetType().Name);
        }
    }
}
