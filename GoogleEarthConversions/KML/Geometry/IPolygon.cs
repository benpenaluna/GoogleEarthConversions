using GoogleEarthConversions.Core.Common;

namespace GoogleEarthConversions.Core.KML.Geometry
{
    public interface IPolygon
    {
        string Id { get; set; }
        IExtrude Extrude { get; set; }
        ITessellate Tessellate { get; set; }
        IAltitudeMode AltitudeMode { get; set; }
        IOuterBoundaryIs OuterBoundaryIs { get; set; }
        IInnerBoundaryIs InnerBoundaryIs { get; set; }
    }
}
