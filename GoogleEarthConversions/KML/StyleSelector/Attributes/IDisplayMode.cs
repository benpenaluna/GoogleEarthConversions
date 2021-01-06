using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleEarthConversions.Core.KML.StyleSelector.Attributes
{
    public interface IDisplayMode : IKMLFormat
    {
        DisplayModeEnum Mode { get; set; }
    }
}
