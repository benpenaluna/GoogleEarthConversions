﻿using GeoFunctions.Core.Coordinates;

namespace GoogleEarthConversions.Core.KML.Geometry
{
    public interface IPoint
    {
        bool Extrude { get; set; }

        AltitudeMode AltitudeMode { get; set; }

        IGeographicCoordinate Coordinates { get; set; }
    }
}
