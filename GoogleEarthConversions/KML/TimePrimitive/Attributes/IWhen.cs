using System;

namespace GoogleEarthConversions.Core.KML.TimePrimitive.Attributes
{
    public interface IWhen : IKMLFormat
    {
        DateTime LocalDateTime { get; set; }
        TimeZoneInfo TimeZone { get; set; }
    }
}
