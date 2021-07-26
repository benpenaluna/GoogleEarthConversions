namespace GoogleEarthConversions.Core.KML.StyleSelector.Attributes
{
    public interface IColorMode : IKMLFormat
    {
        ColorModeEnum Mode { get; set; }
    }
}
