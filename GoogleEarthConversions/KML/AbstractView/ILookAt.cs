using GoogleEarthConversions.Core.KML.AbstractView.Attributes;
using GoogleEarthConversions.Core.KML.Geometry.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleEarthConversions.Core.KML.AbstractView
{
    public interface ILookAt
    {
        TimePrimitive.TimePrimitive TimePrimitive { get; set; }
        IViewerOptions ViewerOptions { get; set; }
        IHorizFov HorizFov { get; set; }
        ISphericalCoordinateKML Longitude { get; set; }
        ISphericalCoordinateKML Latitude { get; set; }
        IDistanceKML Altitude { get; set; }
        IAngleKML Heading { get; set; }
        ISphericalCoordinateKML Tilt { get; set; }
        IDistanceKML Range { get; set; }
        IAltitudeMode AltitudeMode { get; set; }
    }
}
