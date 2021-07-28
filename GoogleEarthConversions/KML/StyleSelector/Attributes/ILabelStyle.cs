using GoogleEarthConversions.Core.Common;

namespace GoogleEarthConversions.Core.KML.StyleSelector.Attributes
{
    public interface ILabelStyle : IKMLFormat
    {
        string Id { get; set; }
        string TargetId { get; set; }
        IColor Color { get; set; }
        IColorMode ColorMode { get; set; }
        GenericKML<double> Scale { get; set; }
    }
}
