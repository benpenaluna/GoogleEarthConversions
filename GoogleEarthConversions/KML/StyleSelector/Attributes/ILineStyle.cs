using GoogleEarthConversions.Core.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleEarthConversions.Core.KML.StyleSelector.Attributes
{
    public interface ILineStyle : IKMLFormat
    {
        string Id { get; set; }
        string TargetId { get; set; }
        IColor Color { get; set; }
        IColorMode ColorMode { get; set; }
        IDoubleKML Width { get; set; }
        IColor OuterColor { get; set; }
        IDoubleKML OuterWidth { get; set; }
        IDoubleKML PhysicalWidth { get; set; }
        IBooleanKML LabelVisibility { get; set; }
    }
}
