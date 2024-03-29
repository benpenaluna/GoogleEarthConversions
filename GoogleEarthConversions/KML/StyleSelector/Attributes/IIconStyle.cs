﻿using GoogleEarthConversions.Core.Common;
using GoogleEarthConversions.Core.Geographical;

namespace GoogleEarthConversions.Core.KML.StyleSelector.Attributes
{
    public interface IIconStyle : IKMLFormat
    {
        string Id { get; set; }
        string TargetId { get; set; }
        IColor Color { get; set; }
        IColorMode ColorMode { get; set; }
        GenericKML<double> Scale { get; set; }
        IAngleKML Heading { get; set; }
        IIcon Icon { get; set; }
        IHotSpot HotSpot { get; set; }
    }
}
