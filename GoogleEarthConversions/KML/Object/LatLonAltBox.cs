﻿using GeoFunctions.Core.Coordinates;
using GeoFunctions.Core.Coordinates.Measurement;
using GoogleEarthConversions.Core.Common;
using GoogleEarthConversions.Core.Geographical;
using GoogleEarthConversions.Core.KML.Geometry.Attributes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GoogleEarthConversions.Core.KML.Object
{
    public class LatLonAltBox : GoogleEarthObject, ILatLonAltBox
    {
        private ISphericalCoordinateKML _north;
        public ISphericalCoordinateKML North
        {
            get => _north;
            private set 
            {
                if (value is null)
                    ThrowNullReferenceException(nameof(North));

                _north = value; 
            }
        }

        private ISphericalCoordinateKML _south;
        public ISphericalCoordinateKML South
        {
            get => _south;
            private set
            {
                if (value is null)
                    ThrowNullReferenceException(nameof(South));

                _south = value; 
            }
        }

        private ISphericalCoordinateKML _east;
        public ISphericalCoordinateKML East
        {
            get => _east;
            private set
            {
                if (value is null)
                    ThrowNullReferenceException(nameof(East));

                _east = value; 
            }
        }

        private ISphericalCoordinateKML _west;
        public ISphericalCoordinateKML West
        {
            get => _west;
            private set
            {
                if (value is null)
                    ThrowNullReferenceException(nameof(West));

                _west = value; 
            }
        }

        private IDistanceKML _minAltitude;
        public IDistanceKML MinAltitude
        {
            get => _minAltitude;
            private set
            {
                if (value is null)
                    ThrowNullReferenceException(nameof(MinAltitude));

                _minAltitude = value;
            }
        }

        private IDistanceKML _maxAltitude;
        public IDistanceKML MaxAltitude
        {
            get => _maxAltitude;
            set
            {
                if (value is null)
                    ThrowNullReferenceException(nameof(MaxAltitude));

                _maxAltitude = value;
            }
        }
        public IAltitudeMode AltitudeMode { get; set; }

        public LatLonAltBox()
        {
            Id = string.Empty;
            TargetId = string.Empty;
            AltitudeMode = new AltitudeMode();
            MinAltitude = new Geographical.Distance(ConvertMinAltitudeToKML, 0.0, DistanceMeasurement.Meters);
            MaxAltitude = new Geographical.Distance(ConvertMaxAltitudeToKML, 0.0, DistanceMeasurement.Meters);
            North = new Geographical.Latitude(90.0, AngleMeasurement.Degrees, ConvertNorthToKML);
            South = new Geographical.Latitude(-90.0, AngleMeasurement.Degrees, ConvertSouthToKML);
            East = new Geographical.Longitude(180.0, AngleMeasurement.Degrees, ConvertEastToKML);
            West = new Geographical.Longitude(-179.999999999999, AngleMeasurement.Degrees, ConvertWestToKML);
        }

        private void ThrowNullReferenceException(string subjectObject)
        {
            var message = string.Format("{0} must not be null.", subjectObject);
            throw new NullReferenceException(message);
        }

        public void UpdateMinAltitude(double distance, DistanceMeasurement measurement)
        {
            MinAltitude.Value = GeoFunctions.Core.Coordinates.Distance.ToMeters(distance, measurement);
        }

        public void UpdateMaxAltitude(double distance, DistanceMeasurement measurement)
        {
            MaxAltitude.Value = GeoFunctions.Core.Coordinates.Distance.ToMeters(distance, measurement);
        }

        public void UpdateNorthAngle(IAngle angle)
        {
            if (angle is null)
                ThrowNullReferenceException(nameof(angle));

            try { North.Angle = angle; }
            catch (ArgumentOutOfRangeException) { throw; }
        }

        public void UpdateSouthAngle(IAngle angle)
        {
            if (angle is null)
                ThrowNullReferenceException(nameof(angle));

            try { South.Angle = angle; }
            catch (ArgumentOutOfRangeException) { throw; }
        }

        public void UpdateEastAngle(IAngle angle)
        {
            if (angle is null)
                ThrowNullReferenceException(nameof(angle));

            try { East.Angle = angle; }
            catch (ArgumentOutOfRangeException) { throw; }
        }

        public void UpdateWestAngle(IAngle angle)
        {
            if (angle is null)
                ThrowNullReferenceException(nameof(angle));

            try { West.Angle = angle; }
            catch (ArgumentOutOfRangeException) { throw; }
        }

        public override bool Equals(object obj)
        {
            return obj.GetType() == typeof(LatLonAltBox) && Equals((LatLonAltBox)obj);
        }

        protected bool Equals(LatLonAltBox other)
        {
            return Equals(Id, other.Id) &&
                   Equals(TargetId, other.TargetId) &&
                   Equals(AltitudeMode, other.AltitudeMode) &&
                   Equals(MinAltitude, other.MinAltitude) &&
                   Equals(MaxAltitude, other.AltitudeMode) &&
                   Equals(North, other.North) &&
                   Equals(South, other.South) &&
                   Equals(East, other.East) &&
                   Equals(West, other.West);
        }

        public static bool operator ==(LatLonAltBox a, LatLonAltBox b)
        {
            return EqualityCheck.ObjectEquals(a, b);
        }

        public static bool operator !=(LatLonAltBox a, LatLonAltBox b)
        {
            return !EqualityCheck.ObjectEquals(a, b);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        private static string ConvertMinAltitudeToKML(Geographical.Distance dist)
        {
            return string.Format("<{0}>{1}</{0}>", nameof(MinAltitude).ConvertFirstCharacterToLowerCase(), dist.ToMeters());
        }

        private static string ConvertMaxAltitudeToKML(Geographical.Distance dist)
        {
            return string.Format("<{0}>{1}</{0}>", nameof(MaxAltitude).ConvertFirstCharacterToLowerCase(), dist.ToMeters());
        }

        private static string ConvertNorthToKML(Geographical.Latitude lat)
        {
            return string.Format("<{0}>{1}</{0}>", nameof(North).ConvertFirstCharacterToLowerCase(), lat.Angle.ToDegrees());
        }

        private static string ConvertSouthToKML(Geographical.Latitude lat)
        {
            return string.Format("<{0}>{1}</{0}>", nameof(South).ConvertFirstCharacterToLowerCase(), lat.Angle.ToDegrees());
        }

        private static string ConvertEastToKML(Geographical.Longitude lon)
        {
            return string.Format("<{0}>{1}</{0}>", nameof(East).ConvertFirstCharacterToLowerCase(), lon.Angle.ToDegrees());
        }

        private static string ConvertWestToKML(Geographical.Longitude lon)
        {
            return string.Format("<{0}>{1}</{0}>", nameof(West).ConvertFirstCharacterToLowerCase(), lon.Angle.ToDegrees());
        }

        public string ConvertObjectToKML()
        {
            StringWriter sw = new StringWriter();

            sw.Write(OpeningTag(GetType()));
            sw.Write(North.ConvertObjectToKML());
            sw.Write(South.ConvertObjectToKML());
            sw.Write(East.ConvertObjectToKML());
            sw.Write(West.ConvertObjectToKML());
            sw.Write(MinAltitude.ConvertObjectToKML());
            sw.Write(MaxAltitude.ConvertObjectToKML());
            sw.Write(AltitudeMode.ConvertObjectToKML());
            sw.Write(ClosingTag(GetType()));

            return sw.ToString();
        }
    }
}
