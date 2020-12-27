using System.Collections.Generic;

namespace GoogleEarthConversions.Core.KML.Geometry
{
    public interface IInnerBoundaryIs : IKMLFormat
    {
        ICollection<ILinearRing> LinearRings { get; set; }
    }
}
