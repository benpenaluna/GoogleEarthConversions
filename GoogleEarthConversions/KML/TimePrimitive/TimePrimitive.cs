namespace GoogleEarthConversions.Core.KML.TimePrimitive
{
    public abstract class TimePrimitive : GoogleEarthObject, IKMLFormat
    {
        public abstract string ConvertObjectToKML();
    }
}
