using System;

namespace GoogleEarthConversions.Core.KML.StyleSelector.Attributes
{
    public interface IStyleUrl : IKMLFormat
    {
        Uri Url { get; set; }
    }
}
