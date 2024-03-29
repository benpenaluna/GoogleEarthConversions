﻿using GoogleEarthConversions.Core.Common;
using GoogleEarthConversions.Core.KML.Geometry.Attributes;
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

        public static bool operator ==(LineString a, LineString b)
        {
            return EqualityCheck.ObjectEquals(a, b);
        }

        public static bool operator !=(LineString a, LineString b)
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

            sw.Write(AltitudeOffset.SerialiseToKML());
            sw.Write(Extrude.SerialiseToKML());
            sw.Write(Tessellate.SerialiseToKML());
            sw.Write(AltitudeMode.SerialiseToKML());
            sw.Write(DrawOrder.SerialiseToKML());
            sw.Write(Attributes.Coordinates.ConvertCoordinatesCollectionToKML(Coordinates));

            sw.Write(ClosingTag(GetType()));

            return sw.ToString();
        }

        public static LineString DeserialiseFromKML(string kml)
        {
            throw new NotImplementedException();
        }
    }
}
