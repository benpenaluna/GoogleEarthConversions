﻿using GoogleEarthConversions.Core.KML.StyleSelector.Attributes;

namespace GoogleEarthConversions.Core.KML.StyleSelector
{
    public interface IStyle : IKMLFormat
    {
        string Id { get; set; }
        string TargetId { get; set; }
        IIconStyle IconStyle { get; set; }
        ILabelStyle LabelStyle { get; set; }
        ILineStyle LineStyle { get; set; }
        IPolyStyle PolyStyle { get; set; }
        IBalloonStyle BalloonStyle { get; set; }
        IListStyle ListStyle { get; set; }
    }
}
