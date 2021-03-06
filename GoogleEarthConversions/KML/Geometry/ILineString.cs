﻿using GoogleEarthConversions.Core.KML.Geometry.Attributes;
using System.Collections.Generic;

namespace GoogleEarthConversions.Core.KML.Geometry
{
    public interface ILineString
    {
        string Id { get; set; }
        IAltitudeOffset AltitudeOffset { get; set; }
        IExtrude Extrude { get; set; }
        ITessellate Tessellate { get; set; }
        IAltitudeMode AltitudeMode { get; set; }
        IDrawOrder DrawOrder { get; set; }
        ICollection<ICoordinates> Coordinates { get; set; }
    }
}
