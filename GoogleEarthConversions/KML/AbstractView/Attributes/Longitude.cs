﻿using GeoFunctions.Core.Coordinates;
using GeoFunctions.Core.Coordinates.Measurement;
using GoogleEarthConversions.Core.Common;
using GoogleEarthConversions.Core.KML.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleEarthConversions.Core.KML.AbstractView.Attributes
{
    public class Longitude : GeoFunctions.Core.Coordinates.Longitude, ISphericalCoordinateKML
    {
        public Longitude() : base() { }

        public Longitude(double angle, AngleMeasurement measurement = AngleMeasurement.Degrees) : base(angle, measurement) { }

        public Longitude(IAngle angle) : base(angle) { }

        public string ConvertObjectToKML()
        {
            return string.Format("<{0}>{1}</{0}>", nameof(Longitude).ConvertFirstCharacterToLowerCase(), Angle.ToDegrees());
        }
    }
}
