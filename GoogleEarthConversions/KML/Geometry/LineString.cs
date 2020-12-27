using GoogleEarthConversions.Core.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GoogleEarthConversions.Core.KML.Geometry
{
    public class LineString : LinearPath, ILineString
    {
        // Source: https://developers.google.com/kml/documentation/kmlreference?hl=en#linestring

        public IDrawOrder DrawOrder { get; set; }
        
        private ICollection<ICoordinates> _coordinates;
        public override ICollection<ICoordinates> Coordinates
        {
            get { return _coordinates; }
            set 
            {
                if (value is null)
                    throw new NullReferenceException(value.ToString());

                if (value.Count < 2)
                    throw new InvalidOperationException("The collection of Coordinates, must contain at least two ICoordinates.");
                
                _coordinates = value; 
            }
        }

        public LineString(ICollection<ICoordinates> coordinates)
        {
            InitialiseProperties(coordinates);
        }

        private void InitialiseProperties(ICollection<ICoordinates> coordinates)
        {
            Id = string.Empty;
            AltitudeOffset = new AltitudeOffset();
            Extrude = new Extrude();
            Tessellate = new Tessellate();
            AltitudeMode = new AltitudeMode();
            DrawOrder = new DrawOrder();
            Coordinates = coordinates;
        }

        public override bool Equals(object obj)
        {
            return obj.GetType() == typeof(LineString) && Equals((LineString)obj);
        }

        protected bool Equals(LineString other)
        {
            return Equals(Id, other.Id) &&
                   Equals(AltitudeOffset, other.AltitudeOffset) &&
                   Equals(Extrude, other.Extrude) &&
                   Equals(Tessellate, other.Tessellate) &&
                   Equals(AltitudeMode, other.AltitudeMode) &&
                   Equals(DrawOrder, other.DrawOrder) &&
                   ConfirmAllCordinatesAreSequentiallyTheSame(other);
        }

        private bool ConfirmAllCordinatesAreSequentiallyTheSame(LineString other)
        {
            return Coordinates.SequenceEqual(other.Coordinates);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ConvertObjectToKML()
        {
            StringWriter sw = new StringWriter();

            sw.Write(OpeningTag(GetType()));
            
            sw.Write(AltitudeOffset.ConvertObjectToKML());
            sw.Write(Extrude.ConvertObjectToKML());
            sw.Write(Tessellate.ConvertObjectToKML());
            sw.Write(AltitudeMode.ConvertObjectToKML());
            sw.Write(DrawOrder.ConvertObjectToKML());
            sw.Write(Common.Coordinates.ConvertCoordinatesCollectionToKML(Coordinates));

            sw.Write(ClosingTag(GetType()));

            return sw.ToString();
        }
    }
}
