using GoogleEarthConversions.Core.KML.Geometry.Attributes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GoogleEarthConversions.Core.KML.Geometry
{
    public class LinearRing : LinearPath, ILinearRing
    {
        // Source: https://developers.google.com/kml/documentation/kmlreference?hl=en#linearring

        private ICollection<ICoordinates> _coordinates;
        public override ICollection<ICoordinates> Coordinates 
        {
            get { return _coordinates; }
            set
            {
                PerformCoorindatesSemanticChecks(value);
                _coordinates = value;
            }
        }

        private static void PerformCoorindatesSemanticChecks(ICollection<ICoordinates> value)
        {
            if (value is null)
                throw new NullReferenceException(value.ToString());

            if (!Attributes.Coordinates.Equals(value.First(), value.Last()))
                throw new InvalidOperationException("The last element in the sequence must be the same as the first.");

            if (value.Count < 4)
                throw new InvalidOperationException("The collection of Coordinates, must contain at least four ICoordinates.");
        }

        public LinearRing(ICollection<ICoordinates> coordinates)
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
            Coordinates = coordinates;
        }

        public override bool Equals(object obj)
        {
            return obj.GetType() == typeof(LinearRing) && Equals((LinearRing)obj);
        }

        protected bool Equals(LinearRing other)
        {
            return Equals(Id, other.Id) &&
                   Equals(AltitudeOffset, other.AltitudeOffset) &&
                   Equals(Extrude, other.Extrude) &&
                   Equals(Tessellate, other.Tessellate) &&
                   Equals(AltitudeMode, other.AltitudeMode) &&
                   ConfirmAllCordinatesAreSequentiallyTheSame(other);
        }

        private bool ConfirmAllCordinatesAreSequentiallyTheSame(LinearRing other)
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
            sw.Write(Attributes.Coordinates.ConvertCoordinatesCollectionToKML(Coordinates));

            sw.Write(ClosingTag(GetType()));

            return sw.ToString();
        }
    }
}
