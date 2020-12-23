using GoogleEarthConversions.Core.KML;
using System;

namespace GoogleEarthConversions.Core.Common
{
    public interface IAltitudeMode : IKMLFormat
    {
        AltMode AltMode { get; set; }

        event EventHandler AltMode_Changed;
    }
}
