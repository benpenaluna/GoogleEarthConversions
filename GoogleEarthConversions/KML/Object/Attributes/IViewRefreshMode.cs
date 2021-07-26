namespace GoogleEarthConversions.Core.KML.Object.Attributes
{
    public interface IViewRefreshMode : IKMLFormat
    {
        ViewRefreshModeEnum Value { get; set; }
    }
}
