namespace GoogleEarthConversions.Core.KML.StyleSelector
{
    public abstract class StyleSelector : GoogleEarthObject, IKMLFormat
    {

        public abstract string SerialiseToKML();
        public abstract object DeserialiseFromKML();
    }
}
