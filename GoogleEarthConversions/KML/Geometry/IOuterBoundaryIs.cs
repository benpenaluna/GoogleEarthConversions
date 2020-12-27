namespace GoogleEarthConversions.Core.KML.Geometry
{
    public interface IOuterBoundaryIs : IKMLFormat
    {
        ILinearRing LinearRing { get; set; }
    }
}
