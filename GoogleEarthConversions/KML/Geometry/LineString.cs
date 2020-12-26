﻿using GoogleEarthConversions.Core.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GoogleEarthConversions.Core.KML.Geometry
{
    public class LineString : Geometry, ILineString
    {
        // Source: https://developers.google.com/kml/documentation/kmlreference?hl=en#linestring

        public IAltitudeOffset AltitudeOffset { get; set ; }

        public ITessellate Tessellate { get; set; }

        public IDrawOrder DrawOrder { get; set; }
        
        private ICollection<ICoordinates> _coordinates;
        public ICollection<ICoordinates> Coordinates
        {
            get { return _coordinates; }
            set 
            {
                if (value.Count < 2)
                    throw new InvalidOperationException("The collection of Coordinates, must contain at least two ICoordinates.");
                
                _coordinates = value; 
            }
        }

        public LineString(string id, ICollection<ICoordinates> coordinates)
        {
            InitialiseProperties(id, coordinates);
        }

        private void InitialiseProperties(string id, ICollection<ICoordinates> coordinates)
        {
            Id = id;
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
