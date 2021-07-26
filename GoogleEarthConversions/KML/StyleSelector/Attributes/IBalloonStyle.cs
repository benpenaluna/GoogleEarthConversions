namespace GoogleEarthConversions.Core.KML.StyleSelector.Attributes
{
    public interface IBalloonStyle : IKMLFormat
    {
        string Id { get; set; }
        string TargetId { get; set; }
        IColor Color { get; set; }
        IColorMode ColorMode { get; set; }
        IColor BgColor { get; set; }
        IColor TextColor { get; set; }
        IText Text { get; set; }
        IDisplayMode DisplayMode { get; set; }
    }
}
