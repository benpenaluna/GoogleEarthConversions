using GoogleEarthConversions.Core.KML;

namespace GoogleEarthConversions.Core.Common
{
    public interface IAltitudeMode : IKMLFormat
    {
        AltMode AltMode { get; set; }
    }
}
