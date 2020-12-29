using GoogleEarthConversions.Core.KML.AbstractView.Attributes;

namespace GoogleEarthConversions.Core.KML.AbstractView
{
    public abstract class AbstractView : GoogleEarthObject, IKMLFormat
    {
        // Source: https://developers.google.com/kml/documentation/kmlreference?hl=en#abstractview

        public TimePrimitive.TimePrimitive TimePrimitive { get; set; }

        public IViewerOptions ViewerOptions { get; set; }

        public IHorizFov HorizFov { get; set; }

        public abstract string ConvertObjectToKML();
    }
}
