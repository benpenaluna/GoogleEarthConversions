namespace GoogleEarthConversions.Core.KML.Geometry.Attributes
{
    public interface IDrawOrder : IKMLFormat
    {
        int OrderValue { get; set; }
    }
}
