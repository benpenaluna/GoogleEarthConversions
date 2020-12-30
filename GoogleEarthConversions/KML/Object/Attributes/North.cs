using GeoFunctions.Core.Coordinates;
using GeoFunctions.Core.Coordinates.Measurement;
using GoogleEarthConversions.Core.Common;
using GoogleEarthConversions.Core.Geographical;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleEarthConversions.Core.KML.Object.Attributes
{
    public class North : Longitude, ISphericalCoordinateKML
    {
        public North() : base() { }

        public North(double angle, AngleMeasurement measurement = AngleMeasurement.Degrees) : base(angle, measurement) { }

        public North(IAngle angle) : base(angle) { }

        public string ConvertObjectToKML()
        {
            return string.Format("<{0}>{1}</{0}>", nameof(North).ConvertFirstCharacterToLowerCase(), Angle.ToDegrees());
        }
    }
}
