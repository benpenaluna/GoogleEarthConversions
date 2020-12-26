using GoogleEarthConversions.Core.Common;
using System.Collections.Generic;

namespace GoogleEarthConversions.Core.KML.Geometry
{
    public interface ILinearRing
    {
        IAltitudeOffset AltitudeOffset { get; set; }
        IExtrude Extrude { get; set; }
        ITessellate Tessellate { get; set; }
        IAltitudeMode AltitudeMode { get; set; }
        ICollection<ICoordinates> Coordinates { get; set; }
    }
}
