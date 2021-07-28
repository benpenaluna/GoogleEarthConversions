using GoogleEarthConversions.Core.Common;

namespace GoogleEarthConversions.Core.KML.StyleSelector.Attributes
{
    public interface IPolyStyle : IKMLFormat
    {
        string Id { get; set; }
        string TargetId { get; set; }
        IColor Color { get; set; }
        IColorMode ColorMode { get; set; }
        GenericKML<bool> Fill { get; set; }
        GenericKML<bool> Outline { get; set; }
    }
}
