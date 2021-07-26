namespace GoogleEarthConversions.Core.KML.Object
{
    public interface IRegion : IKMLFormat
    {
        string Id { get; set; }
        string TargetId { get; set; }
        ILatLonAltBox LatLonAltBox { get; set; }
        ILod Lod { get; set; }
    }
}
