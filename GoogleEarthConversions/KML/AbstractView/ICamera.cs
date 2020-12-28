namespace GoogleEarthConversions.Core.KML.AbstractView
{
    public interface ICamera : IKMLFormat
    {
        TimePrimitive.TimePrimitive TimePrimitive { get; set; }
    }
}
