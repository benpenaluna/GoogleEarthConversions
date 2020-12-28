using System;

namespace GoogleEarthConversions.Core.KML.TimePrimitive.Attributes
{
    public interface ITimeSpanDateTime
    {
        DateTime DateTime { get; set; }
        bool Enabled { get; set; }
    }
}
