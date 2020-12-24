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

        private IAltitudeMode _altitudeMode;
        public IAltitudeMode AltitudeMode
        {
            get { return _altitudeMode; }
            set 
            { 
                _altitudeMode = value;
                AltitudeMode.AltMode_Changed += AltMode_OnChanged;
            }
        }
                
        private IExtrude _extrude;
        public IExtrude Extrude
        {
            get { return _extrude; }
            set 
            {
                if (value.Extruded == false || (_altitudeMode.AltMode != AltMode.ClampToGround && _altitudeMode.AltMode != AltMode.ClampToSeaFloor))
                {
                    _extrude = value;
                    Extrude.Extruded_Changed += Extrude_OnChanged;
                }
                else
                    ThrowInvalidOperationExceptionOnExtrude();
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
            Extrude = new Extrude();
            AltitudeMode = new AltitudeMode();
            Coordinates = coordinate;
        }

        private void AltMode_OnChanged(object sender, EventArgs e)
        {
            if (AltitudeMode.AltMode == AltMode.ClampToGround || AltitudeMode.AltMode == AltMode.ClampToSeaFloor)
                _extrude.Extruded = false;
        }

        private void Extrude_OnChanged(object sender, EventArgs e)
        {
            if (Extrude.Extruded == false)
                return;
            
            if (AltitudeMode.AltMode == AltMode.ClampToGround || AltitudeMode.AltMode == AltMode.ClampToSeaFloor)
            {
                Extrude.Extruded = false;
                ThrowInvalidOperationExceptionOnExtrude();
            }
        }

        private void ThrowInvalidOperationExceptionOnExtrude()
        {
            var message = string.Format("Property '{0}' cannot be set to true when '{1}' is set to '{2}' or '{3}'.",
                                                            nameof(Extrude.Extruded),
                                                            nameof(AltitudeMode.AltMode),
                                                            nameof(AltMode.ClampToGround),
                                                            nameof(AltMode.ClampToSeaFloor));
            throw new InvalidOperationException(message);
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
            sw.Write(Extrude.ConvertObjectToKML());
            sw.Write(AltitudeMode.ConvertObjectToKML());
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
