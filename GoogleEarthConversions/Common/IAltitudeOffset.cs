using GeoFunctions.Core.Coordinates;
using GoogleEarthConversions.Core.KML;

namespace GoogleEarthConversions.Core.Common
{
    public interface IAltitudeOffset : IKMLFormat
    {
        IDistance AltOffset { get; set; }
    }
}