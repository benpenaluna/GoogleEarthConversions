namespace GoogleEarthConversions.Core.KML.Geometry
{
    public abstract class Geometry : GoogleEarthObject, IKMLFormat
    {
        public abstract string ConvertObjectToKML();
    }
}
