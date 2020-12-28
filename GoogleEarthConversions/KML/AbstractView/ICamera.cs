using GoogleEarthConversions.Core.KML.AbstractView.Attributes;

namespace GoogleEarthConversions.Core.KML.AbstractView
{
    public interface ICamera : IKMLFormat
    {
        TimePrimitive.TimePrimitive TimePrimitive { get; set; }

        IViewerOptions ViewerOptions { get; set; }

        IHorizFov HorizFov { get; set; }
    }
}
