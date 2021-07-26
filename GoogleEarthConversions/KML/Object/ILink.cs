using GoogleEarthConversions.Core.Common;
using GoogleEarthConversions.Core.KML.Object.Attributes;

namespace GoogleEarthConversions.Core.KML.Object
{
    public interface ILink : IKMLFormat
    {
        string Id { get; set; }
        string TargetId { get; set; }

        IHref Href { get; set; }
        IRefreshMode RefreshMode { get; set; }
        IDoubleKML RefreshInterval { get; set; }
        IViewRefreshMode ViewRefreshMode { get; set; }
        IDoubleKML ViewRefreshTime { get; set; }
        IDoubleKML ViewBoundScale { get; set; }
        IViewFormat ViewFormat { get; set; }
    }
}
