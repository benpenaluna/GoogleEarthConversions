using System;

namespace GoogleEarthConversions.Core.KML.Geometry.Attributes
{
    public interface ITessellate : IKMLFormat
    {
        bool FollowsTerrain { get; set; }

        event EventHandler FollowsTerrain_Changed;
    }
}
