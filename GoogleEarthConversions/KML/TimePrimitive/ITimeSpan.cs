using GoogleEarthConversions.Core.KML.TimePrimitive.Attributes;

namespace GoogleEarthConversions.Core.KML.TimePrimitive
{
    public interface ITimeSpan : IKMLFormat
    {
        ITimeSpanDateTime Begin { get; set; }
        ITimeSpanDateTime End { get; set; }
    }
}
