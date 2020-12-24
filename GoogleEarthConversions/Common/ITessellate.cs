using GoogleEarthConversions.Core.KML;
using System;

namespace GoogleEarthConversions.Core.Common
{
    public interface ITessellate : IKMLFormat
    {
        bool FollowsTerrain { get; set; }

        event EventHandler FollowsTerrain_Changed;
    }
}
