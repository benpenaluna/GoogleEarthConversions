using GoogleEarthConversions.Core.KML;

namespace GoogleEarthConversions.Core.Common
{
    public interface IDrawOrder : IKMLFormat
    {
        int OrderValue { get; set; }
    }
}
