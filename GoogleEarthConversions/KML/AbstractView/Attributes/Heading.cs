using GeoFunctions.Core.Coordinates;
using GeoFunctions.Core.Coordinates.Measurement;
using GoogleEarthConversions.Core.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleEarthConversions.Core.KML.AbstractView.Attributes
{
    public class Heading : Angle, IAngleKML
    {
        public Heading(double value = 0.0, AngleMeasurement measurement = AngleMeasurement.Degrees) : base(value, measurement) { }

        public string ConvertObjectToKML()
        {
            var heading = AngleMeasurement == AngleMeasurement.Degrees ? CoTerminalValue : Angle.ToDegrees(CoTerminalValue);
            
            return string.Format("<{0}>{1}</{0}>", nameof(Heading).ConvertFirstCharacterToLowerCase(), heading);
        }
    }
}
