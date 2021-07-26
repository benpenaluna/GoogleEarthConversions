using GoogleEarthConversions.Core.KML.StyleSelector.Attributes;

namespace GoogleEarthConversions.Core.KML.StyleSelector
{
    public abstract class ColorStyle : GoogleEarthObject, IKMLFormat
    {
        public IColor Color { get; set; }
        public IColorMode ColorMode { get; set; }

        public abstract string SerialiseToKML();

        public abstract object DeserialiseFromKML();
    }
}
