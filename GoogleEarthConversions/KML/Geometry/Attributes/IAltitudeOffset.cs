using GeoFunctions.Core.Coordinates;

namespace GoogleEarthConversions.Core.KML.Geometry.Attributes
{
    public interface IAltitudeOffset : IKMLFormat
    {
        IDistance AltOffset { get; set; }
    }
}