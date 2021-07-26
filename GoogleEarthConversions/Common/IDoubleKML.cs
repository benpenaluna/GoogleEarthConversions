using GoogleEarthConversions.Core.KML;

namespace GoogleEarthConversions.Core.Common
{
    public interface IDoubleKML : IKMLFormat
    {
        string KmlTagName { get; set; }
        double Value { get; set; }
        double Default { get; set; }
    }
}
