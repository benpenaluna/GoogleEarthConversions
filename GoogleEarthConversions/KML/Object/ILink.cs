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
        GenericKML<double> RefreshInterval { get; set; }
        IViewRefreshMode ViewRefreshMode { get; set; }
        GenericKML<double> ViewRefreshTime { get; set; }
        GenericKML<double> ViewBoundScale { get; set; }
        IViewFormat ViewFormat { get; set; }
    }
}
