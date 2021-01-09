using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleEarthConversions.Core.KML.StyleSelector.Attributes
{
    public interface IPolyStyle : IKMLFormat
    {
        string Id { get; set; }
        string TargetId { get; set; }
        IColor Color { get; set; }
        IColorMode ColorMode { get; set; }
        IBooleanKML Fill { get; set; }
        IBooleanKML Outline { get; set; }
    }
}
