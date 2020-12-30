using GeoFunctions.Core.Coordinates;
using GeoFunctions.Core.Coordinates.Measurement;
using GoogleEarthConversions.Core.Common;
using GoogleEarthConversions.Core.Geographical;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleEarthConversions.Core.KML.Object.Attributes
{
    public class West : Longitude, ISphericalCoordinateKML
    {
        public West() : base() { }

        public West(double angle, AngleMeasurement measurement = AngleMeasurement.Degrees) : base(angle, measurement) { }

        public West(IAngle angle) : base(angle) { }

        public string ConvertObjectToKML()
        {
            return string.Format("<{0}>{1}</{0}>", nameof(West).ConvertFirstCharacterToLowerCase(), Angle.ToDegrees());
        }
    }
}
