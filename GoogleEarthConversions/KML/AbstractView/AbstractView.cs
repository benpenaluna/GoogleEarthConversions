using GoogleEarthConversions.Core.KML.AbstractView.Attributes;

namespace GoogleEarthConversions.Core.KML.AbstractView
{
    public abstract class AbstractView : GoogleEarthObject
    {
        IViewerOptions ViewerOptions { get; set; }
    }
}
