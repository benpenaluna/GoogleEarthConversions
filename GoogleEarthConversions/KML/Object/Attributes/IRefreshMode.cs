namespace GoogleEarthConversions.Core.KML.Object.Attributes
{
    public interface IRefreshMode : IKMLFormat
    {
        RefreshModeEnum Value { get; set; }
    }
}
