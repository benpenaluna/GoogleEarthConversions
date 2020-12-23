using GeoFunctions.Core.Coordinates;
using System;

namespace GoogleEarthConversions.Core.KML.Geometry
{
    public class Point : Geometry, IPoint
    {
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
            ID = id;
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
            return Equals(ID, other.ID) && 
                   Equals(Coordinates, other.Coordinates) &&
                   Equals(Extrude, other.Extrude) && 
                   Equals(AltitudeMode, other.AltitudeMode);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
