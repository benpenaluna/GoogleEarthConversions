﻿using GoogleEarthConversions.Core.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GoogleEarthConversions.Core.KML.Geometry
{
    public class InnerBoundaryIs : IInnerBoundaryIs
    {
        // Source: https://developers.google.com/kml/documentation/kmlreference?hl=en#innerboundaryis

        public ICollection<ILinearRing> LinearRings { get; set; }

        public InnerBoundaryIs(ICollection<ILinearRing> linearRings = null)
        {
            LinearRings = linearRings ?? new List<ILinearRing>() { };
        }

        public override bool Equals(object obj)
        {
            return obj.GetType() == typeof(InnerBoundaryIs) && Equals((InnerBoundaryIs)obj);
        }

        protected bool Equals(InnerBoundaryIs other)
        {
            return LinearRings.SequenceEqual(other.LinearRings);
        }

        public static bool operator ==(InnerBoundaryIs a, InnerBoundaryIs b)
        {
            return EqualityCheck.ObjectEquals(a, b);
        }

        public static bool operator !=(InnerBoundaryIs a, InnerBoundaryIs b)
        {
            return !EqualityCheck.ObjectEquals(a, b);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public string SerialiseToKML()
        {
            if (LinearRings?.Count == 0)
                return "";

            StringWriter linearRingsKML = new StringWriter();
            foreach (var linearRing in LinearRings)
            {
                linearRingsKML.Write(linearRing.SerialiseToKML());
            }

            return string.Format("<{0}>{1}</{0}>", nameof(InnerBoundaryIs).ConvertFirstCharacterToLowerCase(), linearRingsKML.ToString());
        }

        public static InnerBoundaryIs DeserialiseFromKML(string kml)
        {
            throw new NotImplementedException();
        }
    }
}
