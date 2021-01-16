using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleEarthConversions.Core.KML.StyleSelector.Attributes
{
    public interface ILabelStyle : IKMLFormat
    {
        string Id { get; set; }
        string TargetId { get; set; }
        IColor Color { get; set; }
        IColorMode ColorMode { get; set; }
        IDoubleKML Scale { get; set; }
    }
}
