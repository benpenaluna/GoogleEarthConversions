using GoogleEarthConversions.Core.KML.AbstractView.Attributes;

namespace GoogleEarthConversions.Core.KML.AbstractView
{
    public abstract class AbstractView : GoogleEarthObject
    {
        // Source: https://developers.google.com/kml/documentation/kmlreference?hl=en#abstractview

        IViewerOptions ViewerOptions { get; set; }

        IHorizFov HorizFov { get; set; }
    }
}
