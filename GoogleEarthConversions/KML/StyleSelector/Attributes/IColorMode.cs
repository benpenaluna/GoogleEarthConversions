using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleEarthConversions.Core.KML.StyleSelector.Attributes
{
    public interface IColorMode : IKMLFormat
    {
        ColorModeEnum Mode { get; set; }
    }
}
