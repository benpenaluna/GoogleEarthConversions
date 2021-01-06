using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace GoogleEarthConversions.Core.KML.StyleSelector.Attributes
{
    public interface IColor : IKMLFormat
    {
        System.Drawing.Color Value { get; set; } 
        System.Drawing.Color DefaultColor { get; set; }
        string KmlTagName { get; set; }
    }
}
