namespace GoogleEarthConversions.Core.KML.StyleSelector.Attributes
{
    public interface IHotSpot : IKMLFormat
    {
        double X { get; set; }
        double Y { get; set; }
        UnitsEnum Xunits { get; set; }
        UnitsEnum Yunits { get; set; }
    }
}
