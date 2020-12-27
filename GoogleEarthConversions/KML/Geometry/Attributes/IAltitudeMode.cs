using System;

namespace GoogleEarthConversions.Core.KML.Geometry.Attributes
{
    public interface IAltitudeMode : IKMLFormat
    {
        AltMode AltMode { get; set; }

        event EventHandler AltMode_Changed;
    }
}
