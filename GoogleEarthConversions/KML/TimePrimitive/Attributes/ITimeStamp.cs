namespace GoogleEarthConversions.Core.KML.TimePrimitive.Attributes
{
    public interface ITimeStamp : IKMLFormat
    {
        IWhen When { get; set; }
    }
}
