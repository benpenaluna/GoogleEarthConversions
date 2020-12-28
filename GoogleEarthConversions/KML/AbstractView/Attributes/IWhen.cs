using System;

namespace GoogleEarthConversions.Core.KML.AbstractView.Attributes
{
    public interface IWhen : IKMLFormat
    {
        DateTime LocalDateTime { get; set; }
        TimeZoneInfo TimeZone { get; set; }
    }
}
