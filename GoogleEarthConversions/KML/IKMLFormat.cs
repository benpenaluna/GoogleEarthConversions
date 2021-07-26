namespace GoogleEarthConversions.Core.KML
{
    public interface IKMLFormat
    {
        string SerialiseToKML();
        object DeserialiseFromKML();
    }
}
