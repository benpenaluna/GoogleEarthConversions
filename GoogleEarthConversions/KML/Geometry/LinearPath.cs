using GoogleEarthConversions.Core.KML.Geometry.Attributes;
using System.Collections.Generic;

namespace GoogleEarthConversions.Core.KML.Geometry
{
    public abstract class LinearPath : Geometry
    {
        public IAltitudeOffset AltitudeOffset { get; set; }

        public ITessellate Tessellate { get; set; }

        public abstract ICollection<ICoordinates> Coordinates { get; set; }
    }
}
