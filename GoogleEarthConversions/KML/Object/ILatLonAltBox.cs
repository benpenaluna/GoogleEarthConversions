using GoogleEarthConversions.Core.Geographical;
using GoogleEarthConversions.Core.KML.Geometry.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleEarthConversions.Core.KML.Object
{
    public interface ILatLonAltBox
    {
        IAltitudeMode AltitudeMode { get; set; }
        IDistanceKML MinAltitude { get; set; }
        IDistanceKML MaxAltitude { get; set; }
        IAngleKML North { get; set; }
        IAngleKML South { get; set; }
        IAngleKML East { get; set; }
        IAngleKML West { get; set; }
    }
}
