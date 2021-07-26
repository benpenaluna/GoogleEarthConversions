using GoogleEarthConversions.Core.KML;

namespace GoogleEarthConversions.Core.Common
{
    public interface IBooleanKML : IKMLFormat
    {
        string KmlTagName { get; set; }
        bool Value { get; set; }
        bool Default { get; set; }
    }
}
