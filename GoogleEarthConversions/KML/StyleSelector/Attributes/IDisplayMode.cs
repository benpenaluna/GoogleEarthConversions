namespace GoogleEarthConversions.Core.KML.StyleSelector.Attributes
{
    public interface IDisplayMode : IKMLFormat
    {
        DisplayModeEnum Mode { get; set; }
    }
}
