using GoogleEarthConversions.Core.Common;

namespace GoogleEarthConversions.Core.KML.StyleSelector.Attributes
{
    public interface ILineStyle : IKMLFormat
    {
        string Id { get; set; }
        string TargetId { get; set; }
        IColor Color { get; set; }
        IColorMode ColorMode { get; set; }
        GenericKML<double> Width { get; set; }
        IColor OuterColor { get; set; }
        GenericKML<double> OuterWidth { get; set; }
        GenericKML<double> PhysicalWidth { get; set; }
        GenericKML<bool> LabelVisibility { get; set; }
    }
}
